using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;

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
                callback(false, task.Exception.Flatten().InnerExceptions[0].Message);
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
                    .ContinueWithOnMainThread(dbTask =>
                    {
                        if (dbTask.IsCompleted)
                        {
                            user.SendEmailVerificationAsync()
                                .ContinueWithOnMainThread(emailTask =>
                                {
                                    callback(true,
                                        "Account created successfully! Please verify your email.");
                                });
                        }
                        else
                        {
                            callback(false,
                                "Failed to save user information.");
                        }
                    });
        });
}
}