using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning.InfiniteJump
{
    public class InfiniteJumpBusiness : BusinessBase
    {
        private Player m_MyPlayer = null;

        private float m_ElapseSeconds = 0f;

        public override void Initialize()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

            //GameEntry.Entity.ShowCollectApples_Basket(new BasketData(GameEntry.Entity.GenerateSerialId(), 1)
            //{
            //    Position = new Vector3(0, -4.5f, 2f),
            //    Rotation = Quaternion.Euler(-90, 0, 0),
            //    Scale = new Vector3(4.5f, 4.5f, 4.5f),
            //});

            //GameEntry.Entity.ShowCollectApples_AppleTree(new AppleTreeData(GameEntry.Entity.GenerateSerialId(), 2)
            //{
            //    Position = new Vector3(0, 3.1f, 2f),
            //    Rotation = Quaternion.Euler(-90, 0, 0),
            //    Scale = new Vector3(0.65f, 0.65f, 0.65f),
            //    Speed = 1,
            //});

            //GameEntry.UI.OpenUIForm(UIFormId.Dialog_TempForm, this);
           // GameEntry.UI.OpenUIForm(UIFormId.CollectApples_ScorePanelForm, this);//´ò¿ªLoginForm

            isBusinessEnd = false;
            m_MyPlayer = null;
        }

        protected override void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType == typeof(Player))
            {
                m_MyPlayer = (Player)ne.Entity.Logic;
            }
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}
