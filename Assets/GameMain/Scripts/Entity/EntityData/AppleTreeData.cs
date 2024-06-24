using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GFLearning.CollectApples
{
    /// <summary>
    /// CollectApples.AppleTreeData
    /// </summary>
    public class AppleTreeData : EntityData
    {
        [SerializeField]
        private int m_speed; //�ƶ��ٶ�

        [SerializeField]
        private float startPosition; //�ƶ��ٶ�

        public AppleTreeData(int entityId, int typeId) : base(entityId, typeId)
        {
           
        }

        /// <summary>
        /// ����ƻ�������ƶ��ٶȣ���ʼ��
        /// </summary>
        public int Speed
        {
            get
            {
                return m_speed;
            }
            set
            {
                m_speed = value;
            }
        }
    }
}
