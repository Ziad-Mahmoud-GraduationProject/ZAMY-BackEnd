using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Application.Services.Photo
{
    public interface IPhotoService
    {
         Tuple<int, string> SaveImage(IFormFile File);
         string UploadImage(IFormFile file);
         bool ImageExtension(IFormFile fileName, string[] allowedExtensions);
         bool ImageLength(IFormFile fileName,long imageLength);
        void AddToMeal(MealPhoto mealPhoto);
        void AddToKitchen(KitchenPhoto kitchenPhoto);
        bool DeleteImage(string image);
    }
}
