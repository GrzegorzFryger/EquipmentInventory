using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using EquipmentInventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquipmentInventory.Controllers
{
    [Route("api/equipments")]
    public class EquipmentController : Controller
    {
        
        private readonly EquipmentService _equipmentService;
        private readonly ILogger _logger;

        public EquipmentController(EquipmentService equipmentService, ILogger<EquipmentController> logger)
        {
            _equipmentService = equipmentService ?? throw new ArgumentNullException(nameof(equipmentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [HttpGet]
        public Task<IEnumerable<EquipmentDto>> GetListEquipmentByType2()
        {
            _logger.LogInformation($"fetching data retriwe data :  " );
            _logger.LogInformation($"fetching data form Equipment Controller : GetListEquipmentByType ");

            return _equipmentService.GetListEquipmentByType(TypeEquipment.Notebook);

        }

        // GET: api/<controller>
        [HttpGet("{type}")]
        public Task<IEnumerable<EquipmentDto>> GetListEquipmentByType(TypeEquipment type)
        {
            _logger.LogInformation($"fetching data retrieve data :  " + type);
            _logger.LogInformation($"fetching data form Equipment Controller : GetListEquipmentByType ");
            
            

            return _equipmentService.GetListEquipmentByType(TypeEquipment.Notebook);

        }
        
        [HttpGet(("count/{type}"))]
        public EquipmentCountDto GetCountEquipmentByType(TypeEquipment type)
        {
            _logger.LogInformation($"fetching data form Equipment Controller : GetCountEquipmentByType ");

            return _equipmentService.GetCountEquipment(type);

        }

      

//        // POST api/<controller>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }
//
//        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }
//
//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }
}
