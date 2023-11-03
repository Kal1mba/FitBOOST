using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitBOOST
{
    public partial class MainPage : FlyoutPage
    {
        //FLYOUT PAGE
        public MainPage()
        {
            InitializeComponent();
            flyoutMenuPage.listView.ItemSelected += OnSelectedItem;
            ShowWelcomePage();
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyoutMenuPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }

        async void ShowWelcomePage()
        {
            await Navigation.PushModalAsync(new WelcomePage());
        }
    }
}
