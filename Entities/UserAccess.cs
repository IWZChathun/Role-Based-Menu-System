using System;
using System.ComponentModel.DataAnnotations;

namespace RBMS.Entities
{
    public class UserAccess
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

        [Required]
        public string Module { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public UserAccess()
        {
            Created = DateTime.Now;
        }
    }
}
