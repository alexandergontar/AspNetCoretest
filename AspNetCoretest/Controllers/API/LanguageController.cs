using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;


namespace AspNetCoretest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private Guid guid;
        private readonly IStringLocalizer<LanguageController> _localizer;
        public LanguageController(IStringLocalizer<LanguageController> localizer)
        {
            _localizer = localizer;            
        }
        [HttpGet]
       
        public async Task<IActionResult>  Get()
        {          
            await Task.Run(()=> {
                guid = Guid.NewGuid();
            });              
            return Ok(_localizer["RandomGUID", guid.ToString()].Value);
        }
    }
}