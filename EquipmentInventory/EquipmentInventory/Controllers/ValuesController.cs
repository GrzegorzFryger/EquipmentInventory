using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static EquipmentInventory.Repository.SpecificationBuilder;

namespace EquipmentInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IGenericRepository<User, InventoryEquipmentContext> ad;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ValuesController(InventoryEquipmentContext context, IMapper mapper, ILogger<ValuesController> logger)
        {

           
            
             ad = new GenericRepository<User,InventoryEquipmentContext>(context);
             
            
           
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"fetching data ");


            return "it is work";


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
