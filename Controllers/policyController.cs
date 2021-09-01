using Microsoft.AspNetCore.Mvc;
using PolicyStoreWebApi.Models;
using PolicyStoreWebApi.Services;
using System.Collections.Generic;

namespace PolicyStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class policyController : ControllerBase
    {
        private readonly PolicyService _policyService;

        public policyController(PolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public ActionResult<List<Policy>> Get() =>
            _policyService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPolicy")]
        public ActionResult<Policy> Get(string id)
        {
            var book = _policyService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Policy> Create(Policy policy)
        {
            _policyService.Create(policy);

            return CreatedAtRoute("GetPolicy", new { id = policy.Id.ToString() }, policy);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Policy policyIn)
        {
            var policy = _policyService.Get(id);

            if (policy == null)
            {
                return NotFound();
            }

            _policyService.Update(id, policyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var policy = _policyService.Get(id);

            if (policy == null)
            {
                return NotFound();
            }

            _policyService.Remove(policy.Id);

            return NoContent();
        }
    }
}
