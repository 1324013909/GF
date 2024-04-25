
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
        public void OnEnglishButtonClick() //�л�Ӣ��
        {
            m_SelectedLanguage = Language.English;

            SubmitChange();
        }

        public void OnSimplifiedChineseButtonClick() //�л���������
        {
            m_SelectedLanguage = Language.ChineseSimplified;

            SubmitChange();
        }

        public void OnQuitButtonClick()  //�˳���ť
        {

            Log.Error("�˳��ɹ�");
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
            Log.Warning("��ǰ����Ϊ��" + GameEntry.Localization.Language);
            if (m_SelectedLanguage == GameEntry.Localization.Language)
            {
                Close();
                return;
            }

            GameEntry.Setting.SetString(Constant.Setting.Language, m_SelectedLanguage.ToString());
            GameEntry.Setting.Save();

            //��������
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
