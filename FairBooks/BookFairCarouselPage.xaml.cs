using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FairBooks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookFairCarouselPage : CarouselPage
    {
        public BookFairCarouselPage()
        {
            InitializeComponent();
        }
    }
}