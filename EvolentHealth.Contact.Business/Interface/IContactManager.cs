using EvolentHealth.Contact.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.Business.Interface
{
    public interface IContactManager
    {
        Task<ContactModel> GetContact(int contactId);
        Task SaveContact(ContactModel contactModel);
        Task DeleteContact(int contactId);
        Task<List<ContactModel>> GetContacts();
    }
}
