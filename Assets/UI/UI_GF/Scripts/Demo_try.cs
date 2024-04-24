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
            // 延迟启动
            yield return new WaitForSeconds(0.1f);

            // 加载字体资源
            string fontName = "SourceHanSansCN-Bold";

            GameEntry.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    UGuiForm.SetMainFont((Font)asset);
                },
                (assetName, status, errorMessage, userData) => { }));

            // 加载预制体路径
            string assetName = AssetUtility.GetUIFormAsset("UI");

            // 打开UI 参数1：资源路径，参数2：分组，参数3：数据
            GameEntry.UI.OpenUIForm(assetName, "Default", new StepParams()
            {
                Title = "提示",
                Message = "这是第一步",
            });
        }
    }
}

