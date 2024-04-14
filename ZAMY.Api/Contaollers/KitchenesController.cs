using System.Linq;
using ZAMY.Application.Services.KitchenOwnerPhones;
using ZAMY.Application.Services.Photo;
 

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchensController
        (IKitchenService _kitchenService,
         IPhotoService _photoService,
         IKitchenOwnerPhoneService _kitchenOwnerPhoneService,
        IMapper _mapper) : ControllerBase
    {
        private string[] allowedExtention = new string[] { ".jpg", ".png" };
        private long imageLength = 1048576;

        [HttpGet("")]
        public IActionResult Get([FromQuery] PaginationParameters paginationParameters)
        {
            var kitchens = _mapper.Map<IEnumerable<KitchenDto>>(_kitchenService.GetAll(paginationParameters));

            return Ok(kitchens);

        }



        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var kitchen = _mapper.Map<KitchenDto>(_kitchenService.GetById(id));

            return Ok(kitchen);

        }



        [HttpGet("name/{name}")]
        public IActionResult Get(string name, [FromQuery] PaginationParameters paginationParameters)
        {
            var kitchens = _mapper.Map<IEnumerable<KitchenDto>>(_kitchenService.GetKitchenName(name, paginationParameters));

            return Ok(kitchens);


        }
        [HttpPost("Create")]
        public IActionResult Create([FromForm] CreateKitchenDto dto, [FromForm]IList<string>phones, [FromForm] IList<IFormFile>files)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (files is null || !files.Any()) return NotFound("Not Found any Image");

            if (phones is null || !phones.Any()) return NotFound("Not Found any phones");

            foreach (var phone in phones)
            {
                if (string.IsNullOrEmpty(phone))
                    return BadRequest(error: "Phone Not Valid! ");
                if (!_kitchenOwnerPhoneService.IsMatching(phone))
                    return BadRequest(error: "Phone Not Valid ! ");
            }

            foreach (var file in files)
            {
                if (!_photoService.ImageExtension(file, allowedExtention))
                    return BadRequest(error: "Only .jpg,.png image are allowed! ");

                if (!_photoService.ImageLength(file, imageLength))
                    return BadRequest(error: "max allowed size for image 1MB! ");
            }

            var kitchen = _mapper.Map<Kitchen>(dto);
  
            _kitchenService.Add(kitchen);

                foreach (var file in files)
                {

                    var photo = new KitchenPhoto
                    {
                        Image = _photoService.UploadImage(file),
                        KitchenId = kitchen.Id
                    };
                    _photoService.AddToKitchen(photo);
                }
            
                foreach (var phone in phones)
                {
                         var newphone = new KitchenOwnerPhone
                          {
                            Phone = phone,
                            KitchenId = kitchen.Id
                          };

                    _kitchenOwnerPhoneService.Add(newphone);
                }
            return Ok(kitchen);
        }
    }
}
