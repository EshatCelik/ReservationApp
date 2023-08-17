using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Reservation.Api.Controllers;
using Reservation.Api.ErrorDetails;
using Reservation.BLL.Abstract;
using Reservation.BLL.Concreate;
using Reservation.Core.Entity;
using Reservation.Core.Utilities;
using Reservation.NotificationService;
using Reservation.Shared.Dto.Reservation;
using Reservation.Shared.Dto.Response;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Reservation.Test
{
    public class ReservationTest
    {

        private Mock<IReservationBusiness> _mockReservationBusiness;
        private Mock<ITableBusiness> _mockTableBusiness;
        private Mock<IMailService> _mockMailService;
        private IMapper _mapper;

        private ReservationController _reservationController;
        public ReservationTest()
        {
            _mockReservationBusiness = new Mock<IReservationBusiness>();
            _mockTableBusiness = new Mock<ITableBusiness>();
            _mockMailService = new Mock<IMailService>();
            _mapper = new MapperConfiguration(x => x.AddProfile<AutoMapping>()).CreateMapper();
            _reservationController = new ReservationController(_mockReservationBusiness.Object, _mapper, _mockTableBusiness.Object, _mockMailService.Object);

        }

        [Fact]
        public async void MakeReservation_ReservationIsSuccess_IfTableNumberAvailable()
        {
            //Arrange
            var reservation = new ReservationCreateDto()
            {
                TableNumber = 1,
                CustomerName = "Test",
                NumberOfGuests = 1,
                ReservationDate = DateTime.Now,
                CustomerEmail = "test@gmail.com"
            };

            var table = new Table()
            {
                Number = 1,
            };

            // Act
            _mockTableBusiness.Setup(x => x.IsTableAvailable(reservation.TableNumber)).ReturnsAsync(ResponseDto<bool>.Succes(200));
            _mockReservationBusiness.Setup(x => x.Create(It.IsAny<Core.Entity.Reservation>())).ReturnsAsync(ResponseDto<Core.Entity.Reservation>.Succes(new Core.Entity.Reservation() { TableNumber = table.Number },200));

            var result = await _reservationController.MakeReservation(reservation);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

            var returnedData = okResult.Value as ResponseDto<Core.Entity.Reservation>;
            Assert.NotNull(returnedData);
            Assert.Equal(table.Number, returnedData.Data.TableNumber);
        }
        [Fact]
        public async void MakeReservation_ExeptedAError_IfReservationNotCreated()
        {
            //Arrange
            var reservation = new ReservationCreateDto()
            {
                TableNumber = 1,
                CustomerName = "Test",
                NumberOfGuests = 1,
                ReservationDate = DateTime.Now,
                CustomerEmail = "test@gmail.com"
            };

            var table = new Table()
            {
                Number = 1,
            };

            // Act
            _mockTableBusiness.Setup(x => x.IsTableAvailable(reservation.TableNumber)).ReturnsAsync(ResponseDto<bool>.Succes(200));
            _mockReservationBusiness.Setup(x => x.Create(It.IsAny<Core.Entity.Reservation>())).ReturnsAsync(() =>
            {
                return null;
            });

            var result = await _reservationController.MakeReservation(reservation);

            // Assert
            var okResult = result as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(400, okResult.StatusCode);

            var returnedData = okResult.Value as ResponseDto<Core.Entity.Reservation>;
            Assert.Equal(null,returnedData);
        }

        [Fact]
        public async void MakeReservation_ReservationDtoModelIsNotValid_ReturnBadRequest()
        {
            //Arrange
            var reservation = new ReservationCreateDto()
            {
                //TableNumber = 1,
                //CustomerName = "Test",           iki property i göndermedik 400 almayý bekliyoruz
                NumberOfGuests = 1,
                ReservationDate = DateTime.Now,
                CustomerEmail = "test@gmail.com"
            };

            var result = await _reservationController.MakeReservation(reservation);

            // Assert
            var okResult = result as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(400, okResult.StatusCode);

            var returnedData = okResult.Value as ResponseDto<Core.Entity.Reservation>;
            Assert.Equal(null,returnedData );
        }
    }
}
