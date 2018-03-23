using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetTrends
{
    class Parsing
    {
        String filenameStates="states.json";
        String dataJson = "";
        //String str;
        public State state;
        List<Coordinates> coordinats;

        public Parsing()
        {
            StreamReader reader = new StreamReader(filenameStates, Encoding.Default);
            dataJson = File.ReadAllText(filenameStates);            
            reader.Close();
            coordinats = new List<Coordinates>();
            state = new State();
            AdditionInList();
        }
        public void AdditionInList()
        {
            int i = 0;
            String nameState = "";
            String longitude = "";
            String latitude = "";
            while (i < dataJson.Length)
            {
                if (dataJson[i] == '"' || dataJson[i]=='}') {
                    if (nameState != "")
                    {
                        state.coordinatesState.Add(nameState, new List<Coordinates>(coordinats));
                        nameState = "";
                        coordinats.Clear();
                    }
                    if (dataJson[i] == '}') break;
                    nameState = dataJson[i + 1].ToString() + dataJson[i + 2].ToString();
                    i = i + 4;
                    continue;
                }
                if (dataJson[i] == '[' && dataJson[i + 1] != '[')
                {
                    i++;
                    while (dataJson[i] != ',')
                    {
                        longitude += dataJson[i];
                        i++;
                    }
                    i = i + 2;
                    while (dataJson[i] != ']')
                    {
                        latitude += dataJson[i];
                        i++;
                    }
                    coordinats.Add(new Coordinates(longitude, latitude));
                    longitude = "";
                    latitude = "";
                }
                else i++;
                    
            }
        }
    }
}
