using Microsoft.AspNetCore.Http;

public class FileHelper
{
    public static string UploadImageAsync(IFormFile img)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        var filePath = Path.Combine("wwwroot/Uploads", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            img.CopyTo(stream);
        }

        return filePath;
       
    }
}
