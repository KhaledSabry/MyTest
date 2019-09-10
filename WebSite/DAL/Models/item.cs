using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.DAL.Models
{ 
    public class item
    { 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int ID { get; set; }
        [Required]
        public category cat { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int value { get; set; }


        public string categoryName { get { return this.cat!=null?this.cat.name:""; } }
    }
}
