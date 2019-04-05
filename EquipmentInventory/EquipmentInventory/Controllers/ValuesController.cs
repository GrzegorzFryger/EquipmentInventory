using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
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
        private readonly InventoryEquipmentContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ValuesController(InventoryEquipmentContext context, IMapper mapper, ILogger<ValuesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<UserDTO> Get()
        {
            _logger.LogInformation($"fetching data ");
            
            return _context.Users.Where(x => x.Id == 2).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).Single();
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
