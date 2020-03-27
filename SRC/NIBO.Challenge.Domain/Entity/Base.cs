using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NIBO.Challenge.Domain.Entity
{
    public class Base
    {
        

        private DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get { return (_registrationDate==DateTime.MinValue?DateTime.Now:_registrationDate); }
            set { _registrationDate = value; }
        }
    }
}
