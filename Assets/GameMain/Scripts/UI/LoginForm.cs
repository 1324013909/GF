using GameFramework.Localization;
using GFLearning;
using UnityEngine;
using UnityGameFramework.Runtime;
using System.Reflection;
using System.Collections.Generic;

namespace GFLearning
{
    public class LoginForm : UGuiForm
    {
        private UserData m_CurrentUser;
        public void OnLogButtonClick() //登录
        {
            string url = GameEntry.Config.GetString("Login.url");
            //创建表体
            WWWForm form = new WWWForm();
            #region  利用反射请展开
            //使用反射遍历 UserData 类的所有字段，并将它们添加到表单中
            FieldInfo[] fields = typeof(UserData).GetFields();
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(m_CurrentUser);
                form.AddField(field.Name, value.ToString());
            }
            #endregion
            form.AddField("acc", /*m_CurrentUser.acc*/"xiaoli");
            form.AddField("pwd", MD5Change(/*m_CurrentUser.pwd*/"123456"));
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
                m_CurrentUser = new UserData();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            if(m_CurrentUser != null)
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


        private class UserData//账号信息类
        {
            public string acc;
            public string pwd;
            public int src;


            // 构造函数
            public UserData(string account = "", string password ="")
            {
                acc = account;
                pwd = password;
                src = 3;
            }

            public void Clear()
            {
                acc = null;
                pwd = null;
            }
        }
    }
}
