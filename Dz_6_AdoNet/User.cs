namespace Dz_6_AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public bool IsAdmin { get; set; }
    }
}
