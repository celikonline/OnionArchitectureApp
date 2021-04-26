namespace Efactura.WebApi.Controllers
{
    using Efactura.Application.Wrappers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public abstract class ApiBaseController : ControllerBase
    {
        protected IActionResult GetErrorResult(String message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            if (!String.IsNullOrWhiteSpace(message))
            {
                ModelState.AddModelError("", message);
            }

            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }

            return new BadRequestObjectResult(ModelState);
        }

    }
}
