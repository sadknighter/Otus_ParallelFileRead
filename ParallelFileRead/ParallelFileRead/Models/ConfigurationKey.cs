using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileRead.Models
{
    public class ConfigurationKey
    {
        public required string Key { get; set; }

        public string? Section { get; set; }
    }
}
