using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Зорчигчийн Data Transfer Object-ийг төлөөлдөг.
    /// </summary>
    public class PassengerDto
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
    }
}
