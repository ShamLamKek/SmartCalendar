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
    public class GetThursday : Command
    {
        public override string[] Names { get; set; } = new string[] {"Четверг", "четверг", "ЧЕТВЕРГ"};

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Models.Day Day = new Models.Day();
            IWebDriver bs = DayController.Connection();
            DayController.AddToList(bs, Day.TimeID, Day.Time);
            DayController.AddToList(bs, Day.LessonID, Day.Lesson);
            DayController.AddToList(bs, Day.ClassroomID, Day.Classroom);
            DayController.AddToList(bs, Day.TeacherID, Day.Teacher);
            DayController.Difference(bs, Day.DayID, Day.daysStart, Day.daysEnd);
            DayController.AddToListOdd(bs, Day.OddID, Day.odd, Day.even);
            bool odd = DayController.Odd(bs);
            string mes = null;
            for (int i = Day.daysStart[3]; i <= Day.daysEnd[3]; i++)
            {
                if (odd == true)
                {
                    if (Day.odd.Exists(x => x == i))
                        continue;
                    else
                    {
                        mes += Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i] + "\n";
                    }
                }
                else
                {
                    if (Day.even.Exists(x => x == i))
                        continue;
                    else
                    {
                        mes += Day.Time[i] + " " + Day.Lesson[i] + " " + Day.Classroom[i] + " " + Day.Teacher[i] + "\n";
                    }

                }
            }
            if (mes != null)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Четверг:\n" + mes);
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Поздравляю! У вас сегодня нет пар, отдыхайте :)");
            }
        }
    }
}
