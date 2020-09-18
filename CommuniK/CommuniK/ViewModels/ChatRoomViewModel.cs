using MvvmHelpers;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using CommuniK.Models;
using System.Globalization;
using CommuniK.Helpers;
using System.Threading.Tasks;

namespace CommuniK.ViewModels
{
    public class ChatRoomViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Message> Messages { get; }
        ITwilioMessenger twilioMessenger;
        public string m;
        public int iteration;

        private string _outgoingText;
        private string name;

        public string OutGoingText
        {
            get { return _outgoingText; }
            set
            {
                _outgoingText = value;
                OnPropertyChanged();
            }
        }
        public ICommand SendCommand { get; set; }

        public ChatRoomViewModel(string name)
        {
            // Initialize with default values
            twilioMessenger = DependencyService.Get<ITwilioMessenger>();
            Messages = new ObservableRangeCollection<Message>();
            Greeting(name);
            iteration = 1;

            

            if (twilioMessenger == null)
                return;

            twilioMessenger.MessageAdded = (message) =>
            {
                Messages.Add(message);
            };
        }

        public ICommand SendMessageCommand => new Command(SendMessage);

        public void SendMessage()
        {
            if ((OutGoingText != string.Empty) && (OutGoingText != " ") && (OutGoingText != "\n") && (OutGoingText != "\n\n"))
            {
                var message = new Message
                {
                    Text = OutGoingText,
                    IsIncoming = false,
                    MessageDateTime = DateTime.Now
                };
                Messages.Add(message);
                twilioMessenger?.SendMessage(message.Text);
                m = message.Text;

                if(iteration == 1) { selectAction(m); }
                else if(iteration == 2) { selectDepartment(m); }
                else if(iteration == 3) { sendResponse(m); }
                else if(iteration == 4) { RepeatOrEnd(m, name); }
                else if(iteration == 5) { EndProgram(m); }
            }

            OutGoingText = string.Empty;
        }

        public void Greeting( string name)
        {
            string greet;
            Task.Delay(1000000000);
            DateTime time = DateTime.Now;
            if (time.Hour < 12)
            {
                greet = "Good Morning";
            }
            else if (time.Hour >= 12 && time.Hour < 16)
            {
                greet = "Good Afternoon";
            }
            else if (time.Hour >= 16 && time.Hour < 20)
            {
                greet = "Good Evening";
            }
            else
            {
                greet = "What do you want this night";
            }
            Messages.AddRange(new List<Message>
            {
                new Message{Text = greet + " " + name + "\nWhat would you like me to do for you?\n\n1. Make a Request\n2. Make an Enquiry\n3. Make a complaint", IsIncoming = true, MessageDateTime = DateTime.Now},
            });
        }
        public void selectAction(string inputText)
        {
            Task.Delay(10000);
            string response = "";
            if (inputText == "1" || inputText == "2" || inputText == "3")
            {
                response = "What department will you like me to direct your message to?\n\n1. Human Resource\n2. Admin\n3. Marketing";
                iteration = 2;
            }
            else
            {
                response = "I don't understand this. Please select one of the options:\n\n1. Make a Request\n2. Make an Enquiry\n3. Make a complaint";
                iteration = 1;
            }
            Messages.AddRange(new List<Message>
            {
                new Message{Text = response, IsIncoming = true, MessageDateTime = DateTime.Now},
            });
        }
        public void selectDepartment(string inputText)
        {
            string response = "";
            if (inputText == "1" || inputText == "2" || inputText == "3")
            {
                response = "What message will you want me to deliver?";
                iteration = 3;
            }
            else
            {
                response = "I don't understand this. Please select one of the options:\n\n1. Human Resource\n2. Admin\n3. Marketing";
                iteration = 2;
            }
            Messages.AddRange(new List<Message>
            {
                new Message{Text = response, IsIncoming = true, MessageDateTime = DateTime.Now},
            });
        }
        public void sendResponse(string inputText)
        {
            //send the salamaleku to database
            string response = "Your message has been sent.\nWould you like to do anything else?\n1. Yes\n2. No";
            iteration = 4;
            Messages.AddRange(new List<Message>
            {
                new Message{Text = response, IsIncoming = true, MessageDateTime = DateTime.Now},
            });
        }
        public void RepeatOrEnd(string inputText, string name)
        {
            string response = "";
            if(inputText == "1")
            {
                response = "What would you like me to do for you?\n\n1. Make a Request\n2. Make an Enquiry\n3. Make a complaint";
                iteration = 1;
            }
            else if(inputText == "2")
            {
                response = "Alright" + name + "See you later";
                iteration = 5;
            }
            else
            {
                response = "I don't understand this. Please select one of the options:\n1. Yes\n2. No";
                iteration = 4;
            }
            Messages.AddRange(new List<Message>
            {
                new Message{Text = response, IsIncoming = true, MessageDateTime = DateTime.Now},
            });
        }
        public void EndProgram(string inputText)
        {
            
        }
        public void InitializeMock()
        {
            Messages.ReplaceRange(new List<Message>
                {
                    new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25)},
                    new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24)},
                    new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},

                    new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},

            });
        }
    }
}
