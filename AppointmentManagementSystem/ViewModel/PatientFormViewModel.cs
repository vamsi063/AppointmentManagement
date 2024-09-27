using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagementSystem.ViewModel
{
    public class PatientFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Sex { get; set; }
        [Required]
        [ValidDate]
        public string BirthDate { get; set; }


        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public byte City { get; set; }

        public DateTime Date { get; set; }

        
        public string Heading { get; set; }

        public DateTime GetBirthDate()
        {
            //TODO: Validate BirthDate 

            return DateTime.Parse(string.Format("{0}", BirthDate));
            //return DateTime.ParseExact(BirthDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
        
        public IEnumerable<City> Cities { get; set; }

    }
}
