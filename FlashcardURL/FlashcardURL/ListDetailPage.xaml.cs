using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashcardURL.ViewModel;
using FlashcardURL.Models;

namespace FlashcardURL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListDetailPage : ContentPage
	{
        
        private string _tags;
        private bool  _add = true;
		public ListDetailPage ()
		{
			InitializeComponent ();
            searchBar.Text = "";
		}

        public ListDetailPage (string tag, bool mode)
        {
            InitializeComponent();
            //listView.ItemsSource = await App.Database.GetSearchListAsync(Tags);
            _tags = tag;
            _add = mode;
            searchBar.Text = "";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetSearchListAsync(_tags, searchBar.Text);
            if (_add)
            {
                btnAdd.IsVisible = true;
            }
            else
            {
                btnAdd.IsVisible = false;
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int flashcardID = 0;
            var obj = ((TappedEventArgs)e).Parameter;
            int.TryParse(obj.ToString(), out flashcardID);
            var item = await App.Database.GetItemAsync(flashcardID);
            await Navigation.PushModalAsync(new EditPage(item));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Are you sure?", "This item will be deleted permanently", "Yes", "No");
            if (answer)
            {
                int flashcardID = 0;
                var obj = ((TappedEventArgs)e).Parameter;
                int.TryParse(obj.ToString(), out flashcardID);
                var item = await App.Database.GetItemAsync(flashcardID);
                await App.Database.DeleteItemAsync(item);
                listView.ItemsSource = await App.Database.GetSearchListAsync(_tags, searchBar.Text);
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Flashcard)e.SelectedItem;
            Navigation.PushModalAsync(new ShowPage(item));

        }

        private  void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddSavedListPage(_tags));
            _add = false;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = await App.Database.GetSearchListAsync(_tags, searchBar.Text);
        }
    }
}