using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.BLL.Abstract;
using Reservation.Core.Entity;
using Reservation.Shared.Dto.Table;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableBusiness _tableBusiness;
        private readonly IMapper _mapper;

        public TableController(ITableBusiness tableBusiness, IMapper mapper)
        {
            _tableBusiness = tableBusiness;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create(TableCreateDto createTable)
        {
            return Ok(await _tableBusiness.Create(_mapper.Map<Table>(createTable)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<Table>(await _tableBusiness.Get(id)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            if (_tableBusiness.IsTableAvailable(id).Result.IsSuccessful)
            {
                return BadRequest("Masa kullanılıyor silinemez");
            }
            return Ok(_mapper.Map<Table>(await _tableBusiness.Delete(id))); 
        }

    }
}
