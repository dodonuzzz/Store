namespace Yeniden_Chum_Bucket.Migrations
{
    using Microsoft.Ajax.Utilities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;
    using Yeniden_Chum_Bucket.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Yeniden_Chum_Bucket.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Yeniden_Chum_Bucket.Models.ProductContext context)
        {
            var koltuk = new Product
            {
                UrunAdi = "3'lü Koltuk",
                Fiyat = 26999.00M,
                ResimYolu = "~/wwwroot/images/maria-mavi-kanepe.jpg"

            };
            var püskevit = new Product
            {
                UrunAdi = "OREO püskevit 220 G",
                Fiyat = 62.45M,
                ResimYolu = "~/wwwroot/images/61AAkAkTnTL._AC_UL210_SR210,210_.jpg"

            };
            var elbise = new Product
            {
                UrunAdi = "V yaka elbise",
                Fiyat = 399.99M,
                ResimYolu = "~/wwwroot/images/siyah-v-yaka-elbise-0e0b.jpg"
            };
            var iphone = new Product
            {
                UrunAdi = "İphone 14 Pro Max 256Gb Mor (Apple Türkiye Garantili)",
                Fiyat = 73999.00M,
                ResimYolu = "~/wwwroot/images/iphone-14-pro-finish-select-202209-6-7inch-deeppurple.jpg"
            };
            var kusbasi = new Product
            {
                UrunAdi = "Dana Kuşbaşı Kg",
                Fiyat = 305.90M,
                ResimYolu = "~/wwwroot/images/Dana-Kusbasi-2.jpg"

            };
            var barbunya = new Product
            {
                UrunAdi = "Tamek Barbunya Pilaki 400 Gr",
                Fiyat = 25.99M,
                ResimYolu = "~/wwwroot/images/1008412--84c1-.jpg"
            };
            var coconut = new Product
            {
                UrunAdi = "Hindistan Cevizi Adet",
                Fiyat = 36.95M,
                ResimYolu = "~/wwwroot/images/9945833537586.jpg"
            };
            var klima = new Product
            {
                UrunAdi = "Baymak Elegant Prime 24 A++ 24000 Btu Inverter Duvar Tipi Klima",
                Fiyat = 30999.00M,
                ResimYolu = "~/wwwroot/images/baymak-elegant-plus-uv-duvar-tipi-split-klima-yeni.jpg"
            };




            context.Products.AddOrUpdate(koltuk);
            context.Products.AddOrUpdate(püskevit);
            context.Products.AddOrUpdate(elbise);
            context.Products.AddOrUpdate(iphone);
            context.Products.AddOrUpdate(kusbasi);
            context.Products.AddOrUpdate(barbunya);
            context.Products.AddOrUpdate(coconut);
            context.Products.AddOrUpdate(klima);


            context.SaveChanges();
        }
    }
    
}
