using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    [Header("Toggles")]
    public Toggle rememberMeToggle;
    public Toggle showPasswordToggle;

    [Header("Buttons")]
    public Button loginAccountButton;
    public Button forgotPasswordButton;
    public Button signUpButton;

    [Header("UI")]
    public TMP_Text messageText;
    public GameObject loadingPanel;

    private void Start()
    {
        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        if (messageText != null)
            messageText.text = "";

        // Hide password by default
        if (passwordInput != null)
        {
            passwordInput.contentType = TMP_InputField.ContentType.Password;
            passwordInput.ForceLabelUpdate();
        }

        // Button events
        if (loginAccountButton != null)
            loginAccountButton.onClick.AddListener(OnLoginClicked);

        if (forgotPasswordButton != null)
            forgotPasswordButton.onClick.AddListener(OnForgotPasswordClicked);

        if (signUpButton != null)
            signUpButton.onClick.AddListener(OpenSignUpScene);

        if (showPasswordToggle != null)
            showPasswordToggle.onValueChanged.AddListener(TogglePasswordVisibility);

        LoadRememberedEmail();
    }

    private void OnLoginClicked()
    {
        Debug.Log("Login button clicked.");
    }

    private void OnForgotPasswordClicked()
    {
        Debug.Log("Forgot Password button clicked.");
    }

    private void OpenSignUpScene()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    private void TogglePasswordVisibility(bool showPassword)
    {
        passwordInput.contentType = showPassword
            ? TMP_InputField.ContentType.Standard
            : TMP_InputField.ContentType.Password;

        passwordInput.ForceLabelUpdate();
    }

    private void LoadRememberedEmail()
    {
        if (PlayerPrefs.HasKey("RememberedEmail"))
        {
            emailInput.text = PlayerPrefs.GetString("RememberedEmail");
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