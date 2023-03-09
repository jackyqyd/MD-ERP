using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Common.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// JsonTextFormat
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static JObject JsonTextFormat(JObject jsonText)
        {
            JObject jObject = new JObject();
            foreach (var item in jsonText)
            {
                if (item.Value.GetType() == typeof(JObject))
                {
                    JObject jc = new JObject();
                    foreach (var ite in (JObject)item.Value)
                    {
                        jc.Add(new JProperty(StringHelper.ResolvePropertyName(ite.Key), ite.Value));
                    }
                    jObject.Add(new JProperty(StringHelper.ResolvePropertyName(item.Key), jc));
                }
                else
                {
                    jObject.Add(new JProperty(StringHelper.ResolvePropertyName(item.Key), item.Value));
                }
            }

            return jObject;
        }

        /// <summary>
        /// 处理Json字符串中属性名第一个字母转大写
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        public static string ResolvePropertyName(string name)
        {
            StringBuilder sb = new StringBuilder(name.Length);
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];

                if (i == 0 || name[i - 1] == '_')
                    c = char.ToUpper(c);

                if (c != '_')
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据分隔符返回前n条数据
        /// </summary>
        /// <param name="content">数据内容</param>
        /// <param name="separator">分隔符</param>
        /// <param name="top">前n条</param>
        /// <param name="isDesc">是否倒序（默认false）</param>
        /// <returns></returns>
        public static List<string> GetTopDataBySeparator(string content, string separator, int top, bool isDesc = false)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new List<string>() { };
            }

            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentException("message", nameof(separator));
            }

            var dataArray = content.Split(separator).Where(d => !string.IsNullOrEmpty(d)).ToArray();
            if (isDesc)
            {
                Array.Reverse(dataArray);
            }

            if (top > 0)
            {
                dataArray = dataArray.Take(top).ToArray();
            }

            return dataArray.ToList();
        }
    }
}
