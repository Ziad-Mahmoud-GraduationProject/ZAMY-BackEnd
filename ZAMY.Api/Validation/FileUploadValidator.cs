using FluentValidation;
namespace ZAMY.Api.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FileUploadValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,ValidationContext validationContext)
        {
            if (value == null) 
                return new ValidationResult($"No file uploaded");

            else if (!IsImageFile((IFormFile)value))
                return new ValidationResult($"Invalid file format. Please upload an image file.");

            else return ValidationResult.Success;
        }
      
        private bool IsImageFile(IFormFile file)
        {
            if (file.ContentType.ToLower() != "image/jpeg" && file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            var supportedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            return supportedExtensions.Contains(fileExtension);
        }
    }
}