using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetTrends
{
    class Tweet
    {
        String longitude;
        String latitude;
        String date;
        String context;
        String location;
        Double averageSentiment;
        public Tweet(String longitude,String latitude,String date, String context)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.date = date;
            this.context = context;
        }
        
    }
}
