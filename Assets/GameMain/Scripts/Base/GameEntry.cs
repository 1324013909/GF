//------------------------------------------------------------
// Game Framework
// Copyright ? 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace GFLearning
{
    /// <summary>
    /// ��Ϸ��ڡ�
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();//��ʼ���������
            InitCustomComponents();//��ʼ���Զ�������
        }
    }
}
