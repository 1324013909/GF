using GameFramework;
using UnityEngine;

namespace GFLearning
{
    /// <summary>
    /// 提示框显示数据。
    /// </summary>
    public class HintParams
    {

        /// <summary>
        /// 标题。
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容。
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 标题颜色
        /// </summary>
        public string TitleBackgroundColor
        {
            get;
            set;
        }

        /// <summary>
        /// 弹出窗口时是否暂停游戏。
        /// </summary>
        public bool PauseGame
        {
            get;
            set;
        }

        /// <summary>
        /// 确认按钮文本。
        /// </summary>
        public string ConfirmText
        {
            get;
            set;
        }

        /// <summary>
        /// 确定按钮回调。
        /// </summary>
        public GameFrameworkAction<object> OnClickConfirm
        {
            get;
            set;
        }

        /// <summary>
        /// 取消按钮文本。
        /// </summary>
        public string CancelText
        {
            get;
            set;
        }

        /// <summary>
        /// 取消按钮回调。
        /// </summary>
        public GameFrameworkAction<object> OnClickCancel
        {
            get;
            set;
        }

        /// <summary>
        /// 中立按钮文本。
        /// </summary>
        public string OtherText
        {
            get;
            set;
        }

        /// <summary>
        /// 其它按钮回调。
        /// </summary>
        public GameFrameworkAction<object> OnClickOther
        {
            get;
            set;
        }

        /// <summary>
        /// 用户自定义数据。
        /// </summary>
        public string UserData
        {
            get;
            set;
        }
    }
}
