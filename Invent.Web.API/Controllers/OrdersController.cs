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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly IOrdersBsRepository _orderBsRepository;

        public OrdersController(IOrdersBsRepository orderBsRepository)
        {
            _orderBsRepository = orderBsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Orders order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderBsRepository.InsertAsync(order, true);
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
                var records = await _orderBsRepository.GetAllAsync().ConfigureAwait(false);
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
                var record = await _orderBsRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> UpdateAsync(int id, Orders order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderBsRepository.UpdateAsync(order, true);
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
                await _orderBsRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/complete")]
        public async Task<IActionResult> IsOrderCompletedAsync(int id)
        {
            try
            {
                return Ok(await _orderBsRepository.IsOrderCompletedAsync(id).ConfigureAwait(false));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/voidItems")]
        public async Task<IActionResult> GetVoidItemsInOrderAsync(int id)
        {
            try
            {
                return Ok(await _orderBsRepository.GetVoidItemsInOrderAsync(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/payments")]
        public async Task<IActionResult> GetAllPaymentByOrderIdAsync(int id)
        {
            try
            {
                return Ok(await _orderBsRepository.GetAllPaymentByOrderIdAsync(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}