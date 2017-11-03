using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImageFillWidthForms.Droid;
using Java.Net;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ImageSizer_Android))]
namespace ImageFillWidthForms.Droid
{
    public class ImageSizer_Android : IImageSizer
    {
        public async Task<Size> GetSizeForImage(string fileName)
        {
            string fileNameStripped = System.IO.Path.GetFileNameWithoutExtension(fileName);
            var resId = Forms.Context.Resources.GetIdentifier(
                fileNameStripped, "drawable", Forms.Context.PackageName);
            if (resId == 0 && fileName.Contains("http"))
            {
                try
                {
                    URL url = new URL(fileName);
                    Bitmap bmp = await Task.Run(() => BitmapFactory.DecodeStream(url.OpenConnection().InputStream));
                    return new Size(bmp.Width, bmp.Height);
                }
                catch (Exception e)
                {
                    return default(Size);
                }
            }
            else
            {
                var options = new BitmapFactory.Options
                {
                    InJustDecodeBounds = true
                };
                BitmapFactory.DecodeResource(
                    Forms.Context.Resources, resId, options);
                return new Size(options.OutWidth, options.OutHeight);
            }
        }
    }
}