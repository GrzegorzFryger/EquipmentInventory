using System.Threading.Tasks;
using AutoMapper;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquipmentInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly EquipmentRepository _repository;
        private readonly ILogger _logger;

        public ValuesController(EquipmentRepository repository, ILogger<ValuesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        // GET api/values
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"fetching data ");

            return "it's work ";

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
