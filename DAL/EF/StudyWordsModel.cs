using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class StudyWordsModel : DbContext
    {
        public StudyWordsModel()
            : base("name=StudyWordsModel")
        {
        }
        public virtual DbSet<Word> Words { get; set; }
    }
}