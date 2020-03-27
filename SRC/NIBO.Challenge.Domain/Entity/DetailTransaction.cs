using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NIBO.Challenge.Domain.Enums;

namespace NIBO.Challenge.Domain.Entity
{
    public class DetailTransaction:Base
    {
        [Key]
        public int IdDetail { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }
        public string Detail { get; set; }
        public int IdHeader { get; set; }

    }
}
