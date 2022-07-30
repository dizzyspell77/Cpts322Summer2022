using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net.Http;

namespace Milestone_2_Progress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FirebaseClient client = new FirebaseClient("https://heymotocarro-1a1d4.firebaseio.com/");
        Graphics G;
        Beacons BeaconsSet;
        Rectangle[] rect = new Rectangle[6];
        Beacons beacons;
        Sensors sensors;

    /*
    public class DrawRectangle
    {
        public Color color { get; set; }
        public float width { get; set; }
        public Rectangle rect { get; set; }
        public Control surface { get; set; }

        public DrawRectangle(Rectangle r, Color c, float w, Control ct)
        {
            color = c;
            width = w;
            rect = r;
            surface = ct;
        }

        public override string ToString()
        {
            return rect.ToString() + " (" + color.ToString() + 
            " - " + width.ToString("0.00") + ") on " + surface.Name;
        }
    }
    */

        private void ParkingLot_Load(object sender, EventArgs e)
        {
            G = this.CreateGraphics();
            sensors = new Sensors(4);
            sensors.data[0].setCoord(0, 5);
            sensors.data[1].setCoord(9, 5);
            sensors.data[2].setCoord(0, 0);
            sensors.data[3].setCoord(9, 0);
        }

        private async void loadBtn_Click_1(object sender, EventArgs e)
        {
            getPopulationAsync();

        }

        //draw parking lot
        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 0);
            SolidBrush myBrush = new SolidBrush(Color.DarkCyan);
            SolidBrush myBrush2 = new SolidBrush(Color.DarkGreen);


            // Create rectangle and Draw rectangle to screen.
            for (int i = 0; i < 6; i++)
            {
                rect[i] = new Rectangle(100 * i, 100, 100, 200);
                G.FillRectangle(myBrush, rect[i]);
                G.DrawRectangle(blackPen, rect[i]);
            }

            //Update parking space rectangle color
            G.FillRectangle(myBrush2, rect[6]);
            G.FillRectangle(myBrush2, rect[9]);

            //draw parking numbers
            for (int i = 0; i < 6; i++)
            {
                DrawStringFloatFormat((i + 1).ToString(), 100 * i + 50, 200.0F);
            }

        }

        private async void getPopulationAsync()
        {
            BeaconsSet = await client
               .Child("Beacons/")//Prospect list
               .OnceSingleAsync<Beacons>();

            onChildChanged();
        }


        private void getBeacons(Beacons beacons)
        {
            foreach (var beacon in beacons.data)
            {
                Console.WriteLine($"beacon id: { beacon.Id} [{ beacon.D1}]");
                Console.WriteLine($"beacon id: { beacon.Id} [{ beacon.D2}]");
                Console.WriteLine($"beacon id: { beacon.Id} [{ beacon.D3}]");
                Console.WriteLine($"beacon id: { beacon.Id} [{ beacon.D4}]");
            }

        }

        private static async Task sendData()
        {
            FormUrlEncodedContent content;
            HttpResponseMessage response;
            HttpClient httpclient = new HttpClient();
            string responseString;
            int companyId = 0;

            var dictionary = new Dictionary<string, string>{
                            { "key","{'occupied':[1,6]}"  },
                            { "companyId",companyId.ToString()}
                        };

            content = new FormUrlEncodedContent(dictionary);
            response = await httpclient.PostAsync("https://us-central1-heymotocarro-1a1d4.cloudfunctions.net/sendData", content);
            responseString = await response.Content.ReadAsStringAsync();
            Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
            //Response message
            Console.WriteLine(data.key);
            Console.WriteLine(data.companyId);
        }


        private void onChildChanged() // Waits for data base to start with variable
        {
            var companyId = 2;
            var child = client.Child("Beacons/data");
            var observable = child.AsObservable<Beacon>();
            var subscription = observable
                .Subscribe( x =>
                {
                    int key = Int32.Parse(x.Key);
                    int index;
                    //beacons.data[int].update


                    BeaconsSet.data[key].Update(x.Object);
                    Point p = BeaconsSet.data[key].getXY(sensors);


                    //get value
                    Console.WriteLine($" value (x, y): {p.x}, {p.y}");



                    //determine which parking slot contains Sensor
                    /*
                     * int i = Int32.Parse(x.key);
                     * int index;
                     * beacons.data[i].update(x.Object);
                     * Point p = beacons.data[i].getXY(sensors);
                     * if (p.y >= 3 && p.y <=5) {add = 0};
                     * if (p.y >= 0 && p.y <= 2) {add = 6};
                     * 
                     * index = (int)Math.Floor(p.x / 1.5) + add;
                     * if (map[i] != index) {
                     *     G.FillRectangle(myBrush, rect[map[i]]);
                     *     G.FillRectangle(myBrush2, rect[index]]);
                     * }
                     * map[i] = index;
                     */


                });

        }
        public void DrawStringFloatFormat(String drawString, float x, float y)
        {


            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            // drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            G.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }


    }
}
