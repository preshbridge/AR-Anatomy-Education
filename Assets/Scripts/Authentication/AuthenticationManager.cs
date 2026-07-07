using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class AuthenticationManager : MonoBehaviour
{
    public static AuthenticationManager Instance;

    public FirebaseAuth Auth { get; private set; }
    public DatabaseReference Database { get; private set; }

    public FirebaseUser CurrentUser => Auth.CurrentUser;

    private void Awake()
    {
        Debug.Log("AuthenticationManager Awake");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
{
    if (FirebaseManager.Instance != null && FirebaseManager.Instance.IsFirebaseReady)
    {
        InitializeAuth();
    }
    else if (FirebaseManager.Instance != null)
    {
        FirebaseManager.Instance.OnFirebaseReady += InitializeAuth;
    }
    else
    {
        Debug.LogError("FirebaseManager not found in the scene.");
    }
}

private void InitializeAuth()
{
    Auth = FirebaseAuth.DefaultInstance;
    Database = FirebaseDatabase.DefaultInstance.RootReference;

    Debug.Log("✅ Authentication Manager Ready");
}

    // ==========================
    // REGISTER USER
    // ==========================

    public void RegisterUser(
        string firstName,
        string middleName,
        string surname,
        int age,
        string email,
        string password,
        Action<bool, string> callback)
    {
        Auth.CreateUserWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    callback(false, "Registration cancelled.");
                    return;
                }

                if (task.IsFaulted)
                {
                    string error = task.Exception.Flatten().InnerExceptions[0].Message;

if (error.Contains("EMAIL_EXISTS") || error.Contains("already"))
{
    callback(false, "This email is already registered.");
}
else if (error.Contains("INVALID_EMAIL"))
{
    callback(false, "Invalid email address.");
}
else if (error.Contains("WEAK_PASSWORD"))
{
    callback(false, "Password is too weak.");
}
else
{
    callback(false, error);
}
                    return;
                }

                FirebaseUser user = task.Result.User;

                UserData newUser = new UserData(
                    user.UserId,
                    firstName,
                    middleName,
                    surname,
                    email,
                    age
                );

                string json = JsonUtility.ToJson(newUser);

                Database.Child("Users")
                    .Child(user.UserId)
                    .SetRawJsonValueAsync(json)
                    .ContinueWithOnMainThread(databaseTask =>
                    {
                        if (databaseTask.IsFaulted)
                        {
                            callback(false, "Failed to save user information.");
                            return;
                        }

                        user.SendEmailVerificationAsync()
                            .ContinueWithOnMainThread(emailTask =>
                            {
                                if (emailTask.IsCompleted)
                                {
                                    callback(true,
                                        "Account created successfully! Please verify your email before logging in.");
                                }
                                else
                                {
                                    callback(false,
                                        "Account created, but verification email could not be sent.");
                                }
                            });
                    });
            });
    }
    // ==========================
// LOGIN USER
// ==========================

public void LoginUser(string email, string password, Action<bool, string> callback)
{
    Auth.SignInWithEmailAndPasswordAsync(email, password)
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                callback(false, "Login cancelled.");
                return;
            }

            if (task.IsFaulted)
            {
                string error = task.Exception.Flatten().InnerExceptions[0].Message;

                if (error.Contains("INVALID_LOGIN_CREDENTIALS") || error.Contains("password is invalid") || error.Contains("no user record"))
                {
                    callback(false, "Incorrect email or password.");
                }
                else if (error.Contains("INVALID_EMAIL"))
                {
                    callback(false, "Invalid email address.");
                }
                else if (error.Contains("USER_DISABLED"))
                {
                    callback(false, "This account has been disabled.");
                }
                else
                {
                    callback(false, error);
                }
                return;
            }

            FirebaseUser user = task.Result.User;

            // Reload to get the latest email verification status
            user.ReloadAsync().ContinueWithOnMainThread(reloadTask =>
            {
                bool isVerified = user.IsEmailVerified;

                // Fetch the user's stored profile data ("memories") from the database
                Database.Child("Users").Child(user.UserId).GetValueAsync()
                    .ContinueWithOnMainThread(dbTask =>
                    {
                        if (dbTask.IsFaulted || !dbTask.Result.Exists)
                        {
                            callback(false, "Could not load your profile. Please try again.");
                            return;
                        }

                        string json = dbTask.Result.GetRawJsonValue();
                        UserData data = JsonUtility.FromJson<UserData>(json);

                        if (UserSession.Instance != null)
                        {
                            UserSession.Instance.SetUser(data, isVerified);
                        }

                        if (!isVerified)
                        {
                            callback(false, "Please verify your email before logging in. Check your inbox.");
                            return;
                        }

                        callback(true, "Login successful!");
                    });
            });
        });
}
}