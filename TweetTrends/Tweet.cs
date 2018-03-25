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
        String location;
        Double averageSentiment { get; set; }
        public Tweet(String longitude,String latitude,String date, String context)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.date = date;
            this.context = context;
        }
        
    }
}
