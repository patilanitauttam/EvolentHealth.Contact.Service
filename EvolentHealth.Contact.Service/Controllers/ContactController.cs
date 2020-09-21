using EvolentHealth.Contact.Business.Interface;
using EvolentHealth.Contact.Common.Const;
using EvolentHealth.Contact.Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.Service.Controllers
{
    [Route("api/contact")]
    [ApiController]

    public class ContactController : ControllerBase
    {
        private readonly IContactManager _contactManager;
        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        [HttpPut("Contact")]
        public async Task<IActionResult> SaveContact([FromBody] ContactModel contactModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                await _contactManager.SaveContact(contactModel);
                return Ok(new { successMessage = contactModel.ContactId > 0 ? SuccessOrErrorMessage.CONTACT_UPDATION_SUCCESS : SuccessOrErrorMessage.CONTACT_CREATEION_SUCCESS });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Contact/{contactId:int}")]
        public async Task<IActionResult> GetContact(int contactId)
        {
            try
            {
                return Ok(await _contactManager.GetContact(contactId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("Contacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                return Ok(await _contactManager.GetContacts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Contact/{contactId:int}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            try
            {
                await _contactManager.DeleteContact(contactId);
                return Ok(new { successMessage = SuccessOrErrorMessage.CONTACT_DELETION_SUCCESS });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}