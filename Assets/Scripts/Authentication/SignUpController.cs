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
    public TMP_InputField ageInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    [Header("Terms & Conditions")]
    public Toggle termsToggle;

    [Header("Buttons")]
    public Button createAccountButton;
    public Button loginButton;

    [Header("UI")]
    public GameObject signUpPanel;
    public GameObject loadingPanel;
    public TMP_Text messageText;

    private void Start()
    {
        // Hide loading panel when scene starts
        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        // Show Sign Up panel
        if (signUpPanel != null)
            signUpPanel.SetActive(true);

        // Clear message
        if (messageText != null)
            messageText.text = "";

        // Button listeners
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
        // Read user input
        string firstName = firstNameInput.text.Trim();
        string middleName = middleNameInput.text.Trim();
        string surname = surnameInput.text.Trim();
        string email = emailInput.text.Trim();
        string password = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        // Validate age
        if (!int.TryParse(ageInput.text.Trim(), out int age))
        {
            ShowMessage("Please enter a valid age.", Color.red);
            return;
        }

        // Check required fields
        if (string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(surname) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowMessage("Please fill in all required fields.", Color.red);
            return;
        }

        // Check passwords match
        if (password != confirmPassword)
        {
            ShowMessage("Passwords do not match.", Color.red);
            return;
        }

        // Password length
        if (password.Length < 6)
        {
            ShowMessage("Password must be at least 6 characters.", Color.red);
            return;
        }

        // Age check
        if (age < 13)
        {
            ShowMessage("You must be at least 13 years old.", Color.red);
            return;
        }

        // Terms and Conditions
        if (termsToggle == null || !termsToggle.isOn)
        {
            ShowMessage("Please accept the Terms and Conditions before creating an account.", Color.red);
            return;
        }

        // Hide Sign Up UI
        if (signUpPanel != null)
            signUpPanel.SetActive(false);

        // Show Loading UI
        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        createAccountButton.interactable = false;

        // Register user with Firebase
        AuthenticationManager.Instance.RegisterUser(
            firstName,
            middleName,
            surname,
            age,
            email,
            password,
            OnRegistrationCompleted
        );
    }

    private void OnRegistrationCompleted(bool success, string message)
    {
        // Hide Loading
        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        createAccountButton.interactable = true;

        if (success)
        {
            ShowMessage(message, Color.green);

            // Go to Login Scene after 3 seconds
            Invoke(nameof(OpenLoginScene), 3f);
        }
        else
        {
            // Show Sign Up screen again
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