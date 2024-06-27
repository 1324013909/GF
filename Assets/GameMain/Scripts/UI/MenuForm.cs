
using GameFramework.Localization;
using GFLearning;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning
{
    public class MenuForm : UGuiForm
    {
        private ProcedureShowUI m_ProcedureShowUI = null;

        [SerializeField]
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
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = GameEntry.Localization.GetString("AskQuitGame.Title"),
                Message = GameEntry.Localization.GetString("AskQuitGame.Message"),
                OnClickConfirm = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            });
        }

        public void OnCollectScene()
        {
            m_ProcedureShowUI.ChangeToScene();
        }

        private void SubmitChange()
        {
            if (m_SelectedLanguage == GameEntry.Localization.Language)
            {
                GameEntry.UI.OpenUIForm(UIFormId.Dialog_TempForm, new HintParams()
                {
                    Title = GameEntry.Localization.GetString("Tip"),
                    Message = GameEntry.Localization.GetString("Language.Tip.RepeatSetting"),
                    TitleBackgroundColor = GameEntry.Config.GetString("TipColor")
                });
                //Close();�رյ�ǰUI
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

            m_ProcedureShowUI = (ProcedureShowUI)userData;
            if (m_ProcedureShowUI == null)
            {
                Log.Warning("ProcedureShowUI is invalid when open MenuForm.");
                return;
            }

            m_SelectedLanguage = GameEntry.Localization.Language;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureShowUI = null;

            m_SelectedLanguage = GameEntry.Localization.Language;

            base.OnClose(isShutdown, userData);
        }
    }
}
