using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [StringLength(50)]
        public string AutorName { get; set; }

        [StringLength(100)]
        public string AutorImage { get; set; }

        [StringLength(500)]
        public string AutorDescription { get; set; }

        [StringLength(50)]
        public string AutorTitle { get; set; }
        
        [StringLength(100)]
        public string AutorAboutShort {  get; set; }

        [StringLength(50)]
        public string AutorMail {  get; set; }

        [StringLength(50)]
        public string AutorPassword {  get; set; }

        [StringLength(20)]
        public string AutorPhoneNumber { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
