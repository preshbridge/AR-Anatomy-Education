using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    [Header("Panels")]
    public GameObject loginPanel;
    public GameObject successPanel;

    [Header("Buttons")]
    public Button loginButton;
    public Button signUpButton;
    public Button forgotPasswordButton;

    [Header("Toggles")]
    public Toggle rememberMeToggle;
    public Toggle showPasswordToggle;

    [Header("Text")]
    public TMP_Text messageText;

    private void Start()
    {
        loginPanel.SetActive(true);
        successPanel.SetActive(false);

        messageText.text = "";

        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();

        loginButton.onClick.AddListener(LoginUser);

        signUpButton.onClick.AddListener(OpenSignUpScene);

        forgotPasswordButton.onClick.AddListener(ForgotPassword);

        if (showPasswordToggle != null)
            showPasswordToggle.onValueChanged.AddListener(TogglePassword);

        LoadRememberedUsername();
    }

    private void TogglePassword(bool show)
    {
        passwordInput.contentType = show ?
            TMP_InputField.ContentType.Standard :
            TMP_InputField.ContentType.Password;

        passwordInput.ForceLabelUpdate();
    }

    private void LoginUser()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Please enter your username and password.", Color.red);
            return;
        }

        loginButton.interactable = false;

        ShowMessage("Logging in...", Color.white);

        AuthenticationManager.Instance.LoginUser(
            username,
            password,
            OnLoginCompleted
        );
    }

    private void OnLoginCompleted(bool success, string message)
    {
        loginButton.interactable = true;

        if (success)
        {
            if (rememberMeToggle != null && rememberMeToggle.isOn)
            {
                PlayerPrefs.SetString("RememberedUsername", usernameInput.text.Trim());
            }
            else
            {
                PlayerPrefs.DeleteKey("RememberedUsername");
            }

            loginPanel.SetActive(false);
            successPanel.SetActive(true);

            string welcomeName = "User";

            if (UserSession.Instance != null)
                welcomeName = UserSession.Instance.FirstName;

            ShowMessage("Login Successful!\n\nWelcome " + welcomeName + "!", Color.green);

            Invoke(nameof(OpenHomeScene), 2f);
        }
        else
        {
            loginPanel.SetActive(true);
            successPanel.SetActive(false);

            ShowMessage(message, Color.red);
        }
    }

    private void ForgotPassword()
    {
        ShowMessage("Please contact the administrator to reset your password.", Color.yellow);
    }

    private void OpenHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    private void OpenSignUpScene()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    private void LoadRememberedUsername()
    {
        if (PlayerPrefs.HasKey("RememberedUsername"))
        {
            usernameInput.text = PlayerPrefs.GetString("RememberedUsername");

            if (rememberMeToggle != null)
                rememberMeToggle.isOn = true;
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
}