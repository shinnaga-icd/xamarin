using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinSample
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();

            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            dbView.ItemsSource = await App.Database.GetUserAsync();

            name.Text = (Application.Current as App).DisplayText;
        }

        //Application.Currentへ入力データの一時保管
        void userID_Completed(System.Object sender, System.EventArgs e)
        {
            (Application.Current as App).DisplayText = name.Text;
        }

        //ローカルDatabaseへの保管
        async void DatabaseRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(age.Text))
            {
                await App.Database.SaveUserAsync(new User
                {
                    Name = name.Text,
                    Age = int.Parse(age.Text)
                });

                dbView.ItemsSource = await App.Database.GetUserAsync();
            }
        }

        //REST APIの呼び出し
        async void GetRepository_Clicked(System.Object sender, System.EventArgs e)
        {
            List<Repository> repositories = await _restService.GetRepositoriesAsync(Constants.GitHubReposEndpoint);
            RepoView.ItemsSource = repositories;
        }
    }
}
