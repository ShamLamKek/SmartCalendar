using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SmartCalendar.Commands;
using SmartCalendar.Commands.GetDays;
using SmartCalendar.Controllers;
using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SmartCalendar
{
    class Program
    {
        public static TelegramBotClient client;
        public static List<Command> comands;
        static void Main(string[] args)
        {
            comands = new List<Command>() { new GetMyTimeTable(),
                                            new GetMonday(),    
                                            new GetTuesday(), 
                                            new GetWednesday(),
                                            new GetThursday(),
                                            new GetFriday(),
                                            new GetSaturday()
                                            };

            client = new TelegramBotClient("1602590774:AAGcAcmV9fdnJzYy5r9633gwcGY6twfiuho");
            client.StartReceiving();
            Console.WriteLine("[Log]: Bot started");
            client.OnMessage += Bot_onMessage;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static void Bot_onMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message.Text != null)
            {
                foreach (var comm in comands)
                {
                    if (comm.Contains(message.Text))
                    {
                        comm.Execute(message, client);
                    }
                }
            }
        }
    }
}  

    

