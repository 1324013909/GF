using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning.CollectApples
{
    [DisallowMultipleComponent]
    /// <summary>
    /// CollectApples.Apple
    /// </summary>
    public class Apple : Entity
    {
        [SerializeField]
        private AppleData m_AppleData = null;

        [SerializeField]
        private Rigidbody m_Rigidbody = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_AppleData = userData as AppleData;
            if (m_AppleData == null)
            {
                Log.Error("Error:CollectApples.Apple is invalid.");
                return;
            }

            m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
            if(m_Rigidbody == null)
            {
                Log.Error("Error:CollectApples.Apple is invalid.");
                return;
            }

            m_Rigidbody.drag = m_AppleData.Drag;
            m_Rigidbody.velocity = m_AppleData.initialVelocity;

            //Éè¶¨Ãû³Æ
            Name = "Droping Apple" + Id;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        protected virtual void OnDead(Entity attacker)
        {
            GameEntry.Entity.HideEntity(this);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}
