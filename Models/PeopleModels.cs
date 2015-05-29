using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace FirstMVCApplication.Models
{
    public class PeopleModels
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        [Display(Name = "Pbrithday")]
        [DataType(DataType.Date)]
        public DateTime Pbrith { get; set; }
        public string Page { get; set; }
        public string Psex { get; set; }
    }
    public class PeopleDBContext : DbContext
    {
        public DbSet<PeopleModels> peoples { get; set; }
    }
}