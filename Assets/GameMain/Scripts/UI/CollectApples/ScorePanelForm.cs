using GameFramework;
using GFLearning;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using System.Threading.Tasks;
using System;
using System.Text;

namespace GFLearning.CollectApples
{
    public class ScorePanelForm : UGuiForm
    {
        [SerializeField]
        private Text HP;

        [SerializeField]
        private Text CurrentScore;

        [SerializeField]
        private Text HistoricalScore;

        /// <summary>
        /// 用于存放可变字符串
        /// </summary>
        private StringBuilder strb_HP;
        private StringBuilder strb_currScore;
        private StringBuilder strb_histScore;

        protected override void OnOpen(object userData)
        {
            //StringBuilderInit();
            base.OnOpen(userData);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        //private void StringBuilderInit()
        //{
        //    strb_HP = new StringBuilder(10);
        //    strb_currScore = new StringBuilder(10);
        //    strb_histScore = new StringBuilder(10);

        //    strb_HP.Append("1");
        //    strb_currScore.Append("2");
        //    strb_histScore.Append("3");
        //}

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
        }

        private string UpdateText(string textName, int newScore)
        {
            return $"this is {GameEntry.Localization.GetString(textName)}:{newScore}";
        }
    }
}
