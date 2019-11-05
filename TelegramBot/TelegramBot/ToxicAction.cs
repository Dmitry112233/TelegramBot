using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class ToxicAction : BaseAction
    {
        
        private static string boyarin;
        private static string bitch;
        private static string animal;
        private static string fatwoman;
        private static string gays;
        private static string friends;
        private static string fork;
        private static string shoes;
        private static string istrumental;
        private static string brother;
        
        
        static ToxicAction()
        {
            boyarin = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\boyarin.jpg";
            bitch = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                      "\\TelegramBot\\resources\\bitch.jpg";
            animal = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                    "\\TelegramBot\\resources\\animal.jpg";
            fatwoman = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\fatwoman.jpg";
            gays = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\gays.png";
            friends = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\friends.jpg";
            fork = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\fork.jpg";
            shoes = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\shoes.png";
            istrumental = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\instrumental.jpg";
            brother = Directory.GetParent(Directory.GetCurrentDirectory()).FullName +
                     "\\TelegramBot\\resources\\brother.jpg";
        }
       
        public static async Task StarQuiz(MessageEventArgs e)
        {

            await Bot.SendTextMessageAsync(
                e.Message.Chat.Id, "Добро пожаловать в викторину про тэкса, чтобы " + 
                                   "пройти ее с 1 раза надо хорошо разбираться в бомжах, отличать на вкус стеклоомыватели" +
                                   " и иметь опыт ведения сельского хозяйства");
            
            Thread.Sleep(4000);

            await QuestionOne(e.Message.Chat.Id);
        }

        public static async Task QuestionOne(long id)
        {
            await Bot.SendTextMessageAsync(
                id, "И ТАК ПЕРВЫЙ ВОПРОС!1!! ВЫБЕРИ ГДЕ ОРИДЖИНАЛ ФОТОГРАФИЯ ТЭКСА В ШКАЛКЕ?");
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(boyarin, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Рыжий Боярин");
            }

            Thread.Sleep(2000);

            using (var fileStream = new FileStream(bitch, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Бамжук");
            }
            
            var InlineKeyBoard1 = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Бамжук"),
                    InlineKeyboardButton.WithCallbackData("Рыжий боярин") 
                }
            });

            await Bot.SendTextMessageAsync(id, "Выбери тут", replyMarkup: InlineKeyBoard1);
        }

        public static async Task QuestionTwo(long id)
        {
            await Bot.SendTextMessageAsync(
                id, "И ТАК ВОПРОС ДВА!1!! ВЫБЕРИ С КЕМ ХОЧЕШЬ ПРОВЕСТИ ВЕЧЕР?");
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(animal, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Каза");
            }
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(fatwoman, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Жируня");
            }
            
            var InlineKeyBoard1 = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Каза"),
                    InlineKeyboardButton.WithCallbackData("Жируня") 
                }
            });
            
            await Bot.SendTextMessageAsync(id, "Подсказка, это все таки вечер, а самые важные дела " +
                                                              "не могут ждать до утра", replyMarkup: InlineKeyBoard1);
        }
        
        public static async Task QuestionThree(long id)
        {
            await Bot.SendTextMessageAsync(
                id, "ВОПРОС ТРИ!1!! НАЙДИ КОРЕШЕЙ НА ФОТО?");
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(gays, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Сладкие педики");
            }
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(friends, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Брутальные каскадеры");
            }
            
            var InlineKeyBoard1 = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Сладкие педики"),
                    InlineKeyboardButton.WithCallbackData("Брутальные каскадеры") 
                }
            });
            
            await Bot.SendTextMessageAsync(id, "Это будет просто", replyMarkup: InlineKeyBoard1);
        }
        
        public static async Task QuestionFor(long id)
        {
            await Bot.SendTextMessageAsync(
                id, "ПОСЛЕДНИЙ ВОПРОС И ТЫ СМОЖЕШЬ ПОЗНАТЬ ВСЕ ПОЧАСТИ ПОБЕДЫ!1!! " +
                    "ВЫБЕРИ ОСНОВНОЙ АТРИБУТ: +40% К СКОРОСТИ -4 ИНТЕЛЕКТА?");
            
            Thread.Sleep(4000);

            using (var fileStream = new FileStream(shoes, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Кеды");
            }
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(fork, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Вилка");
            }
            
            var InlineKeyBoard1 = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Кеды"),
                    InlineKeyboardButton.WithCallbackData("Вилка") 
                }
            });
            
            await Bot.SendTextMessageAsync(id, "О - основной", replyMarkup: InlineKeyBoard1);
        }
        
        public static async Task OrderSomeMeal(long id)
        {
            await Bot.SendTextMessageAsync(
                id, "ОООООООЙЙЙ ЛЮЮЮЦ! СТАЛАСЬ САС ПОЧИТЬ ГЛАВНЫЙ ПИИЗ, КРУЦИЦЬ БАРАБАН");
            
            Thread.Sleep(2000);

            using (var fileStream = new FileStream(istrumental, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(id, fileStream, "Ой люц");
            }
            
            Thread.Sleep(1000);

            ReplyKeyboardMarkup ReplyKeyboardActionG = new[]
            {
                new[] {"КРУТИТЬ БАРАБАН"},
            };
            
            ReplyKeyboardActionG.OneTimeKeyboard = true;
            await Bot.SendTextMessageAsync(
                id,
                "Соверши действие",
                replyMarkup: ReplyKeyboardActionG);
        }
        
        public static async Task GetPresent(MessageEventArgs e)
        {

            await Bot.SendTextMessageAsync(
                e.Message.Chat.Id, "СЕКТРААААР САААС НАА БАААРАБААНЕ!! ГЛАВНЫЙ ПРИЗ ЗИЗ, В СТУУДИЮ");
            
            Thread.Sleep(2500);

            using (var fileStream = new FileStream(brother, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await Bot.SendPhotoAsync(e.Message.Chat.Id, fileStream, "БРАААТИИШКААА");
            }
            
            Thread.Sleep(1000);
            
            await Bot.SendTextMessageAsync(
                e.Message.Chat.Id, "КАНЕЦ");
        }
    }
}