using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace ZAMY.Application.Services.KitchenPhotos
{
    public class KitchenPhotoService(IUnitOfWork _unitofwork
       ,string _uploadfolderPath ) : IKitchenPhotoService
    {
        public KitchenPhoto Upload(IFormFile imagefile)
        {
            if (!Directory.Exists(_uploadfolderPath))
            {
                Directory.CreateDirectory(_uploadfolderPath);
            }
            if (imagefile == null || imagefile.Length == 0)
            {
                throw new ArgumentNullException("empty");
            }
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(imagefile.FileName)}";
            string filePath = Path.Combine(_uploadfolderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imagefile.CopyTo(fileStream);
            }
           var k=new KitchenPhoto();
            /*  k.FileName = fileName;*/
           // k.Image = $"/images/{k.FileName}";
            _unitofwork.KitchenPhotos.Add(k);
            _unitofwork.Complete();
            return k;
          
            //new KitchenPhoto { FileName = fileName };
            //   imagefile.Filepath = $"/images/{imagefile.Filename}";
        }
       /* public KitchenPhoto Add(KitchenPhoto kitchenPhoto)
        {

            _unitofwork.KitchenPhotos.Add(k);
            _unitofwork.Complete();
            return k;
        }*/
    }
}
