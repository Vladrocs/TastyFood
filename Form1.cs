﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", api_key);
            var response = httpClient.GetAsync("https://foodish-api.herokuapp.com/").Result;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Failed req {response.StatusCode}");
            }

            string responseMessage = response.Content.ReadAsStringAsync().Result;
            //TrendingResponse responseObject = JsonConvert.DeserializeObject(responseMessage);

            // Console.WriteLine($"Type: {responseObject._type}");
            Debug.WriteLine(getBetween(responseMessage, "class=\"form-control\" value=\"", "\""));
            string linkpoza = getBetween(responseMessage, "class=\"form-control\" value=\"", "\"");
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Load(linkpoza);

            //Image.Source = new BitmapImage(new Uri(@linkpoza));
            /*foreach (Category category in responseObject.categories)
            {
                Console.WriteLine($"Category: {category.title}");
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}