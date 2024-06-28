using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageFileID { get; set; }
        [StringLength(100)]
        public string ImageFileName { get; set; }
        [StringLength(250)]
        public string ImageFilePath { get; set; }

    }
}
