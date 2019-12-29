using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashcardURL.Models;

namespace FlashcardURL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        Flashcard _obj;
		public EditPage()
		{
			InitializeComponent ();
		}
        public EditPage(Flashcard obj)
        {
            InitializeComponent();
            _obj = obj;
            BindingContext = _obj;
        }

        private void BtnPreview_Clicked(object sender, EventArgs e)
        {
            webView.Source = txtURL.Text;
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtURL.Text != "" && txtTags.Text != "" && txtName.Text != null && txtURL.Text != null && txtTags.Text != null)
            {
                _obj.Name = txtName.Text;
                _obj.URL = txtURL.Text;
                _obj.Tags = txtTags.Text;
                await App.Database.SaveItemAsync(_obj);
                await Navigation.PopModalAsync();

            }
            else
            {
                await DisplayAlert("Insufficient information", "Please fill all the blank entries", "OK");

            }
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}