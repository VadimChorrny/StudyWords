using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Word> WordRepository { get; }
        GenericRepository<Group> GroupRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private StudyWordsModel context;

        private GenericRepository<Word> wordRepository;
        private GenericRepository<Group> groupRepository;

        public UnitOfWork(StudyWordsModel context)
        {
            this.context = context;
        }

        public GenericRepository<Word> WordRepository
        {
            get
            {
                // lazy loading
                if (this.wordRepository == null)
                {
                    this.wordRepository = new GenericRepository<Word>(context);
                }
                return wordRepository;
            }
        }
        public GenericRepository<Group> GroupRepository
        {
            get
            {
                // lazy loading
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(context);
                }
                return groupRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
