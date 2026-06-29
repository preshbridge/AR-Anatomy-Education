using System;

[Serializable]
public class UserData
{
    public string userId;
    public string firstName;
    public string middleName;
    public string surname;
    public string email;
    public int age;
    public string createdAt;

    public UserData()
    {

    }

    public UserData(
        string userId,
        string firstName,
        string middleName,
        string surname,
        string email,
        int age)
    {
        this.userId = userId;
        this.firstName = firstName;
        this.middleName = middleName;
        this.surname = surname;
        this.email = email;
        this.age = age;

        createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}