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

    [Header("Password")]
    public Toggle showPasswordToggle;

    [Header("Terms")]
    public Toggle termsToggle;

    [Header("Buttons")]
    public Button createAccountButton;
    public Button loginButton;

    [Header("Panels")]
    public GameObject signUpPanel;
    public GameObject successPanel;

    [Header("Text")]
    public TMP_Text messageText;

    private void Start()
    {
        signUpPanel.SetActive(true);
        successPanel.SetActive(false);

        messageText.text = "";

        passwordInput.contentType = TMP_InputField.ContentType.Password;
        confirmPasswordInput.contentType = TMP_InputField.ContentType.Password;

        passwordInput.ForceLabelUpdate();
        confirmPasswordInput.ForceLabelUpdate();

        createAccountButton.onClick.AddListener(RegisterUser);

        loginButton.onClick.AddListener(OpenLoginScene);

        if(showPasswordToggle != null)
            showPasswordToggle.onValueChanged.AddListener(TogglePassword);
    }

    private void TogglePassword(bool show)
    {
        passwordInput.contentType = show ?
            TMP_InputField.ContentType.Standard :
            TMP_InputField.ContentType.Password;

        confirmPasswordInput.contentType = show ?
            TMP_InputField.ContentType.Standard :
            TMP_InputField.ContentType.Password;

        passwordInput.ForceLabelUpdate();
        confirmPasswordInput.ForceLabelUpdate();
    }

    private void RegisterUser()
    {
        string firstName = firstNameInput.text.Trim();
        string middleName = middleNameInput.text.Trim();
        string surname = surnameInput.text.Trim();
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        if(!int.TryParse(ageInput.text,out int age))
        {
            ShowMessage("Please enter a valid age.",Color.red);
            return;
        }

        if(firstName=="" || surname=="" || username=="" || password=="")
        {
            ShowMessage("Please fill all required fields.",Color.red);
            return;
        }

        if(password!=confirmPassword)
        {
            ShowMessage("Passwords do not match.",Color.red);
            return;
        }

        if(password.Length<6)
        {
            ShowMessage("Password must be at least 6 characters.",Color.red);
            return;
        }

        if(age<13)
        {
            ShowMessage("You must be at least 13 years old.",Color.red);
            return;
        }

        if(!termsToggle.isOn)
        {
            ShowMessage("Please accept the Terms & Conditions.",Color.red);
            return;
        }

        createAccountButton.interactable = false;

        ShowMessage("Creating account...",Color.white);

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

    private void OnRegistrationCompleted(bool success,string message)
    {
        createAccountButton.interactable = true;

        if(success)
        {
            signUpPanel.SetActive(false);
            successPanel.SetActive(true);

            ShowMessage("Account created successfully!\n\nPlease login using your Username and Password.",Color.green);

            Invoke(nameof(OpenLoginScene),2f);
        }
        else
        {
            signUpPanel.SetActive(true);
            successPanel.SetActive(false);

            ShowMessage(message,Color.red);
        }
    }

    private void ShowMessage(string msg,Color color)
    {
        messageText.text=msg;
        messageText.color=color;
    }

    private void OpenLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}