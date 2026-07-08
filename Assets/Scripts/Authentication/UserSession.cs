using UnityEngine;

public class UserSession : MonoBehaviour
{
    public static UserSession Instance;

    public string UserId;
    public string FirstName;
    public string MiddleName;
    public string Surname;
    public string Username;
    public int Age;

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

    public void SetUser(UserData data)
    {
        UserId = data.userId;
        FirstName = data.firstName;
        MiddleName = data.middleName;
        Surname = data.surname;
        Username = data.username;
        Age = data.age;
    }

    public void Clear()
    {
        UserId = "";
        FirstName = "";
        MiddleName = "";
        Surname = "";
        Username = "";
        Age = 0;
    }
}