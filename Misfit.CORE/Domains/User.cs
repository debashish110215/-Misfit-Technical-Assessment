using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.CORE.Domains
{
    public class User : BaseModel
    {
        public User() {
            Calculations = new Collection<Calculation>();
        }

        [Required]
        public string UserName { get; set; }
        public ICollection<Calculation> Calculations { get; set; }

    }
}
