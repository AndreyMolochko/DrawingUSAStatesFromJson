using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            data.SetLocationTweets();
            for (int i = 0; i < data.tweets.Count; i++)
                listBox1.Items.Add(data.tweets[i].location);
            //label2.Text=
            //for(int i=0;)

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
            //String jsonn = "";
            //State state = new State();
            //Newtonsoft.Json.JsonConvert.PopulateObject(textBox1.Text, state);
            //MessageBox.Show(state.allStates.ContainsKey("WA").ToString());
            //MessageBox.Show(state.WA.Count.ToString());
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            float longit;
            float latit;
            Graphics graphics = e.Graphics;
            graphics.ScaleTransform(13F,13F);
            graphics.ScaleTransform(1, -1);
            //graphics.RotateTransform(180);            

            Pen pen = new Pen(Color.Red, 0.1F);
            List<PointF> a = new List<PointF>();
            for (int i = 0; i < data.parsing.state.coordinatesState.Count; i++)
            {
                for (int j = 0; j < data.parsing.state.coordinatesState.ElementAt(i).Value.Count; j++)
                {
                    for (int z = 0; z < data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).Count; z++)
                    {
                        longit = float.Parse(data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).longitude.Replace(".", ","));
                        latit = float.Parse(data.parsing.state.coordinatesState.ElementAt(i).Value.ElementAt(j).ElementAt(z).latitude.Replace(".", ","));
                        a.Add(new PointF(longit, latit));
                    }
                    PointF[] ab = a.ToArray();
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddPolygon(ab);
                    if (graphicsPath.IsVisible(new PointF(-117F, 34F))) label2.Text = data.parsing.state.coordinatesState.ElementAt(i).Key;
                    //data.parsing.state.AddGraphicsPath(ab, 1);                    
                    a.Clear();
                    for (int q = 0; q < ab.Length; q++)
                    {
                        ab[q].X += 150;
                        ab[q].Y -= 60;
                    }
                    graphics.DrawPolygon(pen, ab);
                }
            }
            graphics.Dispose();
        }
    }
}
