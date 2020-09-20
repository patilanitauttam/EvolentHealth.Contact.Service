using EvolentHealth.Contact.Common.Model;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.Business.Interface
{
    public interface IContactManager
    {
        ContactModel GetContact(int contactId);
        Task<int> SaveContact(ContactModel contactModel);
        Task<int> DeleteContact(int contactId);
    }
}
