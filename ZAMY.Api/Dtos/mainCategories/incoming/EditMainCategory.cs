﻿namespace ZAMY.Api.Dtos.mainCategories.incoming
{
    public class EditMainCategory
    {
        public string Name { get; set; } = null!;
        public IFormFile Img { get; set; }
    }
}
