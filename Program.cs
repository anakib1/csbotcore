using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Types.Enums;
namespace Bot_NetCore_
{
    class Program
    {
        static Logik l = new Logik();
        static void Main(string[] args)
        {
            // token, который вернул BotFather
            l.Start();
        }
        
    }
    class Logik
    {
        Translate tr = new Translate();
        //Miner mr = new Miner();
        bot.Stocks sr = new bot.Stocks();
        public int number { get; set; } = 0;
        private static TelegramBotClient Bot;
        public void Start()
        {
            
                Bot = new TelegramBotClient(config.key);
                Bot.OnMessage += BotOnMessageReceived;
                Bot.OnMessageEdited += BotOnMessageReceived;
                Bot.StartReceiving();
            
            Console.ReadLine();
            Bot.StopReceiving();
        }
        bool IsAllUpper(string input)
        {
            string a = "йцукенгшщзхъэждлорпавыфячсмитьбюё ".ToUpper();
            foreach(char c in input)
            {
                if(!a.Contains(c)||c.ToString()!=c.ToString().ToUpper())
                {
                    return false;
                }
            }
           
            return true;
        }
        double DegreesToRadian(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        
        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            if(DateTime.Now.Minute%2==0&&DateTime.Now.Second==0)
            {
                number = 0;
            }
            var message = messageEventArgs.Message;
            
            if (message.From.Username=="pauchok1love")
            {

                if(message.Type==MessageType.StickerMessage)
                {

                    var res = message.Sticker.FileId;
                    if(res!=null)
                    await Bot.SendTextMessageAsync(message.Chat.Id, res.ToString());
                    else
                        await Bot.SendTextMessageAsync(message.Chat.Id, "null(");

                }
                if (message.Type == MessageType.DocumentMessage)
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id, message.Document.FileId);
                }
                if (message.Type == MessageType.TextMessage)
                {
                    /*
                    if(message.Text.Contains("/strike"))
                    {
                        string res = "<s>"+message.Text.Substring(message.Text.IndexOf('e') + 1)+"</s>";
                        await Bot.SendTextMessageAsync(message.Chat.Id, res,ParseMode.Html);

                    }*/
                    if (message.Text.Contains("/voteban") && message.ReplyToMessage != null)
                    {
                        try
                        {
                            string[][] text = new string[][]
                               {
                                   new string[] { "Сколько можно баловатся вотебаном??", "Сегодня прописиваем п*зды .."," Вы попали под разадчу!"," ","итак, вы будуте репрессированы на "," минут. Старайтесь не злить одменов!","пойду дальше спать..."},
                                   new string[] { "ГДЕ АНИМЕ! ЧТО АНИМЕ! КОГО ИЗБИТЬ?!", "Ищем врага народа.... Ищем, скипаем генезиса,...", "ПОКАЙСЯ И ВЕРЬ В ЭПОЛ! ", "ДУМАЕМ, ШО С ТОБОЙ ДЕЛАТЬ","Ты будешь  избит макбуком с ай9 на ", " минут. И больше не слова плохого про эпл чтоб я не слышал!", "Пошел писать доклад Тиму Куку.." },
                                   new string[] { "ВОТЕБАН 23.324_final_2_tochnofinal(3) ЗАПУЩЕН! ", " ПОШУК ПОРУШНИКА РОЗПОЧАТО! ", " ТИ КЛЯТИЙ ПОРУШНИК(МОСКАЛЬ)!", "Выбор меры присечения ..... ", " Вы будете забанены на ", " минут! Більше не порушуйте!!", "СИСТЕМА ВЫКЛЮЧАЕТСЯ ДО СЛЕДУЮЩЕГО НАРУШЕНИЯ..." }
                               };

                            int typeofanswer = new Random().Next(0, text.Length);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][0]);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][1] + message.ReplyToMessage.From.FirstName + " " + message.ReplyToMessage.From.LastName + "( @" + message.ReplyToMessage.From.Username + " )" + text[typeofanswer][2]);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][3]);
                            int time = new Random().Next(1, 11);
                            if (new Random().Next(0, 3) >= 1)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][4] + time + text[typeofanswer][5], replyToMessageId: message.ReplyToMessage.MessageId);
                                DateTime now = DateTime.Now;
                                now =now.AddMinutes(time);
                                now = now.AddHours(3);
                                Console.WriteLine(DateTime.Now.ToString() + " " + now.ToString());
                                await Bot.RestrictChatMemberAsync(message.Chat.Id, message.ReplyToMessage.From.Id,now);
                                FileToSend f = new FileToSend("https://i.imgur.com/O3DHIA5.gif");
                                await Bot.SendDocumentAsync(message.Chat.Id, f);
                                Thread.Sleep(time * 60 * 1000);
                                await Bot.RestrictChatMemberAsync(message.Chat.Id, message.ReplyToMessage.From.Id, DateTime.Now, true, true, true, true);
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "сегодня вам повезло и вы можете жить дальше! Но больше не нарушайте!");

                            }
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][6]);
                            

                        }
                        catch (Exception banE)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "О нет! что-то пошло не так(( " + banE.Message);
                        }
                    }
                }
                if(message.Type==MessageType.LocationMessage)
                {
                    var location = message.Location;
                    var earthRadiusKm = 6371;

                    var dLat = DegreesToRadian(location.Latitude - 50.458205);
                    var dLon = DegreesToRadian(location.Longitude - 30.363090);
                    location.Latitude = (float)DegreesToRadian(location.Latitude);
                    float klat = (float)DegreesToRadian(50.458205);

                    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                            Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(location.Latitude) * Math.Cos(klat);
                    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                    var res= earthRadiusKm * c;
                    res = Math.Round(res, 3);
                    await Bot.SendTextMessageAsync(message.Chat.Id, "you need to go: <strong>"+ res.ToString()+"</strong> km, to get to Kiev",ParseMode.Html);
                }
            }
            if (message?.Type == MessageType.TextMessage)
            {
                string[] _message = message.Text.Split(' ');
                if (IsAllUpper(message.Text))
                {
                                    FileToSend[] s = { new Telegram.Bot.Types.FileToSend("CAADAgADtgAD0QABxA2mtwKzCy1LuAI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADnQAD0QABxA0qCVaPhb0-swI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADnwAD0QABxA1K-2P5V_m8CgI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADdQAD0QABxA2IN-acF43gnAI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgAD3gAD0QABxA0yIvltTN4SGwI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgAD0AAD0QABxA2Q_Jdgq9bU5QI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADzgAD0QABxA0aLVE26vv6JQI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADdAAD0QABxA1jcJHFbFDvIQI"),
                                    new Telegram.Bot.Types.FileToSend("CAADAgADzwAD0QABxA21rcb257ePPwI"),
                                };
                    Random random = new Random();
                    if(number<100)
                    await Bot.SendStickerAsync(message.Chat.Id, s[random.Next(0, s.Length)], replyToMessageId: message.MessageId);
                }
                if(message.Text.Contains("/voteban")&&message.From.Username!="pauchok1love" && message.ReplyToMessage != null)
                {
                    if(message.From.Username=="dankavol"||message.From.Username=="autodestructi0n"||message.From.Username=="Booster_pack")
                    {
                        try
                        {
                            string[][] text = new string[][]
                                {
                                   new string[] { "Сколько можно баловатся вотебаном??", "Сегодня прописиваем п*зды .."," Вы попали под разадчу!"," ","итак, вы будуте репрессированы на "," минут. Старайтесь не злить одменов!","пойду дальше спать..."},
                                   new string[] { "ГДЕ АНИМЕ! ЧТО АНИМЕ! КОГО ИЗБИТЬ?!", "Ищем врага народа.... Ищем, скипаем генезиса,...", "ПОКАЙСЯ И ВЕРЬ В ЭПОЛ! ", "ДУМАЕМ, ШО С ТОБОЙ ДЕЛАТЬ","Ты будешь  избит макбуком с ай9 на ", " минут. И больше не слова плохого про эпл чтоб я не слышал!", "Пошел писать доклад Тиму Куку.." },
                                   new string[] { "ВОТЕБАН 23.324_final_2_tochnofinal(3) ЗАПУЩЕН! ", " ПОШУК ПОРУШНИКА РОЗПОЧАТО! ", " ТИ КЛЯТИЙ ПОРУШНИК(МОСКАЛЬ)!", "Выбор меры присечения ..... ", " Вы будете забанены на ", " минут! Більше не порушуйте!!", "СИСТЕМА ВЫКЛЮЧАЕТСЯ ДО СЛЕДУЮЩЕГО НАРУШЕНИЯ..." }
                                };

                            int typeofanswer = new Random().Next(0, text.Length);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][0]);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][1] + message.ReplyToMessage.From.FirstName + " " + message.ReplyToMessage.From.LastName + "( @" + message.ReplyToMessage.From.Username + " )" + text[typeofanswer][2]);
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][3]);
                            int time = new Random().Next(1, 11);
                            if (new Random().Next(0, 3) >= 1)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][4] + time + text[typeofanswer][5], replyToMessageId: message.ReplyToMessage.MessageId);
                                DateTime now = DateTime.Now;
                                now = now.AddMinutes(time);
                                now = now.AddHours(3);
                                Console.WriteLine(DateTime.Now.ToString() + " " + now.ToString());
                                await Bot.RestrictChatMemberAsync(message.Chat.Id, message.ReplyToMessage.From.Id, now);
                                FileToSend f = new FileToSend("https://i.imgur.com/O3DHIA5.gif");
                                await Bot.SendDocumentAsync(message.Chat.Id, f);
                                Thread.Sleep(time * 60 * 1000);
                                await Bot.RestrictChatMemberAsync(message.Chat.Id, message.ReplyToMessage.From.Id, DateTime.Now, true, true, true, true);
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "сегодня вам повезло и вы можете жить дальше! Но больше не нарушайте!");

                            }
                            await Bot.SendTextMessageAsync(message.Chat.Id, text[typeofanswer][6]);



                        }
                        catch (Exception banE)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "О нет! что-то пошло не так(( " + banE.Message);
                        }
                    }
                    else
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Ні! Ти не можеш цього робити! Ти не Одмін!", replyToMessageId: message.MessageId);
                    }
                }
                if(message.Text.Contains("/getprice"))
                {
                    try
                    {
                        if (message.Text.Split(' ').Length != 2)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "error, invalid syntax (code S0)");
                        }
                        else
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, sr.GetAvg(message.Text.Split(' ')[1]));
                        }
                    }
                    catch(Exception StockE)
                    {
                        if(!StockE.Message.Contains("phone_number"))
                            await Bot.SendTextMessageAsync(message.Chat.Id, "error, invalid syntax (code S1) "+StockE.Message);
                    }
                    
                }
                if(message.Text=="/gethash")
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id, sr.GetDif("ETH"));
                }
                if(message.Text.Contains("/trns"))
                {
                    try
                    {
                        if (message.ReplyToMessage.Text != null)
                        {
                            string res = "";
                            string[] tmp = message.ReplyToMessage.Text.Split(' ');
                            foreach(string w in tmp)
                            try
                            {
                                    if (tr.tr(w)!="хуюля")
                                    {
                                        res += tr.tr(w) + " ";
                                    }
                            }
                            catch (Exception TranslateE)
                            {
                                Console.WriteLine(TranslateE.Message);
                            }
                            await Bot.SendTextMessageAsync(message.Chat.Id, res);
                        }
                    }
                    catch(Exception)
                    {
                        if (_message.Length == 2)
                        {
                            try
                            {
                                if (tr.tr(_message[1])!="хуюля")
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, tr.tr(_message[1]));
                                }
                            }
                            catch (Exception TranslateE)
                            {
                                Console.WriteLine(TranslateE.Message);
                            }
                        }
                    }
                    
                    try
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                    }
                    catch(Exception deleteE)
                    {
                        Console.WriteLine(deleteE.Message);
                    }
                    
                }
                /*
                if(message.Text.Contains("/reg"))
                {
                    try
                    {
                        mr.AddPlayer(message.From.Username);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "вы в игре!");
                    }
                    catch(Exception registerE)
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, " some error occused");
                        Console.WriteLine(registerE.Message);
                    }
                }
                if(message.Text.Contains("/exit"))
                {
                    try
                    {
                        mr.DelPlayer(message.From.Username);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "вы свалили(");
                    }
                    catch (Exception registerE)
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, " some error occused");
                        Console.WriteLine(registerE.Message);
                    }
                }
                if(message.Text.Contains("/getminer"))
                {
                    try
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, "@"+mr.GetMinerOfDay());
                    }
                    catch(Exception MinerE)
                    {
                        Console.WriteLine(MinerE.Message);
                    }
                }
                */
            }
        }
    }
}
