using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Bot_NetCore_
{
    class Miner
    {
        List<string> players = new List<string>();
        DateTime day;
        string winner="NOWCURWIN";
        public void AddPlayer(string nick)
        {
            if (!players.Contains(nick))
            {
                players.Add(nick);
            }
            else
            {
                throw new System.ArgumentException("player is already in game");
            }
            BackUp();
        }
        public Miner()
        {
            string[] players1=File.ReadAllLines(@"C:\Users\bidzi\Documents\players.txt");
            string[] tmp= File.ReadAllLines(@"C:\Users\bidzi\Documents\curday.txt");
            foreach (string p in players1)
            {
                AddPlayer(p);
            }
            if(tmp.Length==2)
            {
                if(tmp[1]==DateTime.Now.Day.ToString())
                {
                    winner = tmp[0];
                }
                else
                {
                    winner = "NOWCURWIN";
                }
            }
            
        }
        public void DelPlayer(string nick)
        {
            try
            {
                players.Remove(nick);
            }
            catch (Exception RemoveE)
            {
                Console.WriteLine(RemoveE.Message);
            }
            BackUp();
        }
        public string GetMinerOfDay()
        {
            if (winner == "NOWCURWIN")
            {
                Random r = new Random();
                if(players.Count==0)
                {
                    return "no registered players";
                }
                winner = players[r.Next(0, players.Count)];
                BackUp();
                return (winner + " - майнер дня!");
                
            }
            else
            {
                BackUp();
                return winner+" - майнер дня!";
                
            }
        }
        void BackUp()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\bidzi\Documents\players.txt"))
            {
                foreach(string p in players)
                {
                    sw.WriteLine(p);
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\bidzi\Documents\curday.txt"))
            {
                sw.WriteLine(winner);
                sw.WriteLine(DateTime.Now.Day.ToString());
            }
        }
    }
}
