using System;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using System.Collections.Generic;


namespace GFLearning
{
    public class ProcedureLogin : ProcedureBase
    {
        private bool passTag;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, this);//打开MenuForm


            passTag = false;
            GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if(!passTag)
                    return;

            ChangeState<ProcedureShowUI>(procedureOwner);
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

            //string responseJson = JsonConvert.SerializeObject(ne.GetWebResponseBytes());
            Log.Debug("responseJson：" + responseJson);
            passTag = true;
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            Log.Warning("请求失败");
        }
    }
}