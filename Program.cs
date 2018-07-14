using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
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
        Miner mr = new Miner();
        bot.Stocks sr = new bot.Stocks();
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
        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message?.Type == MessageType.TextMessage)
            {
                string[] _message = message.Text.Split(' ');
                
                if (message.Text == message.Text.ToUpper() && !message.Text.Contains(".") && !message.Text.Contains("(") && !message.Text.Contains(")") && !message.Text.Contains("+"))
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
                    await Bot.SendStickerAsync(message.Chat.Id, s[random.Next(0, s.Length)], replyToMessageId: message.MessageId);
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
            }
        }
    }
}
