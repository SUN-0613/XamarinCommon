﻿namespace AYam.Common.MVVM.Custom
{

    /// <summary>
    /// ViewModel基幹
    /// 編集FLG付
    /// </summary>
    public class EditedViewModelBase : ViewModelBase
    {

        /// <summary>
        /// 編集FLG
        /// True:編集済
        /// False:未編集
        /// </summary>
        private bool _IsEdited = false;

        /// <summary>
        /// 編集FLG
        /// True:編集済
        /// False:未編集
        /// </summary>
        public bool IsEdited
        {
            get { return _IsEdited; }
            private set
            {
                _IsEdited = value;
                CallPropertyChanged(nameof(IsEdited));
            }
        }

        /// <summary>
        /// 編集FLGの更新対象外プロパティ名
        /// 初期値："Call"
        /// </summary>
        /// <remarks>先頭一致するプロパティ名の場合はIsEditedを更新しない</remarks>
        public string ThrowEditEventName { private get; set; } = "Call";

        /// <summary>
        /// PropertyChanged()呼び出し
        /// </summary>
        /// <param name="propertyName">Changedイベントを発生させたいプロパティ名</param>
        /// <param name="stackFrameIndex">呼び出し元StackFrame</param>
        protected override void CallPropertyChanged(string propertyName = "", int stackFrameIndex = 1)
        {

            // 引数指定のプロパティのChangedイベントを発生
            base.CallPropertyChanged(propertyName, stackFrameIndex);

            // 編集FLGの更新
            // 編集FLGプロパティ更新時は除外
            // ThrowEditEventNameにて指定されたプロパティ更新時は除外
            if (!propertyName.Equals(nameof(IsEdited))
                && !(propertyName.Length >= ThrowEditEventName.Length
                && propertyName.Substring(0, ThrowEditEventName.Length).ToUpper().Equals(ThrowEditEventName.ToUpper())))
            {
                IsEdited = true;
            }

        }

        /// <summary>
        /// 編集FLGリセット
        /// </summary>
        protected void ResetEditFlg()
        {
            IsEdited = false;
        }

    }

}
