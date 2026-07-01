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
}