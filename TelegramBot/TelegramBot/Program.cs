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
            Bot.OnMessage += Bot_OnQuiz;
            Bot.OnMessageEdited += Bot_OnQuiz;
            Bot.OnCallbackQuery += Bot_OnCallbackQueryReceived;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.ReadLine();
            Bot.StopReceiving();
        }

        public async static void Bot_OnQuiz(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("/start"))
            {
                await ToxicAction.StarQuiz(e);
            }

            else if(e.Message.Type == MessageType.Text && e.Message.Text.Equals("КРУТИТЬ БАРАБАН"))
            {
                await ToxicAction.GetPresent(e);
            }
            else if (e.Message.Type != MessageType.Text && e.Message.Type != MessageType.Photo)
            {
                await MainAction.DefaultAction(e);
            }
            else
            {
                await MainAction.DefaultAction(e);
            }
        }

        public async static void Bot_OnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            var answer = e.CallbackQuery.Data;
            switch (answer)
            {
                case "Рыжий боярин" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "КРАСАВЧЕГ!");
                    await ToxicAction.QuestionTwo(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Жируня" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ТОП, ТАК ДЕРЖАТЬ");
                    await ToxicAction.QuestionThree(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Брутальные каскадеры": await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ЕЕЕС");
                    await ToxicAction.QuestionFor(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Вилка": await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "А ТЫ ШАРИШЬ");
                    await ToxicAction.OrderSomeMeal(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Бамжук" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ПАПРОБУЙ ИЩЁ!");
                    await ToxicAction.QuestionOne(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Каза" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ПАПРОБУЙ ИЩЁ!");
                    await ToxicAction.QuestionTwo(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Сладкие педики" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ПАПРОБУЙ ИЩЁ!");
                    await ToxicAction.QuestionThree(e.CallbackQuery.Message.Chat.Id);
                    break;
                case "Кеды" : await MainAction.SendMessage(e.CallbackQuery.Message.Chat.Id, "ПАПРОБУЙ ИЩЁ!");
                    await ToxicAction.QuestionFor(e.CallbackQuery.Message.Chat.Id);
                    break;
            }
        }

        public async static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("/Play"))
            {
                await MainAction.ChooseCharacter(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Гари"))
            {
                await MainAction.SendMessage(e, "ПОЗДРАВЛЯЮ, ТЕПЕРЬ ТЫ НАРК!");

                await GariAction.SendCharacterPhoto(e);

                await GariAction.ChooseHowToHigh(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Понюхать"))
            {
                await MainAction.SendMessage(e, "ДЕРЖИ БРАТИШКА");

                await GariAction.Snuff(e);

                await MainAction.StarAgain(e);
            }
            else if (e.Message.Type == MessageType.Text && e.Message.Text.Equals("Завариться"))
            {
                await MainAction.SendMessage(e, "ДЕРЖИ БРАТИШКА");

                await GariAction.MakeHero(e);

                await MainAction.StarAgain(e);
            }
        }
    }
}