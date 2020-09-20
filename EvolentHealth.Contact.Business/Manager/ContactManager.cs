using AutoMapper;
using EvolentHealth.Contact.Business.Interface;
using EvolentHealth.Contact.Common.Model;
using EvolentHealth.Contact.DataAccess.Entities;
using EvolentHealth.Contact.DataAccess.Interface;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.Business.Manager
{
    public class ContactManager : IContactManager
    {
        private readonly IRepository<Contacts> _contactRepository;
        private readonly IMapper _mapper;
        public ContactManager(IRepository<Contacts> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
       
        public async Task<int> SaveContact(ContactModel contactModel)
        {
            Contacts contact = _mapper.Map<Contacts>(contactModel);
            if (contactModel.ContactId > 0)
            {
               return await _contactRepository.Update(contact);
            }
            else
            {
                return await _contactRepository.Add(contact);
            }
        }

        public ContactModel GetContact(int contactId)
        {
            return _mapper.Map<ContactModel>(_contactRepository.GetById(contactId));
        }

        public async Task<int> DeleteContact(int contactId)
        {
            Contacts contact = _contactRepository.GetById(contactId);
            return await _contactRepository.Delete(contact);
        }



    }
}
