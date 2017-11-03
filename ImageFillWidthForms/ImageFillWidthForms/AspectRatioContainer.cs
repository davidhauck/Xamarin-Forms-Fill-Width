using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFillWidthForms
{
    public class AspectRatioContainer : ContentView
    {
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(widthConstraint, widthConstraint * this.AspectRatio));
        }

        public static BindableProperty AspectRatioProperty = BindableProperty.Create(nameof(AspectRatio), typeof(double), typeof(AspectRatioContainer), (double)1);

        public double AspectRatio
        {
            get { return (double) this.GetValue(AspectRatioProperty); }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
        
        public static BindableProperty ImageToSizeProperty = BindableProperty.Create(nameof(ImageToSize), typeof(string), typeof(AspectRatioContainer), null, propertyChanged:OnImageToSizeChanged);

        private static async void OnImageToSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var size = await DependencyService.Get<IImageSizer>().GetSizeForImage((string)newvalue);
            (bindable as AspectRatioContainer).AspectRatio = size.Height / size.Width;
        }

        public string ImageToSize
        {
            get { return (string) this.GetValue(ImageToSizeProperty); }
            set { this.SetValue(ImageToSizeProperty, value); }
        }
    }
}
