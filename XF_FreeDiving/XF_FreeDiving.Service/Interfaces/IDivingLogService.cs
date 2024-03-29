﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using XF_FreeDiving.Repository.Entities;

namespace XF_FreeDiving.Service.Interfaces
{
    public interface IDivingLogService
    {
        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> InsertAsync(DivingLog item);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(DivingLog item);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(Guid id);

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<DivingLog> GetByIdAsync(Guid id);

        /// <summary>
        /// 取得使用者前一筆執行時間
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<DivingLog> GetUserLastDateAsync(string name);

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        Task<List<DivingLog>> GetAllAsync();

        /// <summary>
        /// 取得圖表資訊
        /// </summary>
        /// <param name="name"></param>
        Task<LineChart> GetChartData(string name = null);
    }
}