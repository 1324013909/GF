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
        public void OnLogButtonClick() //登录
        {
            string url = GameEntry.Config.GetString("Login.url");
            //创建表体
            WWWForm form = new WWWForm();
            #region  若利用反射请展开
            //使用反射遍历 UserData 类的所有字段，并将它们添加到表单中
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

            // 设置请求头参数 Content-Type
            Dictionary<string, string> headers = form.headers;
            headers["Content-Type"] = "application/json";
            GameEntry.WebRequest.AddWebRequest(url, form, this); //发送请求
        }

        public void OnClearButtonClick() //清除当前输入信息
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

        private string MD5Change(string str)//MD5加密函数
        {
            string str_md5 = "";
            byte[] buffer = System.Text.Encoding.Default.GetBytes(str);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] buffer_new = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer_new.Length; i++)
            {
                str_md5 += buffer_new[i].ToString("x2");
            }
            //str_md5 = str_md5.ToUpper();//大写
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
                    // 更新 UI 中的 accountText
                    try
                    {
                        myLoginForm.m_UserName.text = account;
                    }
                    catch
                    {
                        Log.Warning("LoginForm关联出错");
                    }

                }
            }

            public string Password
            {
                get { return password; }
                set
                {
                    password = value;
                    // 更新 UI 中的 passwordText
                    try
                    {
                        myLoginForm.m_Password.text = value;
                    }
                    catch
                    {
                        Log.Warning("LoginForm关联出错");
                    }
                }
            }

            // 构造函数
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
