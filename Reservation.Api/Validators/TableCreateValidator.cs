using FluentValidation;
using Reservation.Shared.Dto.Table;

namespace Reservation.Api.Validators
{
    public class TableCreateValidator : AbstractValidator<TableCreateDto>
    {
        public TableCreateValidator()
        {
            RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .LessThanOrEqualTo(0).WithMessage("Table capacity must bigger than zero !!");

            RuleFor(x => x.Number).NotNull().NotEmpty().LessThanOrEqualTo(0).WithMessage("Table number must bigger than zero !!");
        }
    }
}
