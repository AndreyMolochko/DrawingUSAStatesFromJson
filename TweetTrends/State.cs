using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TweetTrends
{
    class State
    {
        
        //public List<List<List<List<double>>>> WA { get; set; }
        public Dictionary<String,List<List<List<List<double>>>>> allStates;
        public State()
        {
            //WA = new List<List<List<List<double>>>>();
            allStates = new Dictionary<string, List<List<List<List<double>>>>>();
            //allStates.Add("WA", WA);
            //allStates.Add("WA", WA);
        }
    }
    
}
