using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NIBO.Challenge.Domain.Entity;
using NIBO.Challenge.Infra.Helpers;
using NIBO.Challenge.Service.Service;

namespace NIBO.Challenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailTransactionController : ControllerBase
    {
        public IConfiguration _configuration;
        public DetailTransactionController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet]
        public ObjectResult Get()
        {
            try

            {

                DetailTransactionService detailTransactionService = new DetailTransactionService(this._configuration);
                List<DetailTransaction> detailTransactions = detailTransactionService.GetList().ToList();

                return new ObjectResult(new MessageReturn<List<DetailTransaction>>(TypeReturn.SUCCESS, $"Operação realizada com sucesso.", detailTransactions));
            }
            catch (Infra.Exceptions.HeaderTransactionException ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.WARNING, $"{ex.Message}"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.ERROR, $"Erro ao importar o arquivo OFX. Erro:{ex.Message}"));
            }
        }
        
        [HttpPost]
        public ObjectResult Post()
        {
            try

            {

                
                DetailTransactionService detailTransactionService = new DetailTransactionService(this._configuration);
                string fileToDownload = detailTransactionService.createExcellFile();
                return new ObjectResult(new MessageReturn<string>(TypeReturn.SUCCESS, $"Operação realizada com sucesso.", fileToDownload));
            }
            catch (Infra.Exceptions.HeaderTransactionException ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.WARNING, $"{ex.Message}"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.ERROR, $"Erro ao importar o arquivo OFX. Erro:{ex.Message}"));
            }
        }
    }
}