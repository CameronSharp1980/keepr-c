using System.ComponentModel.DataAnnotations;

namespace keepr_c.Models
{
    public class Vault
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}