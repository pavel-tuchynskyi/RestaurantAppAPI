using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Common.Enums;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems.ValueObjects
{
    public class Image : ValueObject
    {
        public static readonly int IMAGE_MAX_LENGHT = 1000000;
        private static Dictionary<string, ImageTypes> _allowedTypes = new()
        {
            { ".jpg", ImageTypes.jpg },
            { ".png", ImageTypes.png },
            { "jpg", ImageTypes.jpg },
            { "png", ImageTypes.png }
        };

        public byte[] ImageBlob { get; private set; }
        public ImageTypes ImageType { get; private set; }

        protected Image() { }
        private Image(byte[] imageBlob, ImageTypes imageType) : this()
        {
            ImageBlob = imageBlob;
            ImageType = imageType;
        }

        public static Image Create(byte[] imageBlob, string type)
        {
            Guard.Is(type, nameof(ImageTypes)).NotNullOrWhitespace();

            type = type.Trim();
            var imageType = _allowedTypes[type];

            Guard.Is(imageType, nameof(ImageTypes)).IsEnumOf<ImageTypes>();
            Guard.Is(imageBlob, nameof(ImageBlob)).NotNullOrEmpty();

            return new Image(imageBlob, imageType);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return ImageBlob;
            yield return ImageType;
        }
    }
}
