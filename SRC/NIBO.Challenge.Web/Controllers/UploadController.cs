using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NIBO.Challenge.Domain.Entity;
using NIBO.Challenge.Infra.Exceptions;
using NIBO.Challenge.Infra.Helpers;
using NIBO.Challenge.Service.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NIBO.Challenge.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UploadController: ControllerBase
    {
        private IConfiguration _configuration;
        public UploadController(IConfiguration Configuration) 
        {
            this._configuration = Configuration;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost, DisableRequestSizeLimit]
        public ObjectResult Post(List<IFormFile> files)
        {
            try
            {
                var file = Request.Form.Files;
                FileService fileService = new FileService(this._configuration);
                List<string> listXmlDocument = fileService.ConvertOfxToXmlString(file);
                HeaderTransactionService headerTransactionService = new HeaderTransactionService(this._configuration);
                headerTransactionService.Import(listXmlDocument);
                return new ObjectResult(new MessageReturn(TypeReturn.SUCCESS,"Operação relizada com sucesso!"));
            }
            catch(HeaderTransactionException ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.WARNING, $"{ex.Message}"));
            }
            catch (Exception ex)
            {
                return new ObjectResult(new MessageReturn(TypeReturn.ERROR, $"Erro ao importar o arquivo OFX. Erro:{ex.Message}"));
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
