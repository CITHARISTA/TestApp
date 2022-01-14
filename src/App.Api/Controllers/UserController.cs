using App.Api.Models;
using App.Core.Abstracts;
using App.Core.Models;
using Mapper.Absracts;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] UserVm user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapResult = _mapper.Map<UserVm, User>(user);
            await _userService.PostUserAsync(mapResult);

            return NoContent();
        }
    }
}
