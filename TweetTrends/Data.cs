using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetTrends
{
    class Data
    {
        public List<String> tweetsWithData;
        public List<Tweet> tweets;
        public Data(String filenameTweets)
        {
            tweetsWithData = new List<String>();
            tweets = new List<Tweet>();
            StreamReader reader = new StreamReader(filenameTweets, Encoding.Default);            
            tweetsWithData.AddRange(System.IO.File.ReadAllLines(filenameTweets));            
            reader.Close();
            ParseStringTweets();
        }
        private void ParseStringTweets()
        {
            String longitude="";
            String latitude = "";
            String date = "";
            String context = "";
            for(int i = 0;i < tweetsWithData.Count; i++)
            {
                int position = 0;
                for(int j = 1;tweetsWithData[i][j]!=','; j++)
                {                    
                    longitude += tweetsWithData[i][j];
                    position = j;
                }
                for(int j = position + 2; tweetsWithData[i][j] != ']';j++)
                {
                    latitude += tweetsWithData[i][j];
                    position = j;
                }
                int positionJ = 0;
                for(int j = position + 5; j < position + 24; j++)
                {
                    date += tweetsWithData[i][j];
                    positionJ = j;
                }
                for(int j = positionJ + 2; j<tweetsWithData[i].Length; j++)
                {
                    context += tweetsWithData[i][j];
                }
                tweets.Add(new Tweet(longitude, latitude, date, context));
                longitude = "";
                latitude = "";
                date = "";
                context = "";

            }
        }
    }
}
