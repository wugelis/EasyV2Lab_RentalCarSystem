using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.Configuration7
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int? TimeoutMinutes { get; set; }
    }
}
