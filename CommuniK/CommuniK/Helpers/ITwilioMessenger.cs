using CommuniK.Models;
using System;
using System.Threading.Tasks;

namespace CommuniK.Helpers
{
    public interface ITwilioMessenger
    {
        Task<bool> InitializeAsync();

        void SendMessage(string text);

        Action<Message> MessageAdded { get; set; }
    }
}
