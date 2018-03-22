using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetTrends
{
    class Sentiments
    {
        List<String> dataSentiments;
        Dictionary<String, double> sentis;
        List<String> tweetWords;
        public Sentiments(String filenameSentiments)
        {
            dataSentiments = new List<string>();
            StreamReader reader = new StreamReader(filenameSentiments, Encoding.Default);
            dataSentiments.AddRange(System.IO.File.ReadAllLines(filenameSentiments));
            sentis = new Dictionary<String, double>(dataSentiments.Count);
            ParseDataSentiments();
            tweetWords = new List<string>();
            reader.Close();
        }
        public void ParseDataSentiments()
        {
            String[] wordAndNumber = new String[2];
            String amount="";
            for(int i = 0; i < dataSentiments.Count; i++)
            {
                wordAndNumber=dataSentiments[i].Split(',');
                amount=wordAndNumber[1].Replace('.', ',');
                sentis.Add(wordAndNumber[0], Convert.ToDouble(amount));
            }
        }
        public double getAverageSentiment(String words)
        {
            string str = " "+words+" ";
            double answer = 0;
            for (int i = 0; i < sentis.Count; i++)
            {
                if (str.Contains(sentis.ElementAt(i).Key))
                {
                    if (str[str.IndexOf(sentis.ElementAt(i).Key) - 1] == ' '  && str[str.IndexOf(sentis.ElementAt(i).Key) + sentis.ElementAt(i).Key.Length] ==' ')
                        answer += sentis.ElementAt(i).Value;
                }
            }
            //double value;
            //str.Replace(',', ' ');
            //str.Replace('.', ' ');
            //str.Replace(',', ' ');
            //tweetWords.AddRange(str.Split(' '));

            //for(int i = 0; i < tweetWords.Count; i++)
            //{
            //    if(sentis.TryGetValue(tweetWords[i],out value))
            //    {
            //        answer += value;
            //    }
            //}
            return answer;
        }
    }
}
