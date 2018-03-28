﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweetTrends
{
    class Data
    {
        public List<String> tweetsWithData;
        public List<Tweet> tweets;
        public Parsing parsing;
        public Data(String filenameTweets)
        {
            tweetsWithData = new List<String>();
            tweets = new List<Tweet>();
            parsing = new Parsing();
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
        public void SetLocationTweets()
        {
            float longit;
            float latit;
            float longitTweet;
            float latitTweet;
            bool flag = false;
            List<PointF> a = new List<PointF>();
            for (int k = 0; k < tweets.Count; k++)
            {
                flag = false;
                longitTweet = float.Parse(tweets[k].longitude.Replace(".", ","));
                latitTweet = float.Parse(tweets[k].latitude.Replace(".", ","));
                tweets[k].location = "";
                for (int i = 0; i < parsing.state.coordinatesState.Count; i++)
                {
                    if (flag) break;
                    for (int j = 0; j < parsing.state.coordinatesState.ElementAt(i).Value.Count; j++)
                    {
                        if (flag) break;
                        for (int z = 0; z < parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).Count; z++)
                        {
                            longit = float.Parse(parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).longitude.Replace(".", ","));
                            latit = float.Parse(parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).latitude.Replace(".", ","));
                            a.Add(new PointF(longit, latit));
                            if (flag) break;
                        }
                        PointF[] ab = a.ToArray();
                        GraphicsPath graphicsPath = new GraphicsPath();
                        graphicsPath.AddPolygon(ab);
                        if (graphicsPath.IsVisible(new PointF(latitTweet, longitTweet))) {
                            tweets[k].location = parsing.state.coordinatesState.ElementAt(i).Key;
                            flag = true;
                            break;                            
                        }                                         
                        a.Clear();
                    }
                }
            }
        }
    }
}
