using GameFramework;
using GFLearning;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using System.Threading.Tasks;
using System;

namespace GFLearning
{
    public class Dialog_TempForm : UGuiForm
    {
        [SerializeField]
        private Text m_TitleText = null;

        [SerializeField]
        private Text m_MessageText = null;

        [SerializeField]
        private Image TitleBackground = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            HintParams hintParams = (HintParams)userData;
            m_TitleText.text = hintParams.Title;
            m_MessageText.text = hintParams.Message;
            TitleBackground.color = ColorUtilty.HexToColor(hintParams.TitleBackgroundColor);

            AutoCloseAsync();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_TitleText.text = string.Empty;
            m_MessageText.text = string.Empty;
            TitleBackground.color = ColorUtilty.HexToColor(GameEntry.Config.GetString("DefaultColor"));

            base.OnClose(isShutdown, userData);
        }

        private async void AutoCloseAsync()
        {
            // 等待一定时间后关闭UI
            await Task.Delay(TimeSpan.FromSeconds(3));

            Close();
        }
    }
}
