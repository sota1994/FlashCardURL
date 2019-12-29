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
	public partial class ShowPage : ContentPage
	{
		public ShowPage ()
		{
			InitializeComponent ();
		}

        public ShowPage (Flashcard item)
        {
            InitializeComponent();
            webView.Source = item.URL;
        }
	}
}