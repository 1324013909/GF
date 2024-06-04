using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning
{
    [DisallowMultipleComponent]
    /// <summary>
    /// CollectApples.Basket
    /// </summary>
    public class Basket : Entity
    {
        [SerializeField]
        private BasketData m_BasketData = null;

        public Rect m_PlayerMoveBoundary = default(Rect);

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

            // 根据屏幕的宽度和高度设置矩形的大小
            // 这里可以根据需要设置矩形的位置和大小
            m_PlayerMoveBoundary = new Rect(-screenWidth / 2, -screenHeight / 2, screenWidth, screenHeight);
            Log.Error("zuixiao:" + m_PlayerMoveBoundary.xMin + "zuida"+  m_PlayerMoveBoundary.xMax);

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

            // 限制物体移动在边界内
            newPosition.x = Mathf.Clamp(newPosition.x, m_PlayerMoveBoundary.xMin, m_PlayerMoveBoundary.xMax);
            newPosition.y = Mathf.Clamp(newPosition.y, m_PlayerMoveBoundary.yMin, m_PlayerMoveBoundary.yMax);

            transform.position = newPosition;
        }
    }
}
