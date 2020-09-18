using CommuniK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommuniK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoom : ContentPage
    {
        ChatRoomViewModel chatRoomViewModel;
        public ChatRoom(string name)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = chatRoomViewModel = new ChatRoomViewModel(name);

            chatRoomViewModel.Messages.CollectionChanged += (sender, e) =>
            {
                var target = chatRoomViewModel.Messages[chatRoomViewModel.Messages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.MakeVisible, true);
            };
        }
        void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;

        }
    }
}