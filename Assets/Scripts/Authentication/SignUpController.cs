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
    public TMP_Text messageText;
    public GameObject loadingPanel;

    private void Start()
    {
        if (loadingPanel != null)
            loadingPanel.SetActive(false);

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

        // Check empty fields
        if (string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(surname) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowMessage("Please fill in all required fields.", Color.red);
            return;
        }

        // Passwords match
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

        // Terms & Conditions
        if (termsToggle == null || !termsToggle.isOn)
        {
            ShowMessage("Please accept the Terms and Conditions before creating an account.", Color.red);
            return;
        }

        // Show loading
        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        createAccountButton.interactable = false;

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
        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        createAccountButton.interactable = true;

        if (success)
        {
            ShowMessage(message, Color.green);

            // Return to Login Scene after 3 seconds
            Invoke(nameof(OpenLoginScene), 3f);
        }
        else
        {
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