using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Hakaton
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Бот запущен");

            Console.WriteLine("Имя пользователя || Сообщение пользователя || Время отправки ");
            Console.ForegroundColor = ConsoleColor.White;


            var client = new TelegramBotClient("6034554077:AAFAZTEnnZUmdD6t3zs3_txpmfrBOJtHBlc");

            client.StartReceiving(Update, Error);






            Console.ReadKey();
        }


        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token) // update method
        {

            var message = update.Message;
            if (update.Message != null)
            {
                if (message.Text != null)
                {

                    switch (message.Text.ToLower())
                    {
                        case "/start":
                            StartButton("/start");
                            break;
                        case "вернуться🔙":
                            StartButton("Вернуться🔙");
                            break;

                        case "обучение📈":
                            TichButton();
                            break;

                        case "офис и сотрудники👥":
                            OfficAndSotr_Button();
                            break;

                        case "компания и продукты🏬":
                            CompanyButton();
                            break;

                        case "запросить помощь🙏":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Запрос отправлен, ждите ответа.😉");
                            break;

                        case "обязанности📋":
                            Photo("обязанности📋");
                            //  await botClient.SendTextMessageAsync(message.Chat.Id, "Вы вступили к нам в коллектив и теперь вы будете работать над улучшением языка С--. Вашей команде будет приходить запрос на улучшение, доработку, создание новой функции в языке. Затем вы и ваши коллеги должны будете выполнить задание, после нужно будет составить запрос на тест (пример составления запроса есть в меню). Надеемся вам понравится у нас работать.");
                            break;

                        case "адресы почты📨":
                            Photo("адресы почты📨");
                            // await botClient.SendTextMessageAsync(message.Chat.Id, "Вот список адресов почты для связи с отделом тестирования, отдел аналитики, главным менеджером: \nOtdelTest@yandex.ru 📬 \nOtdelAnalit@yandex.ru 📬 \nManager312@yandex.ru 📬");
                            break;

                        case "пример📄":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Оформить запрос очень легко, вам нужно будет заполнить каждый пункт и отправить на почту в отдел тестирования. ✅ \nПример офрмления: \n1️⃣ Цель изменения/разработки \n2️⃣ Что было изменено/добавлено \n3️⃣ Добавочная информация (если она имеется)");
                            break;

                        case "офис🏢":
                            Photo("офис🏢");
                            break;

                        case "коллеги👨‍💼":
                            Photo("коллеги👨‍💼");
                            break;

                        case "адрес офиса🗺️":
                            Photo("адрес офиса🗺️");
                            break;

                        case "продукты компании💼":
                            Photo("продукты компании💼");
                            //await botClient.SendTextMessageAsync(message.Chat.Id, "Наша компания создала и продолжает улучшать язык C--, СУБД SQLS, пакет офисных программ, в него входит текстовый процессор Wort, табличный процессор Essel");
                            break;

                        case "самый популярный продукт💫":
                            Photo("самый популярный продукт💫");
                            //await botClient.SendTextMessageAsync(message.Chat.Id, "Самый популярный продукт нашей компании - это операционная система Окно. Ей пользуются большая часть населения земли. Вышедшие версии: Окно 1, Окно 2, Окно 3");
                            break;

                        case "история компании🏛️":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Наша компания появилась в 2023 году и сразу стала популярной. 👍");
                            break;

                    }
                }
            }



            async void StartButton(string a)
            {
                string[][] strings = new[] {
                new[]{ "Обучение📈","Офис и сотрудники👥"},
                 new[]{ "Компания и продукты🏬", "Запросить помощь🙏" }
                };

                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                if (a == "/start")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\bot.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "bot.jpg"), caption: "🤗🤗🤗 \nЗдравствуйте, я 🤖, который должен помочь 🫵 в обучении своим должностям, знакомству с офисом🏢, коллективом👥 и продукцией нашей компании📋", replyMarkup: keyboardMarkup);
                    // await botClient.SendTextMessageAsync(message.Chat.Id, "🤗🤗🤗 \nЗдравствуйте, я 🤖, который должен помочь 🫵 в обучении своим должностям, знакомству с офисом🏢, коллективом👥 и продукцией нашей компании📋", replyMarkup: keyboardMarkup);
                }
                if (a == "Вернуться🔙")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите то, о чём вам рассказать. 🙂", replyMarkup: keyboardMarkup);
                return;
            }
            async void TichButton()
            {
                string[][] strings = new[]
                {
                    new[]{ "Обязанности📋", "Адресы почты📨" },
                    new[]{ "Пример📄", "Вернуться🔙" }
                };
                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Позвольте объяснить вам задачи которые вы будете выполнять и полезную в дальнейшем информацию", replyMarkup: keyboardMarkup);
            }

            async void OfficAndSotr_Button()
            {
                string[][] strings = new[] {
                new[]{ "Офис🏢", "Коллеги👨‍💼"},
                 new[]{ "Адрес офиса🗺️", "Вернуться🔙" }
                };

                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Для успешной работы, нужно знать где и с кем работаешь.", replyMarkup: keyboardMarkup);


                return;
            }

            async void CompanyButton()
            {
                string[][] strings = new[]
                {
                    new[]{ "Продукты компании💼", "Самый популярный продукт💫"},
                    new[]{ "История компании🏛️", "Вернуться🔙" }
                };
                ReplyKeyboardMarkup keyboardMarkup = strings;
                keyboardMarkup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Давайте расскажу вам о нашей компании.", replyMarkup: keyboardMarkup);
                return;
            }
            async void Photo(string a)
            {
                if (a == "офис🏢")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1Offis\RabMesto.png");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "RabMesto.png"), caption: "Вы можете взять свой ноутбук и работать в любом месте просторного офиса. В случае отсутствия ноутбука, мы можем его выдать.");

                    await using Stream stream1 = System.IO.File.OpenRead(@"Resurses1\Offis\Relax.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream1, fileName: "Relax.jpg"), caption: "После выполнения сложного проекта нужно раслабиться, отдохнуть и привести мысли в порядок. Для этого у нас есть комнаты отдыха.");

                    await using Stream stream2 = System.IO.File.OpenRead(@"Resurses1\Offis\Sbor.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream2, fileName: "Sbor.jpg"), caption: "Также у нас имеются комнаты для общих собраний и переговоров о дальнейшом ходе действий, направлениях развития и постановления чётких задач.");

                    await using Stream stream3 = System.IO.File.OpenRead(@"Resurses1\Offis\Kitchen.png");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream3, fileName: "Kitchen.png"), caption: "Если вы сильно проголодались, то можете в любой момент придти и уталить свой голод.");
                }

                if (a == "коллеги👨‍💼")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Piple\ocr1.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "ocr1.jpg"), caption: "Коментарий:\"Привет я главый контент менаджер нашей компании \"");

                    await using Stream stream1 = System.IO.File.OpenRead(@"Resurses1\Piple\ocr2.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream1, fileName: "ocr1.jpg"), caption: "Коментарий:\"Привет я главный системный админестратор \"");

                    await using Stream stream2 = System.IO.File.OpenRead(@"Resurses1\Piple\ocr3.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream2, fileName: "ocr3.jpg"), caption: "Коментарий:\"Привет я fullStak разработчик \"");

                }
                if (a == "адрес офиса🗺️")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Offis\Adres.png");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "Adres.png"), caption: "Офис в БЦ \"Бенуа\"");
                }
                if (a == "обязанности📋")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Product\C--.png");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "Adres.png"), caption: "Вы вступили к нам в коллектив и теперь вы будете работать над улучшением языка С--. 🛠️ \nВашей команде будет приходить запрос на улучшение, доработку, создание новой функции в языке. Затем вы и ваши коллеги должны будете выполнить задание, после нужно будет составить запрос на тест (пример составления запроса есть в меню). 📝 \nНадеемся вам понравится у нас работать. 😘");
                }
                if (a == "адресы почты📨")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Product\Mail.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "Adres.png"), caption: "Вот список адресов почты для связи с отделом тестирования, отдел аналитики, главным менеджером: \nOtdelTest@yandex.ru 📬 \nOtdelAnalit@yandex.ru 📬 \nManager312@yandex.ru 📬");
                }
                if (a == "продукты компании💼")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Product\Products.jpg");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "Products.jpg"), caption: "Наша компания создала и продолжает улучшать язык C--, СУБД SQLS Server 💾, пакет офисных программ, в него входит текстовый процессор Wort 📝, табличный процессор Exccel 📊");
                }
                if (a == "самый популярный продукт💫")
                {
                    await using Stream stream = System.IO.File.OpenRead(@"Resurses1\Product\Wind.png");
                    await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(stream, fileName: "Adres.png"), caption: "Самый популярный продукт нашей компании - это операционная система Форточка.🖥️ Ей пользуются большая часть населения земли.🌏 Вышедшие версии: Форточка 10, Форточка 11, Форточка 12");
                }
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}