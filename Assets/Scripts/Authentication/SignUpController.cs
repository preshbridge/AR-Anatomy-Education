using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUpController : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField firstNameInput;
    public TMP_InputField middleNameInput;
    public TMP_InputField surnameInput;
    public TMP_InputField usernameInput;
    public TMP_InputField ageInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    [Header("Terms & Conditions")]
    public Toggle termsToggle;

    [Header("Buttons")]
    public Button createAccountButton;
    public Button loginButton;

    [Header("UI")]
    public GameObject signUpPanel;
    public GameObject successPanel;
    public TMP_Text messageText;

    private void Start()
    {
        if (signUpPanel != null)
            signUpPanel.SetActive(true);

        if (successPanel != null)
            successPanel.SetActive(false);

        if (messageText != null)
            messageText.text = "";

        if (createAccountButton != null)
            createAccountButton.onClick.AddListener(OnCreateAccountClicked);

        if (loginButton != null)
            loginButton.onClick.AddListener(OpenLoginScene);
    }

    private void OnCreateAccountClicked()
    {
        RegisterUser();
    }

    private void RegisterUser()
    {
        string firstName = firstNameInput.text.Trim();
        string middleName = middleNameInput.text.Trim();
        string surname = surnameInput.text.Trim();
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        if (!int.TryParse(ageInput.text.Trim(), out int age))
        {
            ShowMessage("Please enter a valid age.", Color.red);
            return;
        }

        if (string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(surname) ||
            string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowMessage("Please fill in all required fields.", Color.red);
            return;
        }

        if (username.Contains(" "))
        {
            ShowMessage("Username cannot contain spaces.", Color.red);
            return;
        }

        if (password != confirmPassword)
        {
            ShowMessage("Passwords do not match.", Color.red);
            return;
        }

        if (password.Length < 6)
        {
            ShowMessage("Password must be at least 6 characters.", Color.red);
            return;
        }

        if (age < 13)
        {
            ShowMessage("You must be at least 13 years old.", Color.red);
            return;
        }

        if (termsToggle == null || !termsToggle.isOn)
        {
            ShowMessage("Please accept the Terms and Conditions.", Color.red);
            return;
        }

        createAccountButton.interactable = false;

        AuthenticationManager.Instance.RegisterUser(
            firstName,
            middleName,
            surname,
            username,
            age,
            password,
            OnRegistrationCompleted
        );
    }

    private void OnRegistrationCompleted(bool success, string message)
    {
        createAccountButton.interactable = true;

        if (success)
        {
            // Hide the form
            if (signUpPanel != null)
                signUpPanel.SetActive(false);

            // Show the success panel
            if (successPanel != null)
                successPanel.SetActive(true);

            // If messageText is outside the panels,
            // this will display the success message.
            ShowMessage(message, Color.green);

            // Go to Login after 1.5 seconds
            Invoke(nameof(OpenLoginScene), 1.5f);
        }
        else
        {
            // Hide success panel if it was visible
            if (successPanel != null)
                successPanel.SetActive(false);

            // Show the sign up form again
            if (signUpPanel != null)
                signUpPanel.SetActive(true);

            ShowMessage(message, Color.red);
        }
    }

    private void ShowMessage(string message, Color color)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.color = color;
        }
    }

    private void OpenLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}