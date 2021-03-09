using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SmartCalendar.Commands;
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
            comands = new List<Command>();
            comands.Add(new GetMyTimeTable());
            client = new TelegramBotClient("1602590774:AAGcAcmV9fdnJzYy5r9633gwcGY6twfiuho");

            client.StartReceiving();
            Console.WriteLine("[Log]: Bot started");
            client.OnMessage += Bot_onMessage;
            Console.ReadLine();

        }

        private async static void Bot_onMessage(object sender, MessageEventArgs e)
        {

            Day Day = new Day();

            IWebDriver bs = DayController.Connection();
            DayController.AddToList(bs, Day.TimeID, Day.Time);
            DayController.AddToList(bs, Day.LessonID, Day.Lesson);
            DayController.AddToList(bs, Day.ClassroomID, Day.Classroom);
            DayController.AddToList(bs, Day.TeacherID, Day.Teacher);
            DayController.Difference(bs, "ContentPlaceHolderArticle_LVrez3_Lweekday_", Day.daysStart, Day.daysEnd);


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


            switch (message.Text)
            {
                case "понедельник":
                    for (int i = Day.daysStart[0]; i <= Day.daysEnd[0]; i++)
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                    }
                    break;
                case "вторник":
                    for (int i = Day.daysStart[1]; i <= Day.daysEnd[1]; i++)
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                    }
                    break;
                case "среда":
                    for (int i = Day.daysStart[2]; i <= Day.daysEnd[2]; i++)
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                    }
                    break;
                case "четверг":
                    for (int i = Day.daysStart[3]; i <= Day.daysEnd[3]; i++)
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                    }
                    break;
                case "пятница":
                    for (int i = Day.daysStart[4]; i <= Day.daysEnd[4]; i++)
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                    }
                    break;
                case "суббота":
                    try
                    {
                        for (int i = Day.daysStart[5]; i <= Day.daysEnd[5]; i++)
                        {

                            await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    break;

            }

        }
    }
}  

    

