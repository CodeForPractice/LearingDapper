using System.Configuration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2017/1/10 10:00:36
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2017 . All rights reserved.
*/

namespace DapperLearing.Repository
{
    public class BaseRepository
    {
        public static ConnectionStringSettings testDataConn = ConfigurationManager.ConnectionStrings["TestData"];

        /// <summary>
        /// 获取测试连接
        /// </summary>
        /// <returns></returns>
        public string GetTestDataConn()
        {
            if (testDataConn != null)
            {
                return testDataConn.ToString();
            }
            return string.Empty;
        }
    }
}