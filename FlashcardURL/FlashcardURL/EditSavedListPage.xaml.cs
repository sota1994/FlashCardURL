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
	public partial class EditSavedListPage : ContentPage
	{
        private SavedList _item;
		public EditSavedListPage ()
		{
			InitializeComponent ();
		}

        public EditSavedListPage (SavedList item)
        {
            InitializeComponent();
            _item = item;
            txtName.Text = _item.Name;
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            _item.Name = txtName.Text;
            await App.Database.SaveSavedListAsync(_item);
            await Navigation.PopModalAsync();
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}