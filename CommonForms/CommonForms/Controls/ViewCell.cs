using Xamarin.Forms;

namespace AYam.Common.Forms.Controls
{

    /// <summary>
    /// ViewCellカスタマイズ
    /// </summary>
    public class ViewCell : Xamarin.Forms.ViewCell
    {

        /// <summary>
        /// 選択行の背景色プロパティ
        /// </summary>
        public static readonly BindableProperty SelectedBackgroundColorProperty
            = BindableProperty.Create(nameof(SelectedBackgroundColor)
                                    , typeof(Color)
                                    , typeof(ViewCell)
                                    , Color.Default);

        /// <summary>
        /// 選択行の背景色
        /// </summary>
        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

    }

}
