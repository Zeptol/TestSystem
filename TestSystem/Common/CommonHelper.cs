using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace TestSystem.Common
{
    public static class CommonHelper
    {
        /// <summary>
        /// 获取md5
        /// </summary>
        /// <param name="str">需转的字符串</param>
        /// <returns></returns>
        public static string GetMd5(this string str)
        {
            try
            {
                var md5 = new MD5CryptoServiceProvider();
                var reStr = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "").ToLower();
                return reStr;
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5() failed,error:" + ex.Message);
            }
        }

        public static List<T> ToList<T>(this DataTable dt) where T : new()
        {
            //定义集合
            var ts = new List<T>();
            //定义一个临时变量
            //遍历dataTable中的数据行
            foreach (DataRow dr in dt.Rows)
            {
                var t = new T();
                //获得此模型的公共属性
                var props = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (var pi in props)
                {
                    var tempName = pi.Name;
                    //检查dataTable是否包含此列(列名==对象的属性名)
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值
                        var value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;

        }
        
    }
}
