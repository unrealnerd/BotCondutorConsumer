using System.Threading.Tasks;
using iconic.web.Models;
using iconic.web.Services.BotConductor;
using Microsoft.AspNetCore.Mvc;

namespace iconic.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConversationContext _conversationContext;
        private readonly BotConductorService _service;

        public HomeController(ConversationContext conversationContext, BotConductorService service)
        {
            _conversationContext = conversationContext;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            
            var reply = await _service.SendMessage(message);
            //save the conversation to db
            _conversationContext.Conversations.Add(new Conversation{ Message = message, Reply = reply });
            await _conversationContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}