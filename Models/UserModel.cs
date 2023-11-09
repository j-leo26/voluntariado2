
using System.ComponentModel.DataAnnotations;

namespace voluntariado2.Models
{
    public class UserModel
    {
        public int IdUser { get; set; }
        public int IdRol { get; set; }
        public int IdState { get; set; }
        public int IdOffer { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CcNit { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; }
    }
    public class UserModel2
    {
        public int IdUser { get; set; }
        public int IdRol { get; set; }
        public int IdState { get; set; }
        public int IdOffer { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CcNit { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        
    }
    
}