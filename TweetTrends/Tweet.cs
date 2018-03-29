using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TweetTrends
{
    //git remote add origin https://github.com/AndreyMolochko/TweetTrens.git
    //git push -u origin master
    class Tweet
    {
        public String longitude;
        public String latitude;
        String date;
        public String context;
        public String location;
        public double averageSentiment;
        public Tweet(String longitude,String latitude,String date, String context)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.date = date;
            this.context = context;
        }
    }
}
