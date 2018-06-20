using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
namespace Bot_NetCore_
{
    public class EnCrypt
    {
        public string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();
            while (key.Length < text.Length)
                key = "0" + key;
            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c]));

            return result.ToString();
        }
    }
    //mmc class
    class MMC
    {
        Dictionary<string, int> accounts = new Dictionary<string, int>();

        public void Transfer(string sender, string getter, uint sum)
        {
            if (accounts[sender] >= sum)
            {
                UpdateBalance(sender, Convert.ToInt32(-sum));
                UpdateBalance(getter, Convert.ToInt32(sum));

            }


        }
        public bool HasMMC(string name)
        {
            if (accounts.ContainsKey(name))
                return true;
            else
                return false;
        }
        public void UpdateBalance(string @account, int sum)
        {
            accounts[@account] += sum;
            UpdateFile();
        }
        public void UpdateFile()
        {
            using (StreamWriter sw = new StreamWriter(@"e:\doc\cc\data.mmc"))
            {

                foreach (string account in accounts.Keys)
                {
                    sw.WriteLine(account + " " + accounts[account]);
                }
            }

        }
        public string ViewBalance(string user)
        {
            return accounts[user].ToString();
        }
        public MMC()
        {
            using (StreamReader sr = File.OpenText(@"e:\doc\cc\data.mmc"))
            {

                while (!sr.EndOfStream)
                {
                    string t = sr.ReadLine();
                    accounts[t.Split(' ').ToArray()[0]] = Convert.ToInt32(t.Split(' ').ToArray()[1]);

                }
            }
        }
    }
    //ban class alfa
    public class Ban
    {
        string[] message;
        public void GetMessage(string message)
        {
            this.message = message.Split(' ').ToArray();
        }
        public bool NeedToBan()
        {
            bool res = true;
            int points = 0;
            try
            {
                if (Convert.ToInt32(message[1]) > 0 && Convert.ToInt32(message[1]) < 5)
                {
                    points++;
                }
                if (Convert.ToInt32(message[1]) > 4)
                {
                    points += 3;
                }
            }
            catch (Exception)
            {
                return false;
            }
            if (message[2] == "0")
            {
                points++;
            }
            if (message[3] == "0")
            {
                points++;
            }
            points += Convert.ToInt32(message[4]);
            points += Convert.ToInt32(message[5]) * 5;
            points += Convert.ToInt32(message[6]);
            var rnd = new Random();
            int good_score = rnd.Next(7, 14);
            if (points > good_score)
                res = true;
            else
                res = false;
            return res;
        }
        public string Name()
        {
            try
            {
                return message[7];
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
    //mamkate class

    public class Mamkate
    {

        int time;
        public void GetTime(int time)
        {
            this.time = Convert.ToInt32(Convert.ToDouble(time) / 0.00005);
        }
        public int years()
        {

            return time / 31536000;
        }
        public int days()
        {
            return (time - years() * 31536000) / 86400;
        }
        public int hours()
        {
            return (time - years() * 31536000 - days() * 86400) / 3600;
        }

        public int minutes()
        {
            return (time - years() * 31536000 - days() * 86400 - hours() * 3600) / 60;
        }
        public int seconds()
        {
            return (time - years() * 31536000 - days() * 86400 - hours() * 3600 - minutes() * 60);
        }
        public string Timer()
        {
            string r = " ";
            if (years() != 0)
                r += Convert.ToString(years()) + " years";
            if (days() != 0)
                r += Convert.ToString(days()) + " days";
            if (hours() != 0)
                r += Convert.ToString(hours()) + " hours";
            if (minutes() != 0)
                r += Convert.ToString(minutes()) + " minutes";
            if (seconds() != 0)
                r += Convert.ToString(seconds()) + " seconds";
            return r;
        }
        public string tr(string word)
        {
            string res = word;
            if (res.Length < 2)
            {
                res = "mamka" + res;
                return res;
            }

            while (res.Length < 6)
            {
                res = "0" + res;
            }
            if (res.Contains("i"))
            {
                res = "mamki" + res.Substring(3);
                return res;
            }
            if (res.Contains("e"))
            {
                res = "mamke" + res.Substring(3);
                return res;
            }
            if (res.Contains("o"))
            {
                res = "mamko" + res.Substring(3);
                return res;
            }
            if (res.Contains("ya"))
            {
                res = "mamkia" + res.Substring(3);
                return res;
            }
            if (res.Contains("u") || res.Contains("yu"))
            {
                res = "mamku" + res.Substring(3);
                return res;
            }
            if (res.Contains("a"))
            {
                res = "mamka" + res.Substring(3);
                return res;
            }
            else
            {
                res = "mamka" + res.Substring(3);
                return res;
            }

        }
    }
    //tranlate class
    public class Translate
    {

        public string tr(string word)
        {
            string res = word;
            if (res.Length < 2)
            {
                res = "hui" + res;
                return res;
            }

            while (res.Length < 6)
            {
                res = "0" + res;
            }
            if (res.Contains("i"))
            {
                res = "huy" + res.Substring(3);
                return res;
            }
            if (res.Contains("e"))
            {
                res = "hue" + res.Substring(3);
                return res;
            }
            if (res.Contains("o"))
            {
                res = "huy" + res.Substring(3);
                return res;
            }
            if (res.Contains("ya"))
            {
                res = "huya" + res.Substring(3);
                return res;
            }
            if (res.Contains("u") || res.Contains("yu"))
            {
                res = "huyu" + res.Substring(3);
                return res;
            }
            if (res.Contains("a"))
            {
                res = "huya" + res.Substring(3);
                return res;
            }
            else
            {
                res = "hui" + res.Substring(3);
                return res;
            }

        }
    }
    //zinia class
    public class Zinia
    {
        string[] frases = new string[]
        {
            "И жучок, и паучок это понимают, а ты нет","Опарыш ты опарыш","сейчас почешешь свое правое ухо левой рукой через задницу","Ну тюлень! Один в один!","Кубик-рубик Артурик покатился к доске, а ты покатился нах",
            "А ты, Артурик, у нас один?","Артурик, как ты думаеш, почему я всю ночь не спал?","Дежурные Кододач и Палиенко... О! Тюлень! Иди вытри доску","Богатыри!","Если светит в левый глаз значит едешь на кавказ"
        };
        public string res(Telegram.Bot.Types.Message message)
        {
            string r;
            Random random = new Random();
            int ind = random.Next(0, 11);
            if (ind == 10)
            {
                r = message.From.FirstName.ToString() + " " + message.From.LastName.ToString() + ", ты понимаешь, что ты тянешь наш класс вниз? Из-за таких разгильдяев как ты...";
            }
            else
            {
                r = frases[ind];
            }
            return r;
        }
    }
    //manvelian class
    public class Manvelka
    {
        string[] frases = new string[]
        {
            "Твоя мать - шлюха","Я ебал твою мамку","АНУ МОЛИСЬ СВЯТОЙ МАМКЕ","я нарисую карту на пзде твоей мамке и все будут знать географию","мамке своей это скажешь",
            "ты пишешь такие большие сообщения чтоб компенсировать свой маленький член","мамка","иди нахуй","я твоя мамка","плохая мамка плохая"
        };
        public string res(Telegram.Bot.Types.Message message)
        {
            string r;
            Random random = new Random();
            int ind = random.Next(0, 11);
            if (ind == 10)
            {
                r = message.From.FirstName.ToString() + " " + message.From.LastName.ToString() + ", ты понимаешь, что я ебал твою мать?";
            }
            else
            {
                r = frases[ind];
            }
            return r;
        }
    }
    //math class
    public class Math_1
    {
        long a, b, c;
        long d;
        public string input_message(string message)
        {
            try
            {
                int[] ia = message.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                a = ia[0];
                b = ia[1];
                c = ia[2];
                return "OK";
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        public void x1x2(ref double x1, ref double x2)
        {
            d = (b * b) - (4 * a * c);
            if (d == 0)
            {
                try
                {
                    x1 = (-b) / (2 * a);
                }
                catch (Exception e)
                {
                    x1 = 2.228;
                }

                x2 = 2.228;
            }
            if (d > 0)
            {
                try
                {
                    x1 = (-b + Math.Sqrt(d)) / (2 * a);

                }
                catch (Exception e)
                {
                    x1 = 2.228;
                }
                try
                {
                    x2 = (-b - Math.Sqrt(d)) / (2 * a);
                }
                catch (Exception e)
                {
                    x2 = 2.228;
                }
            }
            if (d < 0)
            {
                x1 = 2.228;
                x2 = 2.228;
            }

        }

    }
}