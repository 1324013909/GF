using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GFLearning.InfiniteJump
{
    /// <summary>
    /// InfiniteJump.PlayerData
    /// </summary>
    public class PlayerData : EntityData
    {
        private Animator m_Anim;

        private SpriteRenderer m_Sprd;

        private Rigidbody2D m_Rb;

        private Collider2D m_coll;

        private float m_MoveSpeed;//移动速度
        private float m_JumpForce;//跳跃力度

        private bool m_isOnGround;

        private float m_MoveDirection_h; //水平移动方向(向右:1  向左:-1)
        private float m_JumpDirection_v; //垂直移动方向(向上: 1  向下: -1)

        private Vector2 m_Speed;//每帧移动

        public PlayerData(int entityId, int typeId) : base(entityId, typeId)
        {

        }

        public Animator Anim { get => m_Anim; set => m_Anim = value; }
        public SpriteRenderer Sprd { get => m_Sprd; set => m_Sprd = value; }
        public Rigidbody2D Rb { get => m_Rb; set => m_Rb = value; }
        public Collider2D Coll { get => m_coll; set => m_coll = value; }
        public float MoveSpeed { get => m_MoveSpeed; set => m_MoveSpeed = value; }
        public float JumpForce { get => m_JumpForce; set => m_JumpForce = value; }
        public bool IsOnGround { get => m_isOnGround; set => m_isOnGround = value; }
        public float MoveDirection_h { get => m_MoveDirection_h; set => m_MoveDirection_h = value; }
        public float JumpDirection_v { get => m_JumpDirection_v; set => m_JumpDirection_v = value; }
        public Vector2 Speed { get => m_Speed; set => m_Speed = value; }
    }
}