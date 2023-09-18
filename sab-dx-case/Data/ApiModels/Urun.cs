using System.ComponentModel.DataAnnotations;

namespace sab_dx_case.Data.ApiModels
{
    public class Urun
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

        [Required]
        [MaxLength(20)]
        public string Kodu { get; set; }

        [Required]
        [MaxLength(255)]
        public string Aciklama { get; set; }

        [Required]
        [MaxLength(50)]
        public string Marka { get; set; }

        [Required]
        public string ParaBirimi { get; set; }

        [Required]
        [Range(0, double.MaxValue)] // Only positive values
        public decimal Fiyat { get; set; }

        [Required]
        [Range(0, int.MaxValue)] // only positive values
        public int StokDurumu { get; set; }

        public bool IsDeleted { get; set; }
    }
}
