using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace EmailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox4.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("At the moment only Gmail accounts are supported! Please enter Gmail addresses...");
                    return;
                }
                button1.Enabled = false;
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(textBox4.Text);
                msg.Subject = textBox2.Text;
                msg.Body = textBox3.Text;
                foreach (string str in textBox1.Text.Split(';'))
                    msg.To.Add(str);
                SmtpClient sclient = new SmtpClient();
                sclient.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
                sclient.Host = "smtp.gmail.com";
                sclient.Port = 587;
                sclient.EnableSsl = true;
                sclient.Send(msg);
            }
            catch { 
                MessageBox.Show("Ooops! There was an error sending the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{ button1.Enabled = true; }
        }
    }
}
