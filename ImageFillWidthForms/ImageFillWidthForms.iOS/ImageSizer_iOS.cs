using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using ImageFillWidthForms.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ImageSizer_iOS))]
namespace ImageFillWidthForms.iOS
{
    public class ImageSizer_iOS : IImageSizer
    {
        public async Task<Size> GetSizeForImage(string fileName)
        {
            try
            {
                UIImage image = UIImage.FromFile(fileName);
                if (image == null)
                {
                    image = UIImage.LoadFromData(NSData.FromUrl(NSUrl.FromString(fileName)));
                }
                return new Size((double)image.Size.Width, (double)image.Size.Height);
            }
            catch (Exception ex)
            {
                return default(Size);
            }
        }
    }
}
