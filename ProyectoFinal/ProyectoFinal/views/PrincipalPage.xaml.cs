using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : FlyoutPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
            this.Detail = new NavigationPage(new DetailPage());
            this.Flyout = new LateralMenu();

            App.FlyoutP = this;
        }
    }
}