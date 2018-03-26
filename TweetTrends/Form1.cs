using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweetTrends
{
    public partial class Form1 : Form
    {
        Data data;
        Sentiments sentiments;
        public Form1()
        {
            InitializeComponent();
            data = new Data("my_life.txt");
            sentiments = new Sentiments("sentiments.csv");

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //data = new Data("my_life.txt");
            // = data.tweetsWithData[0];
            //Sentiments sentiments = new Sentiments("sentiments.csv");
            //List<Coordinates> test = new List<Coordinates>();
            //label1.Text=sentiments.getAverageSentiment(data.tweets[0].context).ToString();
            label1.Text = data.parsing.state.coordinatesState.ElementAt(0).Value.ElementAt(1).ElementAt(0).latitude.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String jsonn = "";
            State state = new State();
            Newtonsoft.Json.JsonConvert.PopulateObject(textBox1.Text, state);
            //MessageBox.Show(state.allStates.ContainsKey("WA").ToString());
            //MessageBox.Show(state.WA.Count.ToString());
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            float longit;
            float latit;
            List<PointF> a = new List<PointF>();
            //for (int i = 0; i < data.parsing.state.coordinatesState.Count; i++)
            //{
            //    for (int j = 0; j < data.parsing.state.coordinatesState.ElementAt(i).Value.Count; j++)
            //    {
            //        for (int z = 0; z < data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).Count; z++)
            //        {
            //            longit = float.Parse(data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).longitude.Replace(".", ","));
            //            latit = float.Parse(data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).latitude.Replace(".", ","));
            //            a.Add(new PointF(longit, latit));
            //        }
            //    }
            //}
            //a.Add(new PointF(-124.1f, 47.2f));
            //a.Add(new PointF(-160.1f, 71.2f));
            Graphics graphics = e.Graphics;
            //graphics.RotateTransform(-90);
            for (int z = 0; z < data.parsing.state.coordinatesState.ElementAt(0).Value.ElementAt(0).Count; z++)
            {
                longit = float.Parse(data.parsing.state.coordinatesState.ElementAt(0).Value.ElementAt(0).ElementAt(z).longitude.Replace(".", ","));
                latit = float.Parse(data.parsing.state.coordinatesState.ElementAt(0).Value.ElementAt(0).ElementAt(z).latitude.Replace(".", ","));
                a.Add(new PointF(longit, latit));
            }

            graphics.ScaleTransform(9f, 9F);
            Pen pen = new Pen(Color.Red, 0.1F);  
            
            PointF[] ab = a.ToArray();
            for(int i=0;i<ab.Length;i++)
            {

                ab[i].X += 220;
                //ab[i].Y += ; 
            }
            //Point[] a = { new Point(100, 100), new Point(400, 200) };            
            graphics.DrawPolygon(pen, ab);
            graphics.Dispose();
        }
    }
}
