using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class VaultKeepReturnModel
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public int UserId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public int Views { get; set; }
        public int Keeps { get; set; }
        public int Shares { get; set; }
    }
}