namespace FinalOdevHazirlikMaui;

public partial class Ayarlar : ContentPage
{
	public Ayarlar()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }

    private async void LogoutButtonClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Çýkýþ Yap", "Çýkmak istediðinize emin misiniz?", "Evet", "Hayýr");
        if (answer)
        {
            // Login sayfasýna yönlendirme
            await Navigation.PushAsync(new MainPage());
        }
    }
}