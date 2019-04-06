using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using EquipmentInventory.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public Task<User> Get()
        {
            _logger.LogInformation($"fetching data ");

            return ad.FindByIdAsync(2); 
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
