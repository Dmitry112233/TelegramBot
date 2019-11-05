using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class MainAction : BaseAction
    {

        

        public async static Task SendMessage(MessageEventArgs e, string message)
        {
            Thread.Sleep(1000);
            await  Bot.SendTextMessageAsync(e.Message.Chat.Id, message);
        }
        
        public async static Task SendMessage(long id, string message)
        {
            Thread.Sleep(1000);
            await  Bot.SendTextMessageAsync(id, message);
        }

        public void ChangeHandler(EventHandler<MessageEventArgs> toDelete,
            EventHandler<MessageEventArgs> toAdd)
        {
            Bot.OnMessage -= toDelete;
            Bot.OnMessage += toAdd;
        }

        public async static Task StarAgain(MessageEventArgs e)
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

        public async static Task ChooseCharacter(MessageEventArgs e)
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

        public async static Task DefaultAction(MessageEventArgs e)
        {
            const string usage = @"Usage: /start  - начать квиз";
            await   Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                usage,
                replyMarkup: new ReplyKeyboardRemove());
        }
    }
}