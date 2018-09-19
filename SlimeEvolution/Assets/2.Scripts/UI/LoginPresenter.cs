using SlimeEvolution.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolution.UI
{

    public class LoginPresenter : MonoBehaviour
    {
        [Header("Login Text")]
        [SerializeField]
        private Text loginID;
        [SerializeField]
        private Text loginPW;
        [SerializeField]
        private Text loginAlert;
        
        [Header("SignUp Text")]
        [SerializeField]
        private Text signUpID;
        [SerializeField]
        private Text signUpPW;
        [SerializeField]
        private Text confirmationPW;
        [SerializeField]
        private Text signUpAlert;

        [Header("Panel")]
        [SerializeField]
        private GameObject loginPanel;
        [SerializeField]
        private GameObject loginSuccessPanel;
        [SerializeField]
        private GameObject signUpSuccessPanel;
        

        void Start()
        {
            loginAlert.text = "";
            signUpAlert.text = "";
            DataManager.Instance.LoginResultCallback = ChangeLoginAlertText;
            DataManager.Instance.SignUpResultCallback = ChangeCreateAlertText;
        }

        public void OnClickedLoginButton()
        {
            if (loginID.text.Length == 0)
                loginAlert.text = "아이디를 입력해주세요.";
            else if (loginPW.text.Length == 0)
                loginAlert.text = "비밀번호를 입력해주세요.";
            else
                DataManager.Instance.Login(loginID.text, loginPW.text);
        }

        public void OnClickedSignUpButton()
        {
            if (signUpID.text.Length < 4)
            {
                signUpAlert.text = "아이디는 최소 4자여야 합니다.";
            }
            else if (signUpPW.text.Length < 4)
            {
                signUpAlert.text = "비밀번호는 최소 4자여야 합니다.";
            }
            else if (!signUpPW.text.Equals(confirmationPW.text))
                signUpAlert.text = "비밀번호와 일치하지 않습니다!";
            else
                DataManager.Instance.CreateNewAccount(signUpID.text, signUpPW.text);
        }

        public void ChangeLoginAlertText(string Text)
        {
            if (Text.Equals("성공"))
            {
                loginPanel.SetActive(!loginPanel.activeSelf);
                loginSuccessPanel.SetActive(!loginSuccessPanel.activeSelf);
            }
            else
                loginAlert.text = Text;
        }

        public void ChangeCreateAlertText(string Text)
        {
            if (Text.Equals("성공"))
            {
                signUpSuccessPanel.SetActive(!signUpSuccessPanel.activeSelf);
                signUpAlert.text = "";
            }
            else
                signUpAlert.text = Text;
        }
    }
}
