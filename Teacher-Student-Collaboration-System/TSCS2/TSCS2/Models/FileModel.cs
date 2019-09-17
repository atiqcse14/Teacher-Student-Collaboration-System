using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSCS2.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public int cid { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}