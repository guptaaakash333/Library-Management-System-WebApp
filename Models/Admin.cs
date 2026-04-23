using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemWebApplication.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
