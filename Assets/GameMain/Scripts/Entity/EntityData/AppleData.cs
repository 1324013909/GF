using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GFLearning.CollectApples
{
    /// <summary>
    /// CollectApples.AppleData
    /// </summary>
    public class AppleData : EntityData
    {
        [SerializeField]
        private int m_drag; //��������

        [SerializeField]
        private Vector3 m_initialVelocity;//��ʼ�����ٶ�

        public AppleData(int entityId, int typeId) : base(entityId, typeId)
        {
            Drag = 10;
            initialVelocity =  new Vector3(0,0,0);
        }

        /// <summary>
        /// ���õ���Ŀ�����������ʼ��
        /// </summary>
        public int Drag
        {
            get
            {
                return m_drag;
            }
            set
            {
               m_drag = value;
            }
        }

        /// <summary>
        /// ���õ�����ٶȣ���ʼ��
        /// </summary>
        public Vector3 initialVelocity
        {
            get
            {
                return m_initialVelocity;
            }
            set
            {
                m_initialVelocity = value;
            }
        }
    }
}