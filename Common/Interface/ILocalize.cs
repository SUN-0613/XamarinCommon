using System.Globalization;

namespace AYam.Common.Interface
{

    /// <summary>
    /// 多言語化
    /// </summary>
    public interface ILocalize
    {

        /// <summary>
        /// 選択言語情報の取得
        /// </summary>
        /// <returns></returns>
        CultureInfo GetCurrentCultureInfo();
        
        /// <summary>
        /// 言語セット
        /// </summary>
        /// <param name="cl"></param>
        void SetLocal(CultureInfo cl);

    }

}
