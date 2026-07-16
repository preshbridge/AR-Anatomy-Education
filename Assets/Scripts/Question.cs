using System;

[Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswer;

    public Question(string question, string[] answers, int correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}