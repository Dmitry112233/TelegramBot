using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(SecretKey.API_KEY);

        private static void Main(string[] args)
        {
            BaseAction.Bot = Bot;
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.ReadLine();
            Bot.StopReceiving();
        }
        
        public static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("/Play"))
            {
                new MainAction().ChooseCharacter(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Гари"))
            {
                new MainAction().SendMessage(e, "ПОЗДРАВЛЯЮ, ТЕПЕРЬ ТЫ НАРК!");

                new GariAction().SendCharacterPhoto(e);

                new GariAction().ChooseHowToHigh(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Понюхать"))
            {
                new MainAction().SendMessage(e, "ДЕРЖИ БРАТИШКА");

                new GariAction().Snuff(e);

                new MainAction().StarAgain(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Завариться"))
            {
                new MainAction().SendMessage(e, "ДЕРЖИ БРАТИШКА");

                new GariAction().MakeHero(e);

                new MainAction().StarAgain(e);
            }
            else
            {
                new MainAction().DefaultAction(e);
            }
        }
    }
}