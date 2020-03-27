using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class HeaderTransactionController : ControllerBase
    {
        public IConfiguration _configuration;
        public HeaderTransactionController(IConfiguration Configuration)
        {
            this._configuration = Configuration;
        }
        [HttpGet]
        public ObjectResult Get()
        {
            try

            {
   

                List<HeaderTransaction> headerTransaction = new HeaderTransactionService(this._configuration).GetListWithDetail().ToList();
               
                return new ObjectResult(new MessageReturn<List<HeaderTransaction>>(TypeReturn.SUCCESS, $"Operação realizada com sucesso.", headerTransaction));
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