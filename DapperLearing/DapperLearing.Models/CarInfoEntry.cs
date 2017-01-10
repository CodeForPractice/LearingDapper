/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2017/1/10 9:59:02
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2017 . All rights reserved.
*/

namespace DapperLearing.Models
{
    public sealed class CarInfoEntry
    {
        /// <summary>
        /// 表名
        /// </summary>
        public const string TableName = "T_CarInfoEntry";

        /// <summary>
        /// 图片Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 车辆Id
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}