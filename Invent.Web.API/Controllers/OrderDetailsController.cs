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
    [Route("api/OrderDetails")]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsBsRepository _orderDetailsBsRepository;

        public OrderDetailsController(IOrderDetailsBsRepository orderDetailsBsRepository)
        {
            _orderDetailsBsRepository = orderDetailsBsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderDetails orderDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderDetailsBsRepository.InsertAsync(orderDetails, true);
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
                var records = await _orderDetailsBsRepository.GetAllAsync().ConfigureAwait(false);
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
                var record = await _orderDetailsBsRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> UpdateAsync(int id, OrderDetails orderDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderDetailsBsRepository.UpdateAsync(orderDetails, true);
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
                await _orderDetailsBsRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}