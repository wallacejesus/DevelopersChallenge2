using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Configuration;
using NIBO.Challenge.Domain.Entity;
using NIBO.Challenge.Domain.Enums;
using NIBO.Challenge.Infra.DataBaseContext;
using NIBO.Challenge.Infra.Repository;
using System.Linq;
using NIBO.Challenge.Infra.Exceptions;

namespace NIBO.Challenge.Service.Service
{
    public class HeaderTransactionService : Service<HeaderTransaction>
    {
        public IConfiguration _configuration;
        public HeaderTransactionService(IConfiguration Configuration,SqlServerContext Context=null) :base(Configuration, Context)
        {
            this._configuration = Configuration;
        }
        public void Import(List<string> listXmlDocument)
        {
            repository.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            
            try
            {
                foreach (string xmlString in listXmlDocument)
                {
                    var xml = new XmlDocument();
                    xml.LoadXml(xmlString);
                    SaveXmlInDataBase(xml);
                    xml.DocumentElement.ParentNode.RemoveAll();
                }
                repository.Commit();
            }
            catch(Exception ex)
            {
                repository.Rollback();
                throw;
            }

        }
        private void SaveXmlInDataBase(XmlDocument xml)
        {
            int indexDateEnd = xml.GetElementsByTagName("DTPOSTED").Count - 1;
            HeaderTransaction headerTransaction = new HeaderTransaction()
            {
                DateStart = DateTime.ParseExact(xml.GetElementsByTagName("DTPOSTED").Item(0).InnerText.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                DateEnd = DateTime.ParseExact(xml.GetElementsByTagName("DTPOSTED").Item(indexDateEnd).InnerText.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture)
            };
            if (GetList(new { DateStart = headerTransaction.DateStart, DateEnd = headerTransaction.DateEnd }).Any())
                throw new HeaderTransactionException("O período informado já foi importado.");

            headerTransaction.IdHeader = Insert(headerTransaction).Value;
            List<HeaderTransaction> h = new List<HeaderTransaction>();



            XmlNodeList nodelist = xml.GetElementsByTagName("STMTTRN");
            foreach (XmlNode node in nodelist)
            {


                DetailTransaction detailTransaction = new DetailTransaction()
                {
                    Type = (node.ChildNodes.Item(0).InnerText.Equals("DEBIT") ? TransactionType.DEBIT : TransactionType.CREDIT),
                    Date = DateTime.ParseExact(node.ChildNodes.Item(1).InnerText.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                    Value = Convert.ToDecimal(node.ChildNodes.Item(2).InnerText) / 100,
                    Detail = node.ChildNodes.Item(3).InnerText,
                    IdHeader = headerTransaction.IdHeader
                };

                DetailTransactionService detailTransactionService = new DetailTransactionService(this._configuration, repository._context);

                bool ExistsTransaction = detailTransactionService.GetList(
                new
                {
                    Date = detailTransaction.Date,
                    Type = detailTransaction.Type,
                    Value = detailTransaction.Value,
                    Detail = detailTransaction.Detail
                })
                .Any(x => x.IdHeader != headerTransaction.IdHeader);

                if (!ExistsTransaction)
                    detailTransactionService.Insert(detailTransaction);

            }
        }

        public IEnumerable<HeaderTransaction> GetListWithDetail(object @where=null)
        {
            IEnumerable<HeaderTransaction> listHeaderTransactions = GetList(@where);

            foreach(HeaderTransaction headerTransaction in listHeaderTransactions)
            {
                listHeaderTransactions
                .Where(x => x.IdHeader == headerTransaction.IdHeader)
                .First().ListDetailsTransaction = new DetailTransactionService(this._configuration)
                                                      .GetList(new { IdHeader = headerTransaction.IdHeader}).ToList();
            }

            return listHeaderTransactions;

        }
    }
}
