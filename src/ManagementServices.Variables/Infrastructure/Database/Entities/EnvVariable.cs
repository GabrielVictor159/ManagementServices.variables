using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables.Infrastructure.Database.Entities
{
    [Table("EnvVariable", Schema = "ManagementServices")]
    public class EnvVariable
    {
        [Key]
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
