using GameFramework.Fsm;
using GameFramework.Localization;
using GameFramework.Procedure;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GFLearning
{
    public class ProcedureLaunch : GameFramework.Procedure.ProcedureBase
    {
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            InitLocalization();//本地化数据加载
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //跳转到ProcedureSplash流程
            ChangeState<ProcedureSplash>(procedureOwner);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void InitLocalization()
        {
            if (GameEntry.Base.EditorResourceMode && GameEntry.Base.EditorLanguage != Language.Unspecified)//编辑器模式且语言已被指定
            {
                // 编辑器资源模式直接使用 Inspector 上设置的语言
                return;
            }

            Language language = GameEntry.Localization.Language; //获取当前的本地化语言
            if (GameEntry.Setting.HasSetting(Constant.Setting.Language)) //检查设置中是否存在名为 Constant.Setting.Language 的设置项
            {
                try
                {
                    string languageString = GameEntry.Setting.GetString(Constant.Setting.Language);
                    language = (Language)Enum.Parse(typeof(Language), languageString);//将字符串转换成相应的枚举值
                }
                catch
                {

                }
            }

            if (language != Language.English && language != Language.ChineseSimplified) //目前仅支持英语与简体中文
            {
                // 若是暂不支持的语言，则使用简体中文（默认）
                language = Language.ChineseSimplified;

                GameEntry.Setting.SetString(Constant.Setting.Language, language.ToString());//设置语言Constant.Setting.Language属性
                GameEntry.Setting.Save();//保存语言设置
            }

            GameEntry.Localization.Language = language;
            Log.Info("Init language settings complete, current language is '{0}'.", language.ToString());
        }
    }
}
