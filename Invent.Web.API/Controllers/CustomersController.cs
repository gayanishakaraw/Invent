using System;
using System.Threading.Tasks;
using Invent.Web.Business.Repositories;
using Invent.Web.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invent.Web.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomersBsRepository _customersBsRepository;

        public CustomersController(ICustomersBsRepository customersBsRepository)
        {
            _customersBsRepository = customersBsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Customers customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customersBsRepository.InsertAsync(customer, true);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var records = await _customersBsRepository.GetAllAsync().ConfigureAwait(false);
                if (records != null)
                {
                    return Ok(records);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var record = await _customersBsRepository.GetByIdAsync(id);

                if (record != null)
                    return Ok(record);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Customers customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customersBsRepository.UpdateAsync(customer, true);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _customersBsRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/activeStatus")]
        public async Task<IActionResult> IsActiveCustomerAsync(int id)
        {
            try
            {
                return Ok(await _customersBsRepository.IsActiveCustomerAsync(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}