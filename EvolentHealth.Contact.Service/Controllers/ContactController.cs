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
                return Ok(contactModel.ContactId > 0 ? SuccessOrErrorMessage.CONTACT_UPDATION_SUCCESS : SuccessOrErrorMessage.CONTACT_CREATEION_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Contact/{contactId}")]
        public IActionResult GetContact([FromQuery] int contactId)
        {
            try
            {
                return Ok(_contactManager.GetContact(contactId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Contact/{contactId}")]
        public IActionResult DeleteContact([FromQuery] int contactId)
        {
            try
            {
                return Ok(_contactManager.DeleteContact(contactId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}