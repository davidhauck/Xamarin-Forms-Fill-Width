using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFillWidthForms
{
    public interface IImageSizer
    {
        Task<Size> GetSizeForImage(string fileName);
    }
}
