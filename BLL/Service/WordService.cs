using AutoMapper;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IWordService
    {
        void AddWord(Word word);
        void RemoveWord(Word word);
        IEnumerable<Word> GetAll();
        IEnumerable<bool> GetIsKnow();
        IEnumerable<string> GetWords();
        IEnumerable<string> GetTranslate();
        IEnumerable<Word> GetWord();
        void Update(Word word);

    }
    public class WordService : IWordService
    {
        IUnitOfWork unitOfWork;
        IRepository<Word> words;
        IMapper mapper;
        StudyWordsModel context = new StudyWordsModel();

        public WordService()
        {
            unitOfWork = new UnitOfWork(context);
            words = unitOfWork.WordRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Word, Word>();
            });
            mapper = new Mapper(config);
        }

        public void AddWord(Word word)
        {
            unitOfWork.WordRepository.Insert(word);
            unitOfWork.Save();
        }

        public IEnumerable<Word> GetAll()
        {
            foreach (var item in words.Get())
            {
                yield return new Word()
                {
                    Id = item.Id,
                    Words = item.Words,
                    TranslateWords = item.TranslateWords,
                    IsKnow = item.IsKnow,
                };
            }
        }

        public IEnumerable<Word> GetWord()
        {
            foreach (var item in words.Get())
            {
                yield return new Word()
                {
                    Words = item.Words
                };
            }
        }

        public IEnumerable<bool> GetIsKnow()
        {
            return unitOfWork.WordRepository.Get().Select(a => a.IsKnow);
        }

        public IEnumerable<string> GetTranslate()
        {
            return unitOfWork.WordRepository.Get().Select(a => a.TranslateWords);
        }

        public IEnumerable<string> GetWords()
        {
            return unitOfWork.WordRepository.Get().Select(a => a.Words);
        }

        public void RemoveWord(Word word)
        {
            unitOfWork.WordRepository.Delete(word);
            unitOfWork.Save();
        }

        public void Update(Word word)
        {
            unitOfWork.WordRepository.Update(word);
            unitOfWork.Save();
        }
    }
}
