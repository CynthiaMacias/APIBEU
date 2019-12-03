using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class FileInputModel
    {
        public int ImageID { get; set; }
        public int EmpleadoID { get; set; }
        public IFormFile Photo { get; set; }
    }
}
