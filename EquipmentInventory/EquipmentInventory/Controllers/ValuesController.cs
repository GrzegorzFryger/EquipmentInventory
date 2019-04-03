using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EquipmentInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly InventoryEquipmentContext _context;

        public ValuesController(InventoryEquipmentContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<User> Get()
        {
            
           
            return _context.Users.Include(u => u.Localization)
                .ThenInclude(r => r.Users)
                .Single();
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
