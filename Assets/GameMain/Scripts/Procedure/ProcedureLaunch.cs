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

            InitLocalization();//���ػ����ݼ���
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //��ת��ProcedureSplash����
            ChangeState<ProcedureSplash>(procedureOwner);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void InitLocalization()
        {
            if (GameEntry.Base.EditorResourceMode && GameEntry.Base.EditorLanguage != Language.Unspecified)//�༭��ģʽ�������ѱ�ָ��
            {
                // �༭����Դģʽֱ��ʹ�� Inspector �����õ�����
                return;
            }

            Language language = GameEntry.Localization.Language; //��ȡ��ǰ�ı��ػ�����
            if (GameEntry.Setting.HasSetting(Constant.Setting.Language)) //����������Ƿ������Ϊ Constant.Setting.Language ��������
            {
                try
                {
                    string languageString = GameEntry.Setting.GetString(Constant.Setting.Language);
                    language = (Language)Enum.Parse(typeof(Language), languageString);//���ַ���ת������Ӧ��ö��ֵ
                }
                catch
                {

                }
            }

            if (language != Language.English && language != Language.ChineseSimplified) //Ŀǰ��֧��Ӣ�����������
            {
                // �����ݲ�֧�ֵ����ԣ���ʹ�ü������ģ�Ĭ�ϣ�
                language = Language.ChineseSimplified;

                GameEntry.Setting.SetString(Constant.Setting.Language, language.ToString());//��������Constant.Setting.Language����
                GameEntry.Setting.Save();//������������
            }

            GameEntry.Localization.Language = language;
            Log.Info("Init language settings complete, current language is '{0}'.", language.ToString());
        }
    }
}
