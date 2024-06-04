using System;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEditor.PackageManager.Requests;

namespace GFLearning
{
    public class ProcedureLogin : ProcedureBase
    {
        private LoginForm m_loginForm;
        private bool passTag;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, this);//打开LoginForm

            passTag = false;
            GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!passTag)
                return;

            ChangeState<ProcedureShowUI>(procedureOwner);
            //ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.Event.Unsubscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Unsubscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

            if (m_loginForm != null)
            {
                m_loginForm.Close(isShutdown);
                m_loginForm = null;
            }

            base.OnLeave(procedureOwner, isShutdown);
        }


        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            // 获取回应的数据
            string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());

            ApiCall info = JsonConvert.DeserializeObject<ApiCall>(responseJson);
            if (info.code == 40020)
                passTag = true;
            else
                GameEntry.UI.OpenUIForm(UIFormId.DialogFormTemp, new HintParams()
                {
                    Title = GameEntry.Localization.GetString("Error"),
                    Message = GameEntry.Localization.GetString("Login.Hint.AccOrPwdError"),
                    TitleBackgroundColor = GameEntry.Config.GetString("ErrorColor")
                });
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            Log.Error("请求失败");
            GameEntry.UI.OpenUIForm(UIFormId.DialogFormTemp, new HintParams()
            {
                Title = GameEntry.Localization.GetString("Error"),
                Message = GameEntry.Localization.GetString("Login.Hint.NoInternet"),
                TitleBackgroundColor = GameEntry.Config.GetString("ErrorColor")
            });
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_loginForm = (LoginForm)ne.UIForm.Logic;
            //如果UI设置为不暂停，无法关闭
        }
    }
}