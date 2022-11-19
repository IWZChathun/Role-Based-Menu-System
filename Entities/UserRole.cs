using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RBMS.Entities
{
    public class UserRole
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        public string Role { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public List<UserAccess> UserAccesses { get; set; }

        public UserRole()
        {
            Created = DateTime.Now;
        }
    }
}
