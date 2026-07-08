using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class AuthenticationManager : MonoBehaviour
{
    public static AuthenticationManager Instance;

    public DatabaseReference Database { get; private set; }

    private void Awake()
    {
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
            InitializeDatabase();
        }
        else if (FirebaseManager.Instance != null)
        {
            FirebaseManager.Instance.OnFirebaseReady += InitializeDatabase;
        }
        else
        {
            Debug.LogError("FirebaseManager not found.");
        }
    }

    private void InitializeDatabase()
    {
        Database = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log("Authentication Manager Ready");
    }

    //=========================
    // PASSWORD HASHING
    //=========================

    private string HashPassword(string password)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();

            foreach (byte b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }

    //=========================
    // REGISTER USER
    //=========================

    public void RegisterUser(
        string firstName,
        string middleName,
        string surname,
        string username,
        int age,
        string password,
        Action<bool, string> callback)
    {
        string usernameLower = username.Trim().ToLower();

        Database.Child("Users")
            .OrderByChild("usernameLower")
            .EqualTo(usernameLower)
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    callback(false, "Something went wrong.");
                    return;
                }

                if (task.Result.Exists)
                {
                    callback(false, "Username already exists.");
                    return;
                }

                string userId = Database.Child("Users").Push().Key;

                UserData newUser = new UserData(
                    userId,
                    firstName,
                    middleName,
                    surname,
                    username,
                    age,
                    HashPassword(password)
                );

                string json = JsonUtility.ToJson(newUser);

                Database.Child("Users")
                    .Child(userId)
                    .SetRawJsonValueAsync(json)
                    .ContinueWithOnMainThread(saveTask =>
                    {
                        if (saveTask.IsFaulted)
                        {
                            callback(false, "Could not create account.");
                            return;
                        }

                        Database.Child("Users")
                            .Child(userId)
                            .Child("usernameLower")
                            .SetValueAsync(usernameLower);

                        callback(true, "Sign Up Successful!");
                    });
            });
    }

    //=========================
    // LOGIN USER
    //=========================

    public void LoginUser(
        string username,
        string password,
        Action<bool, string> callback)
    {
        string usernameLower = username.Trim().ToLower();

        Database.Child("Users")
            .OrderByChild("usernameLower")
            .EqualTo(usernameLower)
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    callback(false, "Something went wrong.");
                    return;
                }

                if (!task.Result.Exists)
                {
                    callback(false, "Username or password is incorrect.");
                    return;
                }

                DataSnapshot snapshot = task.Result.Children.First();

                string storedHash =
                    snapshot.Child("passwordHash").Value.ToString();

                if (storedHash != HashPassword(password))
                {
                    callback(false, "Username or password is incorrect.");
                    return;
                }

                UserData data =
                    JsonUtility.FromJson<UserData>(snapshot.GetRawJsonValue());

                if (UserSession.Instance != null)
                {
                    UserSession.Instance.SetUser(data);
                }

                callback(true, "Login Successful!");
            });
    }
}