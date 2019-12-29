using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashcardURL.ViewModel;
using FlashcardURL.Models;
using System.Diagnostics;

namespace FlashcardURL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
        
		public  ListPage ()
		{
			InitializeComponent ();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // new FlashCardBusiness(DependencyService.Get<IFileHelper>().GetLocalFilePath("NewSQLite.db3"));

            //Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            /*Flashcard obj = new Flashcard();
            obj.Name = "Google Machine Learning Crash-Course";
            obj.URL = "https://developers.google.com/machine-learning/crash-course/ml-intro";
            obj.Tags = "machinelearning google programming code";
            await App.Database.SaveItemAsync(obj);

            obj = new Flashcard();
            obj.Name = "Dotabuff";
            obj.URL = "https://www.dotabuff.com";
            obj.Tags = "gaming dota moba statistics";
            await App.Database.SaveItemAsync(obj);*/
          
            
            listView.ItemsSource = await App.Database.GetSavedListsAsync();

            //listView.ItemsSource = await App.Database.GetItemsAsync();
            
            
            //await App.Database.DropDataBase();


        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (SavedList)e.SelectedItem;
            Navigation.PushModalAsync(new ListDetailPage(item.Tags, false));
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int listID = 0;
            var obj = ((TappedEventArgs)e).Parameter;
            int.TryParse(obj.ToString(), out listID);
            var item = await App.Database.GetSavedListAsync(listID);
            await Navigation.PushModalAsync(new EditSavedListPage(item));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Are you sure?", "This item will be deleted permanently", "Yes", "No");
            if (answer)
            {
                int listID = 0;
                var obj = ((TappedEventArgs)e).Parameter;
                int.TryParse(obj.ToString(), out listID);
                var item = await App.Database.GetSavedListAsync(listID);
                await App.Database.DeleteSavedListAsync(item);
                listView.ItemsSource = await App.Database.GetSavedListsAsync();
            }
        }

        private void SearchFlashCard_SearchButtonPressed(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new ListDetailPage(searchFlashCard.Text, true));
            //listView.ItemsSource = await App.Database.GetSearchListAsync(searchFlashCard.Text);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListDetailPage("", false));
            //listView.ItemsSource = await App.Database.GetItemsAsync();
        }

       
    }
}