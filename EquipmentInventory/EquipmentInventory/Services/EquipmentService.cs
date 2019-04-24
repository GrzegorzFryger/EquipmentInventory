using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using EquipmentInventory.Repository;

namespace EquipmentInventory.Services
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper; 
        

        public EquipmentService(EquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
            _mapper = mapper;
        }
        
        public EquipmentCountDto GetCountEquipment(TypeEquipment typeEquipment)
        {
            var resp = _equipmentRepository.GetCountEquipment(e => e.TypeEquioment == typeEquipment);

            if (resp != 0)
            {
                return new EquipmentCountDto(
                            typeEquipment.ToString(),
                        _equipmentRepository
                            .GetCountEquipment(e => e.TypeEquioment == typeEquipment && e.Available),
                        resp
                    );
            }

            return null; 
        }

        public async Task <IEnumerable<EquipmentDto>> GetListEquipmentByType(TypeEquipment typeEquipment)
        {

            return await _mapper
                .ProjectToAsync<IEnumerable<Equipment>,IEnumerable<EquipmentDto>>(_equipmentRepository
                    .GetEagerListEquipmentByType(typeEquipment));

        }
        
        
        public  IEnumerable<EquipmentDto> GetListEquipmentByType2(TypeEquipment typeEquipment)
        {

            return _mapper.Map<IEnumerable<EquipmentDto>>(_equipmentRepository
                .GetEagerListEquipmentByType(typeEquipment).Result);
        }
    }
}