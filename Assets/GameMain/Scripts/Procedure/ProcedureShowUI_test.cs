using System;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Resource;
using UnityEngine;
using GameFramework.Procedure;

namespace GFLearning
{
    public class ProcedureShowUI_test : ProcedureBase
    {

        /// <summary>
        /// 拿到主菜单UI引用
        /// </summary>
        private StepInfoForm m_StepForm;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess); //订阅事件
            //OpenUIFormSuccessEventArgs.EventI => OpenUIForm方法触发


            string fontName = "SourceHanSansCN-Bold";
            GameEntry.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    UGuiForm.SetMainFont((Font)asset);
                    Log.Info("Load font '{0}' OK.", fontName);
                },

                (assetName, status, errorMessage, userData) =>
                {
                    Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
                }));

            string assetName = AssetUtility.GetUIFormAsset("MenuForm");
            GameEntry.UI.OpenUIForm(assetName, "Default", new StepParams()
            {
                Title = "提示",
                Message = "这是第一步",
            });
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if(m_StepForm != null)
            GameEntry.UI.CloseUIForm(m_StepForm.UIForm);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_StepForm = (StepInfoForm)ne.UIForm.Logic;
            GameFrameworkLog.Info("Has get the MenuForm");
        }
    }
}

