using GameFramework.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFLearning
{
    public class Demo_try : MonoBehaviour
    {
        IEnumerator Start()
        {
            // �ӳ�����
            yield return new WaitForSeconds(0.1f);

            // ����������Դ
            string fontName = "SourceHanSansCN-Bold";

            GameEntry.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    UGuiForm.SetMainFont((Font)asset);
                },
                (assetName, status, errorMessage, userData) => { }));

            // ����Ԥ����·��
            string assetName = AssetUtility.GetUIFormAsset("UI");

            // ��UI ����1����Դ·��������2�����飬����3������
            GameEntry.UI.OpenUIForm(assetName, "Default", new StepParams()
            {
                Title = "��ʾ",
                Message = "���ǵ�һ��",
            });
        }
    }
}

