using Xamarin.Forms;

namespace XamarinSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetUserAsync();

            name.Text = (Application.Current as App).DisplayText;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(age.Text))
            {
                await App.Database.SaveUserAsync(new User
                {
                    Name = name.Text,
                    Age = int.Parse(age.Text)
                });
            }
        }

        void userID_Completed(System.Object sender, System.EventArgs e)
        {
            (Application.Current as App).DisplayText = name.Text;
        }
    }
}
