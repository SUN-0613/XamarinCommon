namespace AYam.Common.Interface
{

    /// <summary>
    /// ローカル通知
    /// DependencyServiceにて利用
    /// </summary>
    /// <remarks>
    /// 参考URL
    /// https://itblogdsi.blog.fc2.com/blog-entry-185.html
    /// </remarks>
    public interface INotificationService
    {

        /// <summary>
        /// 通知許可の申請
        /// </summary>
        void Allow();

        /// <summary>
        /// 通知表示
        /// </summary>
        /// <param name="title">主題</param>
        /// <param name="subTitle">副題</param>
        /// <param name="message">表示内容</param>
        /// <param name="sec">表示時間(秒)</param>
        /// <param name="isRepeat">繰り返し表示</param>
        /// <param name="isUseBadge">バッジの数字更新</param>
        void Show(string title, string subTitle, string message, int sec = 1, bool isRepeat = false, bool isUseBadge = true);

        /// <summary>
        /// 通知解除
        /// </summary>
        void Release();

    }

}
