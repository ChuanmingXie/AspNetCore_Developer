/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Common
*项目描述:
*类 名 称:Utility
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/4 18:14:17
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/

using System;

namespace AspNetCore_RazorPages_EFCodeFirst.Common
{
    public static class Utility
    {
        public static string GetChars(byte[] token)
        {
            return token[7].ToString();
        }

        public static string GetChars(Guid token)
        {
            //return token.ToString().Substring(token.ToString().Length - 3);
            return token.ToString()[^3..];
        }
    }
}
