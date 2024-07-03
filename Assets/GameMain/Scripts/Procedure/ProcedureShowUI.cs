using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Localization;
using GameFramework.Procedure;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GFLearning
{
    public class ProcedureShowUI : ProcedureBase
    {
        private MenuForm m_MenuForm = null;
        bool tag;
        int m_nextSceneID;

        public void ChangeToScene(int nextSceneID)
        {
            tag = !tag;
            m_nextSceneID = nextSceneID;
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            tag = false;
            m_nextSceneID = 0;

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);//打开MenuForm
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (tag)
            {
                //procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main")); 从Config读取
                procedureOwner.SetData<VarInt32>("NextSceneId", m_nextSceneID);
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
    }
}

