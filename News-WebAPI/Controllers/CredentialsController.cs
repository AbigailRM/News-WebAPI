using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using News_WebAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Rest;

namespace News_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly NewsServerContext _context;
        private readonly ITokenProvider _tokenProvider;

        public CredentialsController(NewsServerContext context, ITokenProvider tokenProvider)
        {
            _context = context;
            _tokenProvider = tokenProvider;
        }

        [HttpPost("credential")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromForm]string name, [FromForm]string password)
        {
            int hoursForExpiration = 24;
            DateTime ExpirationTime = DateTime.UtcNow.AddHours(hoursForExpiration);
            var conn = _context.Database.GetDbConnection();

            var res = conn.QuerySingleOrDefault<User>("ValidatingUser", new
            {
                name,
                password
            }, 
            commandType: System.Data.CommandType.StoredProcedure);

            if (res == null)
            {
                return BadRequest("Those credentials are invalid.");
            }

            var token = _tokenProvider.AToken(res, ExpirationTime);

            var newToken = (new
            {
                token = token,
                timeOut_in = hoursForExpiration * 60 * 60
            });

            return Ok(newToken);
        }
    }
}
