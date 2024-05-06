using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using UnityEngine.UI;

namespace GFLearning
{
    public class LoginForm : UGuiForm
    {
        private UserData m_CurrentUser;

        public InputField m_UserName;
        public InputField m_Password;
        public void OnLogButtonClick() //��¼
        {
            string url = GameEntry.Config.GetString("Login.url");
            //��������
            WWWForm form = new WWWForm();
            #region  �����÷�����չ��
            //ʹ�÷������ UserData ��������ֶΣ�����������ӵ�����
            //FieldInfo[] fields = typeof(UserData).GetFields();
            //foreach (FieldInfo field in fields)
            //{
            //    object value = field.GetValue(m_CurrentUser);
            //    form.AddField(field.Name, value.ToString());
            //}
            #endregion

            form.AddField("acc", m_UserName.text);
            form.AddField("pwd", MD5Change(m_Password.text));
            form.AddField("src", 3);

            // ��������ͷ���� Content-Type
            Dictionary<string, string> headers = form.headers;
            headers["Content-Type"] = "application/json";
            GameEntry.WebRequest.AddWebRequest(url, form, this); //��������
        }

        public void OnClearButtonClick() //�����ǰ������Ϣ
        {
            m_CurrentUser.Clear();
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            if (m_CurrentUser == null)
                UserData_Initialize();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            if (m_CurrentUser != null)
                m_CurrentUser.Clear();

            base.OnClose(isShutdown, userData);
        }

        private string MD5Change(string str)//MD5���ܺ���
        {
            string str_md5 = "";
            byte[] buffer = System.Text.Encoding.Default.GetBytes(str);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] buffer_new = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer_new.Length; i++)
            {
                str_md5 += buffer_new[i].ToString("x2");
            }
            //str_md5 = str_md5.ToUpper();//��д
            return str_md5;
        }

        public void UserData_Initialize()
        {
            m_CurrentUser = new UserData();
            m_CurrentUser.SetMyLoginForm(this);
        }

        public class UserData
        {
            private string account;
            private string password;
            private int src;
            private LoginForm myLoginForm;

            public string Account
            {
                get { return account; }
                set
                {
                    account = value;
                    // ���� UI �е� accountText
                    try
                    {
                        myLoginForm.m_UserName.text = account;
                    }
                    catch
                    {
                        Log.Warning("LoginForm��������");
                    }

                }
            }

            public string Password
            {
                get { return password; }
                set
                {
                    password = value;
                    // ���� UI �е� passwordText
                    try
                    {
                        myLoginForm.m_Password.text = value;
                    }
                    catch
                    {
                        Log.Warning("LoginForm��������");
                    }
                }
            }

            // ���캯��
            public UserData(string account = "", string password = "")
            {
                this.account = account;
                this.password = password;
                src = 3;
            }

            public void SetMyLoginForm(LoginForm loginForm)
            {
                myLoginForm = loginForm;
            }

            public void Clear()
            {
                Account = "";
                Password = "";
            }
        }
    }
}
