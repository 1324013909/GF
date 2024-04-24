
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI_Learning
{
    public class Test_NoFrame : MonoBehaviour
    {
        public StepInfoLogic StepPrefabs;//预制体

        void Start()
        {
            // 生成预制体
            StepInfoLogic step = Instantiate(StepPrefabs);
            // 传参
            step.OnOpen(new StepParams()
            {
                Title = "提示",
                Message = "这是第一步",
            });
        }
    }
}

