using GameFramework.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GFLearning
{
    public class StepInfoForm : UGuiForm
    {
        [SerializeField]
        private Text m_TitleText = null;

        [SerializeField]
        private Text m_MessageText = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            StepParams stepParams = (StepParams)userData;
            if (stepParams == null)
            {
                Log.Warning("stepParams is invalid.");
                return;
            }

            m_TitleText.text = stepParams.Title;
            m_MessageText.text = stepParams.Message;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_TitleText.text = string.Empty;
            m_MessageText.text = string.Empty;

            base.OnClose(isShutdown, userData);
        }
    }
}
