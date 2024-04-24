using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UI_Learning
{
    public class StepInfoLogic : MonoBehaviour
    {
        [SerializeField]
        private Text m_TitleText = null;

        [SerializeField]
        private Text m_MessageText = null;

        void Start()
        {
        }

        public void OnOpen(object userData)
        {
            StepParams stepParams = (StepParams)userData;
            if (stepParams == null)
            {
                Debug.Log("stepParams is invalid.");
                return;
            }

            m_TitleText.text = stepParams.Title;
            m_MessageText.text = stepParams.Message;
        }

        public void OnClose(object userData)
        {
            m_TitleText.text = string.Empty;
            m_MessageText.text = string.Empty;
        }
    }
}


