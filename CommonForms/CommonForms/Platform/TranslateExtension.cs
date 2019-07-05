using AYam.Common.Interface;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AYam.Common.Forms.Platform
{

    /// <summary>
    /// XAMLから言語設定呼出
    /// </summary>
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {

        /// <summary>
        /// リソースファイル
        /// </summary>
        private readonly string _ResourceFile = "DrugManagement.Resx.Resources";

        /// <summary>
        /// 言語情報
        /// </summary>
        private readonly CultureInfo _CultureInfo;

        /// <summary>
        /// テキスト
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// XAMLから言語設定呼出
        /// </summary>
        /// <param name="resourceFile">リソースファイル</param>
        public TranslateExtension(string resourceFile)
        {

            _ResourceFile = resourceFile;

            switch (Device.RuntimePlatform)
            {

                case Device.iOS:
                case Device.Android:
                    _CultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                    break;

                default:
                    break;

            }

        }

        /// <summary>
        /// リソースファイルよりテキスト取得
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider provider)
        {

            if (Text != null)
            {

                var resource = new ResourceManager(_ResourceFile, typeof(TranslateExtension).GetTypeInfo().Assembly);
                var translation = resource.GetString(Text, _CultureInfo);

                if (translation == null)
                {
#if DEBUG
                    throw new ArgumentException(string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'", Text, _ResourceFile, _CultureInfo.Name), nameof(Text));
#else
                    translation = Text;
#endif
                }

                return translation;

            }
            else
            {
                return "";
            }

        }

    }
}
