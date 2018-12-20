using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensDel2.Models;
using DemensDel2.Models.Account;
using DemensDel2API.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemensDel2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DemensDbContext _db;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DemensDbContext db)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _db = db;
        }
        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = registration.EmailAddress,
                    UserName = registration.EmailAddress
                };

                var result = await _userManager.CreateAsync(user, registration.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Bruger");

                    User newUser = new User() { UserIdentityID = user.Id };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();

                    return RedirectToAction("Home", "Profile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(registration);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
