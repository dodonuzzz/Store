using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Yeniden_Chum_Bucket.Models
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string UrunAdi { get; set; } = string.Empty;
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
    }
}