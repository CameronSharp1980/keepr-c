using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        [Required]
        public int VaultId { get; set; }
        [Required]
        public int KeepId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}