using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class MainAction : BaseAction
    {
        
        public async void SendMessage(MessageEventArgs e, string message)
        {
            Thread.Sleep(1000);
            await  Bot.SendTextMessageAsync(e.Message.Chat.Id, message);
        }

        public void ChangeHandler(EventHandler<MessageEventArgs> toDelete,
            EventHandler<Telegram.Bot.Args.MessageEventArgs> toAdd)
        {
            Bot.OnMessage -= toDelete;
            Bot.OnMessage += toAdd;
        }

        public async void StarAgain(MessageEventArgs e)
        {
            Thread.Sleep(2000);
            
            ReplyKeyboardMarkup ReplyKeyboardActionG = new[]
            {
                new[] {"/Play"},
            };
            ReplyKeyboardActionG.OneTimeKeyboard = true;
            await  Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                "ХОЧЕШЬ ЕБАНУТЬ ЕЩЕ РАЗОЧЕК?",
                replyMarkup: ReplyKeyboardActionG);
        }

        public async void ChooseCharacter(MessageEventArgs e)
        {
            ReplyKeyboardMarkup ReplyKeyboardPerosn = new[]
            {
                new[] {"Гари", "Ян"},
                new[] {"Токс", "Макс"},
            };
            await  Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                "ВЫБЕРИ ПЕРСОНАЖА",
                replyMarkup: ReplyKeyboardPerosn);
        }

        public async void DefaultAction(MessageEventArgs e)
        {
            const string usage = @"Usage: /Play  - жми если не пидр";
            await   Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                usage,
                replyMarkup: new ReplyKeyboardRemove());
        }
    }
}