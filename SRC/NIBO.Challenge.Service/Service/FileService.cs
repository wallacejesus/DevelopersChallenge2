using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;
using NIBO.Challenge.Infra.DataBaseContext;
using System.ComponentModel;
using GemBox.Spreadsheet;

namespace NIBO.Challenge.Service.Service
{
    public class FileService:Service<Domain.Entity.File>
    {
        public IConfiguration _configuration;
        public FileService(IConfiguration Configuration, SqlServerContext Context=null) : base(Configuration, Context)
        {
            this._configuration = Configuration;

        }
        public List<string>ConvertOfxToXmlString(IFormFileCollection OfxFile)
        {
            string XmlString = string.Empty;
            List<string> listXmlDocument = new List<string>();
            foreach (var formFileCollection in OfxFile)
            {
                if (formFileCollection.Length > 0)
                {          
                    StreamReader streamReader = new StreamReader(formFileCollection.OpenReadStream());
                    string line;

                    while((line = streamReader.ReadLine()) != null)
                    {
              
                        if (new Regex("<[^>]+[A-Z]+>").IsMatch(line))
                        {
                            string endTag="";
                            if (new Regex("<[^>]+[A-Z]+>+.+").IsMatch(line))
                                endTag = new Regex("<[^>]+[A-Z]+>").Match(line).Value.Replace("<","</");
                            XmlString += line.ToString()+endTag;
                        }
                    }
                    //XmlDocument xmlDocument = new XmlDocument();
                    //xmlDocument.LoadXml(XmlString);
                    listXmlDocument.Add(XmlString);
                    //xmlDocument = null;
                }

            }
            
            
            return listXmlDocument;
        }
        public void ConvertListToExcel<TEntity>(List<TEntity> list,string excelFilePath,string sheetName)
        {

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TEntity));
            ExcelFile excelFile = new ExcelFile();
            ExcelWorksheet sheet = excelFile.Worksheets.Add(sheetName);

            for (int i = 0; i < properties.Count; i++)
                sheet.Cells[0, i].Value = properties[i].Name;

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < properties.Count; j++)
                    sheet.Cells[i + 1, j].Value = properties[j].GetValue(list[i]);
            excelFile.Save(excelFilePath);
        }
  
        
    }
}
