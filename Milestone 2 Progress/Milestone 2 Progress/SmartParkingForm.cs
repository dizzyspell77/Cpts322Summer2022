﻿using System;
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
        }

        FirebaseClient client = new FirebaseClient("https://heymotocarro-1a1d4.firebaseio.com/");
        Graphics G;
        Beacons BeaconsSet;
        Rectangle[] rect = new Rectangle[6];
        Beacons beacons;
        Sensors sensors;

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
            BeaconsSet = await client
               .Child("Beacons/")//Prospect list
               .OnceSingleAsync<Beacons>();

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
                .Subscribe( x =>
                {
                    int key = Int32.Parse(x.Key);


                    BeaconsSet.data[key].Update(x.Object);
                    Point p = BeaconsSet.data[key].getXY(sensors);


                    //get value
                    Console.WriteLine($" value (x, y): {p.x}, {p.y}");

             

                    //determine which parking slot contains Sensor
                    /*if (p.y >= 0 && p.y <=2)
                    //{
                        //int index = int(Math.Floor(p.x / 1.5) + 6);
                    //}*/
                    
               
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
