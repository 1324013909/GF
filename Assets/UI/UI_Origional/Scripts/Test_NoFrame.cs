
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI_Learning
{
    public class Test_NoFrame : MonoBehaviour
    {
        public StepInfoLogic StepPrefabs;//Ԥ����

        void Start()
        {
            // ����Ԥ����
            StepInfoLogic step = Instantiate(StepPrefabs);
            // ����
            step.OnOpen(new StepParams()
            {
                Title = "��ʾ",
                Message = "���ǵ�һ��",
            });
        }
    }
}

