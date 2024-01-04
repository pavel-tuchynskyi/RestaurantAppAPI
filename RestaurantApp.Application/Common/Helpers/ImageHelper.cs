using Microsoft.AspNetCore.Http;

namespace RestaurantApp.Application.Common.Helpers
{
    public static class ImageHelper
    {
        public static async Task<byte[]> SerializeImage(IFormFile image)
        {
            var imageBytes = new byte[image.Length];

            using (var fs = image.OpenReadStream())
            {
                await fs.ReadAsync(imageBytes, 0, (int)image.Length);
                await fs.FlushAsync();
            }

            return imageBytes;
        }

        public static string GetImageType(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);

            return extension.TrimStart('.');
        }
    }
}
