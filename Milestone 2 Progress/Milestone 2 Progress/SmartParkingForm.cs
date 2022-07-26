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

namespace Milestone_2_Progress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FirebaseClient client = new FirebaseClient("https://heymotocarro-1a1d4.firebaseio.com/");
            Graphics G;
            Rectangle[] rect = new Rectangle[6];
        }

        private void ParkingLot_Load(object sender, EventArgs e)
        {
            G = this.CreateGraphics();

        }

        private async void loadBtn_Click_1(object sender, EventArgs e)
        {
            var BeaconsSet = await client
               .Child("Beacons/")//Prospect list
               .OnceSingleAsync<Beacons>();
            getBeacons(BeaconsSet);

            onChildChanged();
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


        private void onChildChanged() // Waits for data base to start with variable
        {


            var child = client.Child("Beacons/data");
            var observable = child.AsObservable<Beacon>();
            var subscription = observable
                .Subscribe(x =>
                {
                    beacon.data[Int32.Parse(x.Key)].update(x.Object);
                    Point p = Beacons.data[Int32.Parse(x.Key)];
                    Console.WriteLine($"beacon id: { x.Object.Id} [{ x.Object.D1}]");
                    Console.WriteLine($"beacon id: { x.Object.Id} [{ x.Object.D2}]");
                    Console.WriteLine($"beacon id: { x.Object.Id} [{ x.Object.D3}]");
                    Console.WriteLine($"beacon id: { x.Object.Id} [{ x.Object.D4}]");

                    //determine which parking slot is filled
                    if (p.y >= 0 && p.y <=2)
                    {
                        //int index = int(Math.Floor(p.x / 1.5) + 6);
                    }


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
