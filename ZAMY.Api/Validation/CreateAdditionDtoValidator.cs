public class CreateAdditionDtoValidator : AbstractValidator<CreateAdditionDto>
{
    public CreateAdditionDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(dto => dto.MealId)
            .NotEmpty().WithMessage("MealId is required.");

        RuleFor(dto => dto.Img)
            .NotNull().WithMessage("Image is required.")
            .Must(BeAValidImage).WithMessage("Invalid image format. Please upload an image file.");
    }

    private bool BeAValidImage(IFormFile img)
    {
        if (img == null || img.Length == 0)
        {
            return false;
        }

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = System.IO.Path.GetExtension(img.FileName).ToLower();
        return allowedExtensions.Contains(fileExtension);
    }
}
