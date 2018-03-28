using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TweetTrends
{
    class State
    {

        public Dictionary<String, List<List<Coordinates>>> coordinatesState;
        List<GraphicsPath> graphicsPath;
        double averageSentiment;
        public State()
        {
            coordinatesState = new Dictionary<string, List<List<Coordinates>>>();
            graphicsPath = new List<GraphicsPath>();
        }
        public void SetAverageSentiment(double averageSentiment)
        {
            this.averageSentiment = averageSentiment;
        }
        
        public double GetAverageSentiment()
        {
            return averageSentiment;
        }

        public void AddGraphicsPath(PointF[]points,int i)
        {
            graphicsPath.Add(new GraphicsPath());
            graphicsPath[i].AddPolygon(points);
        }
        
    }
    
}
