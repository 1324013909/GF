using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning.CollectApples
{
    [DisallowMultipleComponent]
    /// <summary>
    /// CollectApples.Basket
    /// </summary>
    public class Basket : Entity
    {
        [SerializeField]
        private BasketData m_BasketData = null;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_BasketData = userData as BasketData;
            if (m_BasketData == null)
            {
                Log.Error("Error:CollectApples.Basket is invalid.");
                return;
            }

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Name = "MyBasket";
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

            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveX, moveY, 0);
            Vector3 newPosition = transform.position + move * 5 * Time.deltaTime;

            transform.position = newPosition;
        }
    }
}
