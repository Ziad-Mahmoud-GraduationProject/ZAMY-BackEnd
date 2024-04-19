using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Photo
{
    public class PhotoService(IUnitOfWork _unitOfWork,
        IWebHostEnvironment _environment) : IPhotoService
    {
        public Tuple<int, string> SaveImage(IFormFile File)
        {
            var content = _environment.ContentRootPath;
            var path = Path.Combine(content, "Uploads");
            if (!Directory.Exists(path)) 
            { Directory.CreateDirectory(path); }
            var extension = Path.GetExtension(File.FileName);
            var allowedextension = new string[] { ".jpg", ".png", ".jpeg" };
            if (!allowedextension.Contains(extension))
            {
                string msg = string.Format("Only {0} extension are allowed", string.Join(",", allowedextension));
                return new Tuple<int, string>(0, msg);
            }
            string uniquestring = Guid.NewGuid().ToString();
            var newfilename = uniquestring + extension;
            var filepath = Path.Combine(path, newfilename);
            var stream = new FileStream(filepath, FileMode.Create);
            File.CopyTo(stream);
            stream.Close();
            return new Tuple<int,string>(1,newfilename);
        }
        public  string UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded!");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var uploadsPath = Path.Combine(_environment.WebRootPath, "Uploads");

            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            var filePath = Path.Combine(uploadsPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyTo(stream);
                }

                var imageUrl = Path.Combine("/Uploads", fileName); 
                return imageUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading image: {ex.Message}");
            }
        }
        public bool ImageExtension(IFormFile fileName,string [] allowedExtensions)
        {
          var extension = Path.GetExtension(fileName.FileName).ToLower();
            return allowedExtensions.Contains(extension);
        }
        public bool ImageLength(IFormFile fileName, long imageLength)
        {
            return fileName.Length <= imageLength;
        }
        public void AddToMeal(MealPhoto mealPhoto)
        {
            _unitOfWork.MealPhotos.Add(mealPhoto);
            _unitOfWork.Complete();
        }
       public void AddToKitchen(KitchenPhoto kitchenphoto)
        {
            _unitOfWork.KitchenPhotos.Add(kitchenphoto);
            _unitOfWork.Complete();
        }
        public bool DeleteImage(string image)
        {
            var wwpath= _environment.ContentRootPath;
            var path = Path.Combine(wwpath, "Uploads\\", image);
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }

}
