using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Words { get; set; }
        [Required]
        [MaxLength(150)]
        public string TranslateWords { get; set; }
        public bool IsKnow { get; set; }
    }
}
