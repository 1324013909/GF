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
        private int m_speed; //移动速度

        [SerializeField]
        private float startPosition; //移动速度

        public AppleTreeData(int entityId, int typeId) : base(entityId, typeId)
        {
           
        }

        /// <summary>
        /// 设置苹果树的移动速度（初始）
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
