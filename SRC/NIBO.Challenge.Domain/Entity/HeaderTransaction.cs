using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NIBO.Challenge.Domain.Entity
{
    public class HeaderTransaction : Base
    {
        [Key]
        public int IdHeader { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        [NotMapped]
        public List<DetailTransaction> ListDetailsTransaction{get;set;}

    }
}
