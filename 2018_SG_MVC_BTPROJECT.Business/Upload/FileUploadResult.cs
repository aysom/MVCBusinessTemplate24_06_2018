using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_SG_MVC_BTPROJECT.Business.Upload
{
    public class FileUploadResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string FilePath { get; set; }
    }
}
