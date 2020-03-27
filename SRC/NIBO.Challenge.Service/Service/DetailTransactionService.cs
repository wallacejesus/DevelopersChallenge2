using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using NIBO.Challenge.Domain.Entity;
using NIBO.Challenge.Infra.DataBaseContext;
using System.Linq;
using System.IO;
using GemBox.Spreadsheet;

namespace NIBO.Challenge.Service.Service
{
    public class DetailTransactionService: Service<DetailTransaction>
    {
        public IConfiguration _configuration;
        public DetailTransactionService(IConfiguration Configuration,SqlServerContext Context=null) : base(Configuration, Context)
        {
            this._configuration = Configuration;
        }
        public string createExcellFile()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            string randomNumber = new Random().Next(1, 1000).ToString();
            string fileName = $"ExcellFiles\\ExcelFille{DateTime.Now.ToString("yyyyMMddHHmmss")}{randomNumber.PadLeft(4,'0')}.xls";
            string excellPathFile = Path.Combine(Path.GetFullPath("wwwroot"),fileName);
            string sheetName = "Extrato";
            List<DetailTransaction> listDetailsTransaction = this.GetList().ToList();
            FileService fileService = new FileService(this._configuration);
            fileService.ConvertListToExcel<DetailTransaction>(listDetailsTransaction, excellPathFile, sheetName);
            return fileName;
        }
        
    }
}
