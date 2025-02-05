﻿using FinalOdevHazirlikMaui.Models;
using System.Text.Json;

namespace FinalOdevHazirlikMaui;

public partial class News : ContentPage
{
    public News()
    {
        InitializeComponent();
        lstKategori.ItemsSource = haberKategoriList;

        selectedCategory = haberKategoriList[0];
    }

    List<HaberKategori> haberKategoriList = new List<HaberKategori>()
    {
         new HaberKategori(){Baslik = "Yaşam", Link = "https://www.trthaber.com/yasam_articles.rss"},
         new HaberKategori(){Baslik = "Gündem", Link = "https://www.trthaber.com/gundem_articles.rss"},
         new HaberKategori(){Baslik = "Dünya", Link = "https://www.trthaber.com/dunya_articles.rss"},
         new HaberKategori(){Baslik = "Türkiye", Link = "https://www.trthaber.com/turkiye_articles.rss"},
         new HaberKategori(){Baslik = "Kültür Sanat", Link = "https://www.trthaber.com/kultur_sanat_articles.rss"},
         new HaberKategori(){Baslik = "Yerel", Link = "https://www.trthaber.com/yerel_articles.rss"},
         new HaberKategori(){Baslik = "Yazarlar", Link = "https://www.trthaber.com/yazarlar_articles.rss"},
         new HaberKategori(){Baslik = "Manşet", Link = "https://www.trthaber.com/manset_articles.rss"},
         new HaberKategori(){Baslik = "Son Dakika", Link = "https://www.trthaber.com/sondakika_articles.rss"},
         new HaberKategori(){Baslik = "Spor", Link = "https://www.trthaber.com/spor_articles.rss"},
         new HaberKategori(){Baslik = "Ekonomi", Link = "https://www.trthaber.com/ekonomi_articles.rss"},
         new HaberKategori(){Baslik = "Bilim Teknoloji", Link = "https://www.trthaber.com/bilim_teknoloji_articles.rss"},
         new HaberKategori(){Baslik = "Sağlık", Link = "https://www.trthaber.com/saglik_articles.rss"},
         new HaberKategori(){Baslik = "Eğitim", Link = "https://www.trthaber.com/egitim_articles.rss"},
         new HaberKategori(){Baslik = "Magazin", Link = "https://www.trthaber.com/magazin_articles.rss"},


    };

    HaberKategori selectedCategory = null;

    private void LoadNews(object sender, EventArgs e)
    {
        Load();
        refreshView.IsRefreshing = false;
    }

    async Task Load()
    {


        string jsondata = await NewsService.GetNews(selectedCategory.Link);
        if (!string.IsNullOrEmpty(jsondata))
        {
            var haberler = JsonSerializer.Deserialize<HaberRoot>(jsondata);
            lstHaberler.ItemsSource = haberler.items;
        }

    }

    private async void lstKategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedCategory = lstKategori.SelectedItem as HaberKategori;
        await Load();
    }

    private void lstHaberler_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var url = (lstHaberler.SelectedItem as Item).link;
        NewsDetail page = new NewsDetail(url);
        Navigation.PushAsync(page);
    }
}

    public class HaberKategori
    {
        public string Baslik { get; set; }
        public string Link { get; set; }
    }