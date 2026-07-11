using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    [Header("Toggles")]
    public Toggle rememberMeToggle;
    public Toggle showPasswordToggle;

    [Header("Buttons")]
    public Button loginAccountButton;
    public Button forgotPasswordButton;
    public Button signUpButton;

    [Header("UI")]
public GameObject loginPanel;
public GameObject successPanel;
public TMP_Text messageText;
public GameObject loadingPanel;

    private void Start()
{
    if (loginPanel != null)
        loginPanel.SetActive(true);

    if (successPanel != null)
        successPanel.SetActive(false);

    if (loadingPanel != null)
        loadingPanel.SetActive(false);

    if (messageText != null)
        messageText.text = "";

    if (passwordInput != null)
    {
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
    }

    if (loginAccountButton != null)
        loginAccountButton.onClick.AddListener(OnLoginClicked);

    if (forgotPasswordButton != null)
        forgotPasswordButton.onClick.AddListener(OnForgotPasswordClicked);

    if (signUpButton != null)
        signUpButton.onClick.AddListener(OpenSignUpScene);

    if (showPasswordToggle != null)
        showPasswordToggle.onValueChanged.AddListener(TogglePasswordVisibility);

    LoadRememberedUsername();
}

    private void OnLoginClicked()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Please enter your username and password.", Color.red);
            return;
        }

        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        loginAccountButton.interactable = false;

        AuthenticationManager.Instance.LoginUser(
            username,
            password,
            OnLoginCompleted
        );
    }

    private void OnLoginCompleted(bool success, string message)
{
    Debug.Log("OnLoginCompleted called");
    Debug.Log("Success = " + success);

    if (loadingPanel != null)
        loadingPanel.SetActive(false);

    loginAccountButton.interactable = true;

    if (success)
    {
        Debug.Log("Login Successful!");

        if (loginPanel != null)
            loginPanel.SetActive(false);

        if (successPanel != null)
            successPanel.SetActive(true);

        ShowMessage(message, Color.green);

        if (rememberMeToggle != null && rememberMeToggle.isOn)
        {
            PlayerPrefs.SetString("RememberedUsername", usernameInput.text.Trim());
        }
        else
        {
            PlayerPrefs.DeleteKey("RememberedUsername");
        }

        Invoke(nameof(OpenHomeScene), 1.5f);
    }
    else
    {
        if (successPanel != null)
            successPanel.SetActive(false);

        if (loginPanel != null)
            loginPanel.SetActive(true);

        ShowMessage(message, Color.red);
    }
}
    private void OnForgotPasswordClicked()
    {
        ShowMessage(
            "Please contact the administrator to reset your password.",
            Color.yellow
        );
    }

    private void OpenSignUpScene()
    {
        SceneManager.LoadScene("SignUpScene");
    }

   private void OpenHomeScene()
{
    Debug.Log("Opening HomeScene...");

    SceneManager.LoadScene("HomeScene");
}
    private void TogglePasswordVisibility(bool showPassword)
    {
        passwordInput.contentType = showPassword
            ? TMP_InputField.ContentType.Standard
            : TMP_InputField.ContentType.Password;

        passwordInput.ForceLabelUpdate();
    }

    private void LoadRememberedUsername()
    {
        if (PlayerPrefs.HasKey("RememberedUsername"))
        {
            usernameInput.text =
                PlayerPrefs.GetString("RememberedUsername");

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