using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Interfaces;
using XF_FreeDiving.Service.Interfaces;

namespace XF_FreeDiving.Service.Impements
{
    /// <summary>
    /// DivingLogService
    /// </summary>
    /// <seealso cref="XF_FreeDiving.Service.Interfaces.IDivingLogService" />
    public class DivingLogService : IDivingLogService
    {
        private readonly IDataStore<DivingLog> _divingLogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivingLogService"/> class.
        /// </summary>
        /// <param name="divingLogRepository">The data store.</param>
        public DivingLogService(IDataStore<DivingLog> divingLogRepository)
        {
            _divingLogRepository = divingLogRepository;
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> InsertAsync(DivingLog item)
        {
            return await _divingLogRepository.InsertAsync(item);
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> UpdateItemAsync(DivingLog item)
        {
            return await _divingLogRepository.UpdateItemAsync(item);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> DeleteItemAsync(Guid id)
        {
            return await _divingLogRepository.DeleteItemAsync(id);
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DivingLog> GetByIdAsync(Guid id)
        {
            return await _divingLogRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public async Task<List<DivingLog>> GetAllAsync()
        {
            return await _divingLogRepository.GetAllAsync();
        }

        /// <summary>
        /// 取得圖表資訊
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<LineChart> GetChartData()
        {
            Random r = new Random((int)DateTime.Now.Ticks);

            var divingLogs = await _divingLogRepository.GetAllAsync();

            //填值
            var chartSeries = new List<ChartSerie>();

            var userDivingLogs = divingLogs.FindAll(x => x.name == "Woody");

            var chartEntries = new List<ChartEntry>();

            for (int i = 0; i < userDivingLogs.Count; i++)
            {
                chartEntries.Add(new ChartEntry((int)userDivingLogs[i].time.TotalSeconds)
                {
                    ValueLabel = ((int)userDivingLogs[i].time.TotalSeconds).ToString(),
                    Label = i.ToString(),
                });
            }

            chartSeries.Add(new ChartSerie()
            {
                Name = "Woody",
                Color = SKColor.Parse("#2c3e50"),
                Entries = chartEntries,
            });

            //分開存到 ChartEntry 中

            var lineChartData = new LineChart()
            {
                Entries = chartEntries,
                LabelTextSize = 42,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                BackgroundColor = SKColor.Parse("#409BD1"),
                Margin = 40

                //LabelOrientation = Orientation.Horizontal,
                //ValueLabelOrientation = Orientation.Horizontal,
                //LabelTextSize = 42,
                //ValueLabelTextSize = 30,
                //SerieLabelTextSize = 50,
                //LineAreaAlpha = 10,
                //ShowYAxisLines = true,
                //ShowYAxisText = true,
                //YAxisPosition = Position.Left,
                //BackgroundColor = SKColor.Parse("#409BD1"),
                //Series = chartSeries
            };

            return lineChartData;
        }

        /// <summary>
        /// 亂數產生
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="labelNumber">The label number.</param>
        /// <param name="withLabel">if set to <c>true</c> [with label].</param>
        /// <returns></returns>
        private static IEnumerable<ChartEntry> GenerateSeriesEntry(Random r, int labelNumber = 3, bool withLabel = true)
        {
            List<ChartEntry> entries = new List<ChartEntry>();

            int label = 2020 - ((labelNumber - 1) * 5);
            var value = r.Next(0, 700);
            do
            {
                entries.Add(new ChartEntry(value)
                {
                    ValueLabel = value.ToString(),
                    Label = withLabel ? label.ToString() : null
                });
                value = r.Next(0, 700);
                label += 5;
            }
            while (label <= 2020);

            return entries;
        }
    }
}