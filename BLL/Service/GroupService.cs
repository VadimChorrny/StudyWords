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
    public interface IGroupService
    {
        void AddGroup(Group group);
        void RemoveGroup(Group group);
        IEnumerable<Group> GetAll();
        IEnumerable<int> GetCountWords();
        IEnumerable<string> GetGroupName();
        IEnumerable<int> GetId();
    }

    public class GroupService : IGroupService
    {
        IUnitOfWork unitOfWork;
        IRepository<Group> groups;
        IMapper mapper;
        StudyWordsModel context = new StudyWordsModel();

        public GroupService()
        {
            unitOfWork = new UnitOfWork(context);
            groups = unitOfWork.GroupRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Group, Group>();
            });
            mapper = new Mapper(config);
        }

        public void AddGroup(Group group)
        {
            unitOfWork.GroupRepository.Insert(group);
            unitOfWork.Save();
        }

        public IEnumerable<Group> GetAll()
        {
            foreach (var item in groups.Get())
            {
                yield return new Group()
                {
                    Name = item.Name,
                    CardCounter = item.CardCounter, // maybe add ICollection with words....
                    Words = item.Words
                };
            }
        }

        public void GetWords()
        {
        }

        public IEnumerable<int> GetCountWords()
        {
            return unitOfWork.GroupRepository.Get().Select(a => a.CardCounter);
        }

        public IEnumerable<string> GetGroupName()
        {
            return unitOfWork.GroupRepository.Get().Select(a => a.Name);
        }

        public IEnumerable<int> GetId()
        {
            return unitOfWork.GroupRepository.Get().Select(a => a.Id);
        }

        public void RemoveGroup(Group group)
        {
            unitOfWork.GroupRepository.Delete(group);
            unitOfWork.Save();
        }

    }
}
