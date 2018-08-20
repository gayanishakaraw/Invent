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
    [Route("api/ItemStocks")]
    public class ItemStocksController : Controller
    {
        private readonly IItemStocksBsRepository _itemStocksBsRepository;

        public ItemStocksController(IItemStocksBsRepository itemStocksBsRepository)
        {
            _itemStocksBsRepository = itemStocksBsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ItemStocks itemStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemStocksBsRepository.InsertAsync(itemStock, true);
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
                var records = await _itemStocksBsRepository.GetAllAsync().ConfigureAwait(false);
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
                var record = await _itemStocksBsRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> UpdateAsync(int id, ItemStocks itemStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemStocksBsRepository.UpdateAsync(itemStock, true);
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
                await _itemStocksBsRepository.DeleteAsync(id, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/reorderStatus")]
        public async Task<IActionResult> IsRequiredToReorderAsync(int id)
        {
            try
            {
                return Ok(await _itemStocksBsRepository.IsRequiredToReorderAsync(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}