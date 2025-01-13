namespace FinalOdevHazirlikMaui;

public partial class HavaDurumu : ContentPage
{
    private readonly List<string> cities = new()
    {
        "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AMASYA", "ANKARA", "ANTALYA",
        "ARTVİN", "AYDIN", "BALIKESİR", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR",
        "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM", "DENİZLİ", "DİYARBAKIR", "EDİRNE",
        "ELAZIĞ", "ERZİNCAN", "ERZURUM", "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE",
        "HAKKARİ", "HATAY", "IĞDIR", "ISPARTA", "İSTANBUL", "İZMİR", "KAHRAMANMARAŞ",
        "KARABÜK", "KARAMAN", "KARS", "KASTAMONU", "KAYSERİ", "KIRIKKALE", "KIRKLARELİ",
        "KIRŞEHİR", "KİLİS", "KOCAELİ", "KONYA", "KÜTAHYA", "MALATYA", "MANİSA", "MARDİN",
        "MERSİN", "MUĞLA", "MUŞ", "NEVŞEHİR", "NİĞDE", "ORDU", "OSMANİYE", "RİZE", "SAKARYA",
        "SAMSUN", "SİİRT", "SİNOP", "SİVAS", "ŞANLIURFA", "ŞIRNAK", "TEKİRDAĞ", "TOKAT",
        "TRABZON", "TUNCELİ", "UŞAK", "VAN", "YALOVA", "YOZGAT", "ZONGULDAK"
    };

    public HavaDurumu()
    {
        InitializeComponent();
        cityPicker.ItemsSource = cities;
    }

    private void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cityPicker.SelectedItem is string selectedCity)
        {
            string imageUrl = $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={selectedCity}&basla=1&bitir=5&rC=111&rZ=fff";

            ImageButton newImage = new ImageButton
            {
                Source = imageUrl,
                HeightRequest = 200,
                WidthRequest = 400
            };

            Label text = new Label
            {
                Text = selectedCity,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            newImage.Clicked += DeleteButton_Clicked;

            StackLayout imageLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10
            };
            imageLayout.Children.Add(text);
            imageLayout.Children.Add(newImage);

            imageStackLayout.Children.Add(imageLayout);
        }
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        ImageButton deleteButton = (ImageButton)sender;
        StackLayout imageLayout = (StackLayout)deleteButton.Parent;
        imageStackLayout.Children.Remove(imageLayout);
    }
}
