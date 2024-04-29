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
        public void OnLogButtonClick() //��¼
        {
            string url = GameEntry.Config.GetString("Login.url");
            //��������
            WWWForm form = new WWWForm();
            #region  ���÷�����չ��
            //ʹ�÷������ UserData ��������ֶΣ�����������ӵ�����
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
                m_CurrentUser = new UserData();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            if(m_CurrentUser != null)
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


        private class UserData//�˺���Ϣ��
        {
            public string acc;
            public string pwd;
            public int src;


            // ���캯��
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
