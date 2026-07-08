using System;

[Serializable]
public class UserData
{
    public string userId;
    public string firstName;
    public string middleName;
    public string surname;
    public string username;
    public int age;
    public string passwordHash;

    public UserData(
        string userId,
        string firstName,
        string middleName,
        string surname,
        string username,
        int age,
        string passwordHash)
    {
        this.userId = userId;
        this.firstName = firstName;
        this.middleName = middleName;
        this.surname = surname;
        this.username = username;
        this.age = age;
        this.passwordHash = passwordHash;
    }
}