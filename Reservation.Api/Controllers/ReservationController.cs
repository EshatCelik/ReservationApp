using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Api.ErrorDetails;
using Reservation.Api.Validators;
using Reservation.BLL.Abstract;
using Reservation.NotificationService;
using Reservation.Shared.Dto.Notification;
using Reservation.Shared.Dto.Reservation;
using Reservation.Shared.Dto.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationBusiness _reservationBusiness;
        private readonly ITableBusiness _tableBusiness;
        private readonly IMailService _notificationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationBusiness reservationBusiness, IMapper mapper,
            ITableBusiness tableBusiness, IMailService notificationService)
        {
            _reservationBusiness = reservationBusiness;
            _mapper = mapper;
            _tableBusiness = tableBusiness;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation(ReservationCreateDto reservationCreateDto)
        {
            var validator = new ReservationCreateValidator();
            var validatorResult = validator.Validate(reservationCreateDto);
            if (!validatorResult.IsValid)
            {
                var errorResponse = new ErrorResponse();
                errorResponse.Errors.AddRange(validatorResult.Errors.Select(error => new ErrorDetail
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                }));
                return BadRequest(errorResponse);
            }
            var isTableAvailable = await _tableBusiness.IsTableAvailable(reservationCreateDto.TableNumber);
            if (!isTableAvailable.IsSuccessful)
            {
                var errorResponse = new ErrorResponse();
                errorResponse.Errors.Add(new ErrorDetail()
                {
                    Field = reservationCreateDto.TableNumber.ToString(),
                    Message = " Table number is not Available !!!"
                });
                return BadRequest(errorResponse);
            }
            var result = await _reservationBusiness.Create(_mapper.Map<Core.Entity.Reservation>(reservationCreateDto));
            if (result != null)
            {
                _notificationService.SendMail(new NotificationDto
                {
                    Message = $"{result.Data.CustomerEmail} created new reservation  !!!",
                    Source = $"{result.Data.Id} "
                });
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<ReservationCreateDto>(await _reservationBusiness.Get(id)));
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(_mapper.Map<ReservationCreateDto>(await _reservationBusiness.Delete(id)));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ReservationCreateDto>>(await _reservationBusiness.GetAll()));
        }
    }
}
