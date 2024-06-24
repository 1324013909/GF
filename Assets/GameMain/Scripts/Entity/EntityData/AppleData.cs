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
        private int m_drag; //空气阻力

        [SerializeField]
        private Vector3 m_initialVelocity;//初始掉落速度

        public AppleData(int entityId, int typeId) : base(entityId, typeId)
        {
            Drag = 10;
            initialVelocity =  new Vector3(0,0,0);
        }

        /// <summary>
        /// 设置掉落的空气阻力（初始）
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
        /// 设置掉落的速度（初始）
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