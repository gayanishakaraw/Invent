using System;
using System.Threading.Tasks;
using Invent.Web.Business.Repositories;
using Invent.Web.Common;
using Invent.Web.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invent.Web.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Permissions")]
    public class PermissionsController : Controller
    {
        private readonly IPermissionsBsRepository _permissionsBsRepository;

        public PermissionsController(IPermissionsBsRepository permissionsBsRepository)
        {
            _permissionsBsRepository = permissionsBsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Permissions permissions)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _permissionsBsRepository.InsertAsync(permissions, true);
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
                var records = await _permissionsBsRepository.GetAllAsync().ConfigureAwait(false);
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
                var record = await _permissionsBsRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> UpdateAsync(int id, Permissions permissions)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _permissionsBsRepository.UpdateAsync(permissions, true);
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
                await _permissionsBsRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/{moduleId}/{actionId}/Access")]
        public async Task<IActionResult> CanProceedAsync(int userId, Modules module, Actions action)
        {
            try
            {
                return Ok(await _permissionsBsRepository.CanProceedAsync(userId, module, action).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}