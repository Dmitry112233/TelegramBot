using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class GariAction : BaseAction
    {
        private static string dollar;
        private static string cocs;
        private static string heroin;
        private static string nark;

        static GariAction()
        {
            dollar = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\dollar.jpg";
            cocs = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                   "\\TelegramBot\\resources\\cocs.png";
            heroin = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\heroin.jpg";
            nark = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                   "\\TelegramBot\\resources\\nark.png";
        }

        public async static Task Snuff(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(cocs, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
            
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(dollar, FileMode.Open, FileAccess.Read, FileShare.Read))
            { 
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
            
            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "ПРОЖЕБАНА!");
        }

        public async static Task MakeHero(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(heroin, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
            
            Thread.Sleep(1000);
            
            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "КОНГРАТИЛЕЙШНС, ТЫ ВЫЙГРАЛ НО СЛУЧАЙНО УМЕР!");
        }

        public async static Task SendCharacterPhoto(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(nark, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
        }

        public async static Task ChooseHowToHigh(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            ReplyKeyboardMarkup ReplyKeyboardActionG = new[]
            {
                new[] {"Понюхать", "Завариться"},
            };
            ReplyKeyboardActionG.OneTimeKeyboard = true;
            await Bot.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Соверши действие",
                replyMarkup: ReplyKeyboardActionG);
        }
    }
}