using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private IMessage _message;

        public MessageController(IMessage message)
        {
            _message = message;
        }
        /*
        public string Index()
        {
            return "Welcome to Index page";
        }

        */
        [HttpGet("welcome/{name}")]
        public string Welcome(string name)
        {

            return _message.WriteMessage(name);
        }
        
    }
}
