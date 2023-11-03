using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBOOST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage  
    {
        public WelcomePage()
        {
            InitializeComponent();
            welcomeBackgroundImage.Source = ImageSource.FromResource("FitBOOST.welcomeBackground.png");
            welcomeBackgroundImage.Aspect = Aspect.AspectFill;
        }

        private async void acceptButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void acceptCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (acceptCheckBox.IsChecked == true)
            {
                acceptButton.IsEnabled = true;
            }
            else if (acceptCheckBox.IsChecked == false)
            {
                acceptButton.IsEnabled = false;
            }
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RulesPage());
        }
    }
}