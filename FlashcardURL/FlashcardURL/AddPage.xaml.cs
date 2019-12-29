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
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
			InitializeComponent ();
		}

        private void BtnPreview_Clicked(object sender, EventArgs e)
        {
            webView.Source = txtURL.Text;
        }

        private void BtnOK_Clicked(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtURL.Text != "" && txtTags.Text != "" && txtName.Text != null && txtURL.Text != null && txtTags.Text != null)
            {
                Flashcard obj = new Flashcard();
                obj.Name = txtName.Text;
                obj.URL = txtURL.Text;
                obj.Tags = txtTags.Text;
                App.Database.SaveItemAsync(obj);
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Insufficient information", "Please fill all the blank entries", "OK");
            }
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

       
    }
}