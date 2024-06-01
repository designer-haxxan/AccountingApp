using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryFarm.Models
{
    public class ResponseModel
    {
        public bool isSuccess { get; set; }

        [MaxLength]
        public string? Message { get; set; }
    }
}
