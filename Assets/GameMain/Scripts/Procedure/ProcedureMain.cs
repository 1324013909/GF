using System;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEditor.PackageManager.Requests;

namespace GFLearning
{
    public class ProcedureMain : ProcedureBase
    {
        private BusinessBase m_CurrentBusiness = null;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_CurrentBusiness = new CollectApples();
            m_CurrentBusiness.Initialize();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (m_CurrentBusiness != null)
            {
                m_CurrentBusiness.Shutdown();
                m_CurrentBusiness = null;
            }

            base.OnLeave(procedureOwner, isShutdown);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

      

    }
}