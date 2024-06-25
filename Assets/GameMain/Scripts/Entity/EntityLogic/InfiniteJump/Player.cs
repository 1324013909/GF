using GameFramework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning.InfiniteJump
{
    [DisallowMultipleComponent]
    /// <summary>
    /// InfiniteJump.Player
    /// </summary>
    public class Apple : Entity
    {
        [SerializeField]
        private PlayerData m_PlayerData = null;

        [SerializeField]
        private LayerMask m_LayerMask;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_PlayerData = userData as PlayerData;
            if (m_PlayerData == null)
            {
                Log.Error("Error:InfiniteJump.Player is invalid.");
                return;
            }
            PlayerDataInit();

            //设置名称
            Name = "MyPlayer" + Id;
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

            // isOnGroundCheck();

            IsPlayerMove();
            IsPlayerJump();
            //移动计算
            m_PlayerData.Speed = new Vector2(m_PlayerData.MoveDirection * m_PlayerData.MoveSpeed * Time.deltaTime, m_PlayerData.JumpDirectionV * m_PlayerData.MoveSpeed * Time.deltaTime);
            GetComponent<Transform>().Translate(m_PlayerData.Speed);
        }

        private void PlayerDataInit()
        {
            m_PlayerData.Anim = this.GetComponent<Animator>();
            m_PlayerData.Sprd = this.GetComponent<SpriteRenderer>();
            m_PlayerData.Rb = this.GetComponent<Rigidbody2D>();
            m_PlayerData.Coll = this.GetComponent<Collider2D>();
            m_PlayerData.MoveSpeed = this.GetComponent<float>();
            m_PlayerData.JumpForce = this.GetComponent<float>();

            m_PlayerData.MoveDirection = 0;
        }

        private void IsPlayerMove()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_PlayerData.Anim.SetBool("isRun", true);
                m_PlayerData.MoveDirection = -1;
                m_PlayerData.Sprd.flipX = true;//设置镜像 
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                m_PlayerData.Anim.SetBool("isRun", true);
                m_PlayerData.MoveDirection = 1;
                m_PlayerData.Sprd.flipX = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                m_PlayerData.Anim.SetBool("isRun", false);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                m_PlayerData.Anim.SetBool("isRun", false);
            }
            else
            {
                m_PlayerData.MoveDirection = 0;
            }
        }

        private void IsPlayerJump()
        {
            if (Input.GetKey(KeyCode.Space) && m_PlayerData.IsOnGround)
            {
                m_PlayerData.Anim.SetBool("isJump", true);

                PlayerJumpAction();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                m_PlayerData.Anim.SetBool("isJump", false);
            }
        }

        private void PlayerJumpAction()
        {
            m_PlayerData.Rb.velocity = new Vector2(m_PlayerData.Rb.velocity.x,)
        }
    }
}
