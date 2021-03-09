using OpenQA.Selenium;
using SmartCalendar.Controllers;
using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SmartCalendar.Commands.GetDays
{
    public class GetWednesday : Command
    {
        public override string[] Names { get; set; } = new string[] { "Среда", "среда", "СРЕДА" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Models.Day Day = new Models.Day();
            IWebDriver bs = DayController.Connection();
            DayController.AddToList(bs, Day.TimeID, Day.Time);
            DayController.AddToList(bs, Day.LessonID, Day.Lesson);
            DayController.AddToList(bs, Day.ClassroomID, Day.Classroom);
            DayController.AddToList(bs, Day.TeacherID, Day.Teacher);
            DayController.Difference(bs, Day.DayID, Day.daysStart, Day.daysEnd);
            for (int i = Day.daysStart[2]; i <= Day.daysEnd[2]; i++)
            {

                await client.SendTextMessageAsync(message.Chat.Id, Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i]);
            }
        }
    }
}
