using UnityEngine;

public class UserSession : MonoBehaviour
{
    public static UserSession Instance;

    public string UserId;
    public string FirstName;
    public string MiddleName;
    public string Surname;
    public string Email;
    public int Age;
    public bool IsEmailVerified;

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
        }
    }

    public void SetUser(UserData data, bool verified)
    {
        UserId = data.userId;
        FirstName = data.firstName;
        MiddleName = data.middleName;
        Surname = data.surname;
        Email = data.email;
        Age = data.age;
        IsEmailVerified = verified;
    }

    public void Clear()
    {
        UserId = "";
        FirstName = "";
        MiddleName = "";
        Surname = "";
        Email = "";
        Age = 0;
        IsEmailVerified = false;
    }
}