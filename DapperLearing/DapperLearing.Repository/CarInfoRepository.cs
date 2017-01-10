using Dapper;
using DapperLearing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2017/1/10 10:02:17
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2017 . All rights reserved.
*/

namespace DapperLearing.Repository
{
    public sealed class CarInfoRepository : BaseRepository
    {
        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddCarInfo(CarInfo info)
        {
            string sql = string.Format("INSERT INTO {0}(CarName,CarFactory,SaleStatus,AddTime,UpdateTime) VALUES(@CarName,@CarFactory,@SaleStatus,@AddTime,@UpdateTime) select cast(scope_identity() as int);", CarInfo.TableName);
            using (SqlConnection conn = new SqlConnection(GetTestDataConn()))
            {
                conn.Open();
                int keyId = conn.ExecuteScalar<int>(sql, info, null, null, null);
                conn.Close();
                info.Id = keyId;
                return keyId > 0;
            }
        }

        public CarInfo Get(int key)
        {
            string sql = string.Format("SELECT * FROM {0} where Id=@Id", CarInfo.TableName);
            using (SqlConnection conn = new SqlConnection(GetTestDataConn()))
            {
                conn.Open();
                CarInfo info = conn.QueryFirstOrDefault<CarInfo>(sql, new { Id = key }, null, null);
                conn.Close();
                return info;
            }
        }

        public bool UpdateCarInfo(CarInfo info)
        {
            string sql = string.Format("UPDATE {0} SET CarName=@CarName,SaleStatus=@SaleStatus WHERE Id=@Id;", CarInfo.TableName);
            using (SqlConnection conn = new SqlConnection(GetTestDataConn()))
            {
                conn.Open();
                int count = conn.Execute(sql, info, null, null, null);
                conn.Close();
                return count > 0;
            }
        }

        public IEnumerable<CarInfo> GetList()
        {
            string sql = string.Format("SELECT * FROM {0} A LEFT JOIN {1} B ON A.Id=B.CarId;", CarInfo.TableName, CarInfoEntry.TableName);
            using (IDbConnection conn = new SqlConnection(GetTestDataConn()))
            {
                conn.Open();
                var lookUp = new Dictionary<int, CarInfo>();
                var result = conn.Query<CarInfo, CarInfoEntry, CarInfo>(sql, (carInfo, entry) =>
                {
                    CarInfo model;
                    if (!lookUp.TryGetValue(carInfo.Id, out model))
                    {
                        lookUp.Add(carInfo.Id, model = carInfo);
                    }
                    if (model.PicList == null)
                    {
                        model.PicList = new List<CarInfoEntry>();
                    }
                    if (entry != null)
                    {
                        model.PicList.Add(entry);
                    }
                    return carInfo;
                }, null, null, true, splitOn: "Id");
                conn.Close();
                return lookUp.Values;
            }
        }

        public bool Add(CarInfo info)
        {
            string sqlCarInfo = string.Format("INSERT INTO {0}(CarName,CarFactory,SaleStatus,AddTime,UpdateTime) VALUES(@CarName,@CarFactory,@SaleStatus,@AddTime,@UpdateTime) select cast(scope_identity() as int);", CarInfo.TableName);
            string sqlCarInfoEntry = string.Format("INSERT INTO {0}(CarId,PicUrl,Title,IsDeleted) VALUES(@CarId,@PicUrl,@Title,@IsDeleted) select cast(scope_identity() as int);", CarInfoEntry.TableName);
            using (IDbConnection conn = new SqlConnection(GetTestDataConn()))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        int keyId = conn.ExecuteScalar<int>(sqlCarInfo, info, tran, null, null);
                        info.Id = keyId;
                        if (info.PicList != null && info.PicList.Any())
                        {
                            info.PicList.ForEach(pic =>
                            {
                                pic.CarId = keyId;
                            });
                            conn.Execute(sqlCarInfoEntry, info.PicList, tran, null, null);
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
            }
        }
    }
}