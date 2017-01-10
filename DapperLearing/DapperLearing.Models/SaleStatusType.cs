/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2017/1/10 9:58:19
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2017 . All rights reserved.
*/

namespace DapperLearing.Models
{
    /// <summary>
    /// 销售状态
    /// </summary>
    public enum SaleStatusType : int
    {
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = 1,

        /// <summary>
        /// 在售
        /// </summary>
        OnSale = 2,

        /// <summary>
        /// 下架
        /// </summary>
        OffShevel = 3
    }
}