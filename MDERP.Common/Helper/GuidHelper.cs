using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Common.Helper
{
    public class GuidHelper
    {
        /// <summary>
        /// 无横杠分隔
        /// Ex：e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <returns></returns>
        public static string GetGuidN()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 有横杠分隔
        /// Ex：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
        /// </summary>
        /// <returns></returns>
        public static string GetGuidD()
        {
            return Guid.NewGuid().ToString("D");
        }

        /// <summary>
        /// 有分隔，带大括号
        /// Ex：{734fd453-a4f8-4c5d-9c98-3fe2d7079760}
        /// </summary>
        /// <returns></returns>
        public static string GetGuidB()
        {
            return Guid.NewGuid().ToString("B");
        }

        /// <summary>
        /// 有间隔，有小括号
        /// Ex： (ade24d16-db0f-40af-8794-1e08e2040df3)
        /// </summary>
        /// <returns></returns>
        public static string GetGuidP()
        {
            return Guid.NewGuid().ToString("P");
        }

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= b + 1;
            }

            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
