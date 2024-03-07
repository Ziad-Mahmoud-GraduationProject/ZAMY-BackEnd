using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.KitchenPhotos
{
    public interface IKitchenPhotoService
    {
        KitchenPhoto Upload(IFormFile kitchenphoto);
       // KitchenPhoto Add(KitchenPhoto kitchenPhoto);
    }
}
