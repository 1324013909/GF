using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityGameFramework.Runtime;

namespace GFLearning.CollectApples
{
    [DisallowMultipleComponent]
    /// <summary>
    /// CollectApples.AppleTree
    /// </summary>
    public class AppleTree : Entity
    {
        [SerializeField]
        private AppleTreeData m_AppleTreeData = null;

        private float moveRange = 5.0f; // �ƶ���Χ
        private Vector3 startPosition;

        public float m_RealElapseSeconds = 0f;
        public float realInterval = 2.5f;

        // �ƶ�����
        private bool moveRight = true;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_RealElapseSeconds = 0;
            startPosition = transform.position;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_AppleTreeData = userData as AppleTreeData;
            if (m_AppleTreeData == null)
            {
                Log.Error("Error:CollectApples.Apple is invalid.");
                return;
            }

            //�趨����
            Name = Utility.Text.Format("AppleTree{0}", Id);
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

            m_RealElapseSeconds += realElapseSeconds;
            if(m_RealElapseSeconds >= realInterval) //����ƻ��
            {
                m_RealElapseSeconds = 0f;

                //�ж��Ƿ��л�����
                moveRight = Random.value > 0.4f;//60%�����л�����

                //����ƻ��
                GameEntry.Entity.ShowCollectApples_Apple(new AppleData(GameEntry.Entity.GenerateSerialId(), 3)
                {
                    Position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z),
                    Scale = new Vector3(5, 5, 5),
                });
            }


            //// ʹ�� Mathf.PingPong �����µ�Xλ��
            //float newX = Mathf.PingPong(Time.time * m_AppleTreeData.Speed, moveRange) - (moveRange / 2);
            //transform.position = new Vector3(startPosition.x + newX, transform.position.y, transform.position.z);

            // ���ݵ�ǰ�����ƶ�
            float moveDelta = m_AppleTreeData.Speed * realElapseSeconds;
            if (!moveRight)
            {
                moveDelta = -moveDelta;
            }

            float newX = transform.position.x + moveDelta;
            if (Mathf.Abs(newX - startPosition.x) > moveRange)
            {
                // ������Χ�����ƶ�
                moveRight = !moveRight;
                newX = Mathf.Clamp(newX, startPosition.x - moveRange, startPosition.x + moveRange);
            }

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        }
    }
}

