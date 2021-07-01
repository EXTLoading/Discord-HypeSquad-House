using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace Discord_HypeSquad_House
{
    public partial class Form1 : Form
    {

        


        internal class Mouse
        {
            public static Point newpoint = default(Point);

            public static int x;

            public static int y;
        }
    

    public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void HeadServerLbl_Click(object sender, EventArgs e)
        {

        }

        private void HeadLinePnlInf_MouseMove(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                Mouse.newpoint = Control.MousePosition;
                Mouse.newpoint.X = Mouse.newpoint.X - Mouse.x;
                Mouse.newpoint.Y = Mouse.newpoint.Y - Mouse.y;
                base.Location = Mouse.newpoint;
            }
        }

        private void HeadLinePnlInf_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse.x = Control.MousePosition.X - base.Location.X;
            Mouse.y = Control.MousePosition.Y - base.Location.Y;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Balance.Checked == false)
            {
                Brilliance.Enabled = true;
                Bravery.Enabled = true;
            }
            else
            {
                Brilliance.Enabled = false;
                Bravery.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int house = 0;
            if (Balance.Checked == true) {
               house = 3;
                
            }
            else if (Brilliance.Checked == true)
            {
                house = 2;
            }
            else if (Bravery.Checked == true)
            {
                house = 1;
            }
            try
            {
                var client = new RestClient("https://canary.discord.com/api/v9/hypesquad/online");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token.Text);
                request.AddHeader("content-type", "application/json");
                request.AddCookie("__dcfduid", "ad494cb358b94f9fba9531dad664dd93");
                request.AddParameter("application/json", "{\"house_id\": " + house + "}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void CrashPCchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Brilliance.Checked == false)
            {
                Balance.Enabled = true;
                Bravery.Enabled = true;
            }
            else
            {
                Balance.Enabled = false;
                Bravery.Enabled = false;
            }
        }

        private void Bravery_CheckedChanged(object sender, EventArgs e)
        {
            if (Bravery.Checked == false)
            {
                Brilliance.Enabled = true;
                Balance.Enabled = true;
            }
            else
            {
                Brilliance.Enabled = false;
                Balance.Enabled = false;
            }
        }

        private void token_Enter(object sender, EventArgs e)
        {
            if (token.Text == "Token Here")
            {
                token.Text = "";
            }
        }

        private void token_Leave(object sender, EventArgs e)
        {
            if (token.Text == "")
            {
                token.Text = "Token Here";
            }
        }
    }
}
