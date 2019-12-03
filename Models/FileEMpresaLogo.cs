using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class FileEMpresaLogo
    {
        public int ImageID { get; set; }
        public int EmpresaID { get; set; }
        public IFormFile Photo { get; set; }
    }
}
