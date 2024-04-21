namespace ZAMY.Api.Validation
{

    public class ChoiceRequestDtoValidator : AbstractValidator<ChoiceRequstDto>
    {
        public ChoiceRequestDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("IsActive must be specified.");

            RuleFor(dto => dto.MealId)
                .GreaterThan(0).WithMessage("MealId must be greater than 0.");
        }
    }

}
