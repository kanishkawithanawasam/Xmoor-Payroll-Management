using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public int RoleName { get; set; }
    }
}
