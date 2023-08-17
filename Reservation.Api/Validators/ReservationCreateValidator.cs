using FluentValidation;
using Reservation.Shared.Dto.Reservation;

namespace Reservation.Api.Validators
{
    public class ReservationCreateValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CustomerEmail).NotNull().WithMessage("{PropertyName} is required").EmailAddress().WithMessage("{PropertyName} is required");
            RuleFor(x => x.NumberOfGuests).NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1,10).WithMessage("Guest Number must be between 1 and 10 !");
            RuleFor(x=>x.TableNumber).NotNull().WithMessage("{PropertyName} is required").GreaterThanOrEqualTo(1).WithMessage("Table number must be bigger than zero !!");
            RuleFor(x => x.ReservationDate).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
