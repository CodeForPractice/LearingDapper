using System;
using System.Collections.Generic;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2017/1/10 9:59:49
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2017 . All rights reserved.
*/

namespace DapperLearing.Models
{
    /// <summary>
    /// 车辆信息
    /// </summary>
    public sealed class CarInfo
    {
        /// <summary>
        /// 车辆信息
        /// </summary>
        public const string TableName = "T_CarInfo";

        /// <summary>
        /// 车辆Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 车辆名字
        /// </summary>
        public string CarName { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public string CarFactory { get; set; }

        /// <summary>
        /// 销售状态
        /// </summary>
        public SaleStatusType? SaleStatus { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        public List<CarInfoEntry> PicList { get; set; }
    }
}