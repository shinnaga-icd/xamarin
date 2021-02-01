using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinSample
{
    public partial class App : Application
    {
        const string DISPLAY_TEXT = "displayText";
        public string DisplayText { get; set; }

        static Database database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static Database Database
        {
            get
            {
                if(database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart");
            if (Properties.ContainsKey(DISPLAY_TEXT))
            {
                DisplayText = (string)Properties[DISPLAY_TEXT];
            }
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
        }
    }
}
