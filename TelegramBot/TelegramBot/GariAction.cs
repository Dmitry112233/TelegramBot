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
        private  string dollar;
        private  string cocs;
        private  string heroin;
        private  string nark;

        public GariAction()
        {
            dollar = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                     "\\resources\\dollar.jpg";
            cocs = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                   "\\resources\\cocs.png";
            heroin = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                     "\\resources\\heroin.jpg";
            nark = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                   "\\resources\\nark.png";
        }

        public async void Snuff(MessageEventArgs e)
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

        public async void MakeHero(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(heroin, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
            
            Thread.Sleep(1000);
            
            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "КОНГРАТИЛЕЙШНС, ТЫ ВЫЙГРАЛ НО СЛУЧАЙНО УМЕР!");
        }

        public async void SendCharacterPhoto(MessageEventArgs e)
        {
            Thread.Sleep(1000);
            
            using (var fileStream = new FileStream(nark, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream);
            }
        }

        public async void ChooseHowToHigh(MessageEventArgs e)
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