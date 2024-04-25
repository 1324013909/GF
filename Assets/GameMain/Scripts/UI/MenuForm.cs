
using GameFramework.Localization;
using GFLearning;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning
{
    public class MenuForm : UGuiForm
    {
        //private ProcedureMenu m_ProcedureMenu = null;

        private Language m_SelectedLanguage = Language.Unspecified;
        public void OnEnglishButtonClick() //切换英语
        {
            m_SelectedLanguage = Language.English;

            SubmitChange();
        }

        public void OnSimplifiedChineseButtonClick() //切换简体中文
        {
            m_SelectedLanguage = Language.ChineseSimplified;

            SubmitChange();
        }

        public void OnQuitButtonClick()  //退出按钮
        {

            Log.Error("退出成功");
            //GameEntry.UI.OpenDialog(new DialogParams()
            //{
            //    Mode = 2,
            //    Title = GameEntry.Localization.GetString("AskQuitGame.Title"),
            //    Message = GameEntry.Localization.GetString("AskQuitGame.Message"),
            //    OnClickConfirm = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            //});
        }

        private void SubmitChange()
        {
            Log.Warning("当前语言为：" + GameEntry.Localization.Language);
            if (m_SelectedLanguage == GameEntry.Localization.Language)
            {
                Close();
                return;
            }

            GameEntry.Setting.SetString(Constant.Setting.Language, m_SelectedLanguage.ToString());
            GameEntry.Setting.Save();

            //重新启动
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Restart);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_SelectedLanguage = GameEntry.Localization.Language;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_SelectedLanguage = GameEntry.Localization.Language;

            base.OnClose(isShutdown, userData);
        }
    }
}
