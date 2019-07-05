using System;

namespace AYam.Common.Platform
{

    /// <summary>
    /// 言語選択クラス
    /// </summary>
    public class PlatformCulture
    {

        /// <summary>
        /// 言語
        /// </summary>
        public string PlatformString { get; private set; }

        /// <summary>
        /// 言語コード
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// ローカルコード
        /// </summary>
        public string LocalCode { get; private set; }

        /// <summary>
        /// 言語選択クラス
        /// </summary>
        /// <param name="platformCultureString">指定言語</param>
        public PlatformCulture(string platformCultureString)
        {

            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException(nameof(platformCultureString));
            }

            PlatformString = platformCultureString.Replace('_', '-');
            int index = PlatformString.IndexOf("-", StringComparison.Ordinal);

            if (index > 0)
            {

                string[] values = PlatformString.Split('-');
                LanguageCode = values[0];
                LocalCode = values[1];

            }
            else
            {

                LanguageCode = PlatformString;
                LocalCode = "";

            }

        }

        /// <summary>
        /// 文字列へ変換
        /// </summary>
        public override string ToString()
        {
            return PlatformString;
        }

    }

}
