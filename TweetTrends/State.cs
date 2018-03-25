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

        public Dictionary<String, List<List<Coordinates>>> coordinatesState;
        public State()
        {
            coordinatesState = new Dictionary<string, List<List<Coordinates>>>();
        }
    }
    
}
