using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GFLearning
{
    public class CollectApples : BusinessBase
    {
        private Basket m_MyBasket = null;

        private float m_ElapseSeconds = 0f;

        public override void Initialize()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

            GameEntry.Entity.ShowCollectApples_Basket(new BasketData(GameEntry.Entity.GenerateSerialId(), 1)
            {
                Position = new Vector3(0, 0, -4.5f),
                Scale = new Vector3(4.5f,4.5f,4.5f),
            });

            isBusinessEnd = false;
            m_MyBasket = null;
        }

        protected override void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType == typeof(Basket))
            {
                m_MyBasket = (Basket)ne.Entity.Logic;
            }
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}
