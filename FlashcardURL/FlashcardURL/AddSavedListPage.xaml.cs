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
	public partial class AddSavedListPage : ContentPage
	{
        private string _tags;
		public AddSavedListPage ()
		{
			InitializeComponent ();
		}

        public AddSavedListPage (string Tags)
        {
            InitializeComponent();
            _tags = Tags;
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            var obj = new SavedList();
            obj.Name = txtName.Text;
            obj.Tags = _tags;
            await App.Database.SaveSavedListAsync(obj);
            await Navigation.PopModalAsync();
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}