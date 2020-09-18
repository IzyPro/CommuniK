using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CommuniK
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void SignUpButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

        private void ForgotPasswordButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassword());
        }

        private void ChatRoomButtonClicked(object sender, EventArgs e)
        {
            string Name = this.Name.Text;
            Navigation.PushAsync(new ChatRoom(Name));
        }
    }
}
