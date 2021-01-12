using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Fingers10.ExcelExport.Attributes;
using Microsoft.AspNetCore.Http;

namespace ExpanseTracker.Models
{
    public class Expense
    {
        [Key]
        [DisplayName("Id")]
        [IncludeInReport(Order = 1)]
        public int Id { get; set; }

        [MaxLength(100)]
        [IncludeInReport(Order = 2)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [IncludeInReport(Order = 3)]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        [IncludeInReport(Order = 4)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [MaxLength(100)]
        [DisplayName("FileName")]
        public string FileName { get; set; }
        public byte[] Attachment { get; set; }

        [NotMapped]
        public IFormFile AttchFile { get; set; }
    }
}
