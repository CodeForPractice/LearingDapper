using DapperLearing.Models;
using DapperLearing.Repository;
using System;

namespace DapperLearing.First
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarInfoRepository carInfoRepository = new CarInfoRepository();

            //#region 单个操作

            //CarInfo info = new CarInfo()
            //{
            //    AddTime = DateTime.Now,
            //    CarFactory = "备胎",
            //    CarName = "备胎好车",
            //    SaleStatus = SaleStatusType.OnSale
            //};
            //if (carInfoRepository.AddCarInfo(info))
            //{
            //    Console.WriteLine("车辆添加成功");
            //    Console.WriteLine(info.Id.ToString());
            //    var selectInfo = carInfoRepository.Get(info.Id);
            //    if (selectInfo != null)
            //    {
            //        selectInfo.SaleStatus = SaleStatusType.Deleted;
            //        selectInfo.CarName = "一手车";
            //        carInfoRepository.UpdateCarInfo(selectInfo);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("车辆添加失败");
            //}

            //#endregion 单个操作

            //#region 多个事务操作

            //CarInfo infoNew = new CarInfo()
            //{
            //    AddTime = DateTime.Now,
            //    CarFactory = "备胎",
            //    CarName = "备胎好车",
            //    SaleStatus = SaleStatusType.OnSale,
            //    PicList = new System.Collections.Generic.List<CarInfoEntry>() {
            //        new CarInfoEntry() { IsDeleted=false, PicUrl="http:..www.baidu.com", Title="百度" },
            //        new CarInfoEntry() { IsDeleted=false, PicUrl="http:..www.google.com", Title="谷歌" }
            //    }
            //};
            //var result = carInfoRepository.Add(infoNew);
            //Console.WriteLine(result.ToString());

            //#endregion 多个事务操作

            var result = carInfoRepository.GetList();

            foreach (var item in result)
            {
                //Console.WriteLine(item.CarName + "图片个数：" + item.PicList?.Count.ToString());
                int imageCount = 0;
                if (item.PicList != null)
                {
                    imageCount = item.PicList.Count;
                }
                Console.WriteLine(item.CarName + "图片个数：" + imageCount.ToString());
            }

            Console.Read();
        }
    }
}