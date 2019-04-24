using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using EquipmentInventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquipmentInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly EquipmentService _equipmentService;
        private readonly ILogger _logger;

        public ValuesController( ILogger<ValuesController> logger, EquipmentService equipmentService)
        {
            _logger = logger;
            _equipmentService = equipmentService;
        }


        // GET api/values
        [HttpGet]
        public Task<IEnumerable<EquipmentDto>> Get()
        {
            _logger.LogInformation($"fetching data ");




            return _equipmentService.GetListEquipmentByType(TypeEquipment.Notebook);

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
