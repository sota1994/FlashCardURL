using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashcardURL.ViewModel;
using System.IO;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlashcardURL
{
    public partial class App : Application
    {
        static FlashCardBusiness database = null;
        public static FlashCardBusiness Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Flashcard.db3");


                   // var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("NewSQLite.db3");
                    //string dbPath = Path.Combine(@"/storage/emulated/0/Test", "Flashcard.db3");
                    Debug.WriteLine(dbPath);
                    database = new FlashCardBusiness(dbPath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new ListPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
