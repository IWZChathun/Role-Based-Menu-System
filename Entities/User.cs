using RBMS.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RBMS.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50), Required]
        public string Username { get; set; }

        [MaxLength(50), Required]
        public string Password { get; set; }

        public long UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public User()
        {
            Created = DateTime.Now;
        }
    }
}
