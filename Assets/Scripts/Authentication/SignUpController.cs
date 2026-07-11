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
        Debug.Log("✅ SignUpController Started");

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
        Debug.Log("✅ Create Account Button Clicked");

        RegisterUser();
    }

    private void RegisterUser()
    {
        Debug.Log("✅ RegisterUser() Started");

        string firstName = firstNameInput.text.Trim();
        string middleName = middleNameInput.text.Trim();
        string surname = surnameInput.text.Trim();
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        if (!int.TryParse(ageInput.text.Trim(), out int age))
        {
            Debug.Log("❌ Invalid age.");

            ShowMessage("Please enter a valid age.", Color.red);
            return;
        }

        if (string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(surname) ||
            string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            Debug.Log("❌ Required fields missing.");

            ShowMessage("Please fill in all required fields.", Color.red);
            return;
        }

        if (username.Contains(" "))
        {
            Debug.Log("❌ Username contains spaces.");

            ShowMessage("Username cannot contain spaces.", Color.red);
            return;
        }

        if (password != confirmPassword)
        {
            Debug.Log("❌ Passwords do not match.");

            ShowMessage("Passwords do not match.", Color.red);
            return;
        }

        if (password.Length < 6)
        {
            Debug.Log("❌ Password too short.");

            ShowMessage("Password must be at least 6 characters.", Color.red);
            return;
        }

        if (age < 13)
        {
            Debug.Log("❌ User is under 13.");

            ShowMessage("You must be at least 13 years old.", Color.red);
            return;
        }

        if (termsToggle == null || !termsToggle.isOn)
        {
            Debug.Log("❌ Terms and Conditions not accepted.");

            ShowMessage("Please accept the Terms and Conditions.", Color.red);
            return;
        }

        Debug.Log("✅ All validation passed.");

        createAccountButton.interactable = false;

        if (signUpPanel != null)
            signUpPanel.SetActive(false);

        if (successPanel != null)
            successPanel.SetActive(true);

        ShowMessage("Creating account...", Color.white);

        Debug.Log("✅ Calling AuthenticationManager.RegisterUser()");

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
        Debug.Log("✅ OnRegistrationCompleted() Called");
        Debug.Log("Success = " + success);
        Debug.Log("Message = " + message);

        createAccountButton.interactable = true;

        if (success)
        {
            Debug.Log("✅ Registration Successful");

            if (signUpPanel != null)
                signUpPanel.SetActive(false);

            if (successPanel != null)
                successPanel.SetActive(true);

            ShowMessage(message, Color.green);

            Invoke(nameof(OpenLoginScene), 1.5f);
        }
        else
        {
            Debug.Log("❌ Registration Failed");

            if (successPanel != null)
                successPanel.SetActive(false);

            if (signUpPanel != null)
                signUpPanel.SetActive(true);

            ShowMessage(message, Color.red);
        }
    }

    private void ShowMessage(string message, Color color)
    {
        Debug.Log("MESSAGE: " + message);

        if (messageText != null)
        {
            messageText.text = message;
            messageText.color = color;
        }
    }

   private void OpenLoginScene()
{
    Debug.Log("Opening Login Scene...");

    SceneManager.LoadScene("LoginScene");
}
}