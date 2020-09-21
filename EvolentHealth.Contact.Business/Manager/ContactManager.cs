using AutoMapper;
using EvolentHealth.Contact.Business.Interface;
using EvolentHealth.Contact.Common.Model;
using EvolentHealth.Contact.DataAccess.Entities;
using EvolentHealth.Contact.DataAccess.Interface;
using System;
using System.Collections.Generic;
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
       
        public async Task SaveContact(ContactModel contactModel)
        {
            Contacts contact = _mapper.Map<Contacts>(contactModel);
            contact.CreatedDate = DateTime.UtcNow;
            contact.ModifiedDate = DateTime.UtcNow;
            if (contactModel.ContactId > 0)
            {
                await _contactRepository.Update(contact);
            }
            else
            {
                await _contactRepository.Add(contact);
            }
        }

        public async Task<ContactModel> GetContact(int contactId)
        {
            var contact = await _contactRepository.Get<Contacts>(x=>x.ContactId == contactId);
            return _mapper.Map<ContactModel>(contact);
        }

        public async Task<List<ContactModel>> GetContacts()
        {
            var contact = await _contactRepository.Gets();
            return _mapper.Map<List<ContactModel>>(contact);
        }

        public async Task DeleteContact(int contactId)
        {
            Contacts contact = await _contactRepository.Get<Contacts>(x => x.ContactId == contactId);
            if (!(contact is null))
            {
                await _contactRepository.Delete(contact);
            }
        }
    }
}
