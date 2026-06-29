using System;

[Serializable]
public class UserData
{
    public string FirstName;
    public string MiddleName;
    public string Surname;
    public int Age;
    public string Email;
    public string DateCreated;

    public UserData()
    {
    }

    public UserData(string firstName, string middleName, string surname,
                    int age, string email)
    {
        FirstName = firstName;
        MiddleName = middleName;
        Surname = surname;
        Age = age;
        Email = email;
        DateCreated = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }
}