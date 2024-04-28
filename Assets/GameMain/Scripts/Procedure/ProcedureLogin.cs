using System;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Procedure;
using Newtonsoft.Json;
using System.Text;

namespace GFLearning
{
    public class ProcedureLogin : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
            string url = GameEntry.Config.GetString("Login.url");
            UserData userData = new UserData("xiaoli","123456");

            string jsonUserData = JsonConvert.SerializeObject(userData);
            byte[] userDataBytes = Encoding.UTF8.GetBytes(jsonUserData);
            GameEntry.WebRequest.AddWebRequest(url, userDataBytes, this);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Unsubscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
        }

        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            // 获取回应的数据
            string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());
            Log.Debug("responseJson：" + responseJson);
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            Log.Warning("请求失败");
        }

        //账号信息类
        private class UserData
        {
            public string acc;
            public string pwd;
            public int src;

            // 构造函数
            public UserData(string account, string password)
            {
                acc = account;
                pwd = password;
                src = 3;
            }
        }


    }
}
