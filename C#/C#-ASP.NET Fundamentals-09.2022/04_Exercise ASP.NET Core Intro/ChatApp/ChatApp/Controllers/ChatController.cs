using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var newMessage = new ChatViewModel()
            {
                Messages = messages.Select(m => new MessageViewModel
                {
                    Message = m.Value,
                    Sender = m.Key
                }).ToList()
            };

            return View(newMessage);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));

            return RedirectToAction(nameof(Show));
        }
    }
}
