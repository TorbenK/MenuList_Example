using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MenuList_Example
{
    public partial class SamplePage : ContentPage
    {
        public SamplePage()
        {
            InitializeComponent();

            this.lvMenu.ItemSelected += (o, e) => { this.lvMenu.SelectedItem = null; };

            this.BindingContext = new MenuViewModel();
        }
    }
}
