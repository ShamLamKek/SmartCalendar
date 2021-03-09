using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SmartCalendar.Commands
{
    public  class GetMyTimeTable : Command
    {
        public override string[] Names { get; set; } = new string[] { "расписание", "мое расписание", "моё расписание" }; 

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Введите день недели:\nПонедельник\nВторник\nСреда\nЧетверг\nПятница\nСуббота");
        }
    }
}
