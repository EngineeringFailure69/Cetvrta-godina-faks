using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using WcfClient.ChatServiceReference;

namespace WcfClient
{
    public partial class Chat : Form, IChatCallback
    {
        private ChatClient proxy;

        public Chat()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            txtFrom.Enabled = false;
            InstanceContext instanceContext = new InstanceContext(this);

            proxy = new ChatClient(instanceContext);
            proxy.ClockIn(txtFrom.Text);
        }

        private void btnPosalji_Click(object sender, EventArgs e)
        {
            ChatMessage message = new ChatMessage()
            {
                From = txtFrom.Text,
                To = txtTo.Text,
                Text = txt.Text
            };
            proxy.SendMessage(message);
        }

        public void ReceiveMessage(ChatMessage message)
        {
            AppendText(rtbPrijem, $"{message.From} - {DateTime.Now}", Color.Blue, true);

            AppendText(rtbPrijem, message.Text, Color.Black, true);
        }

        public void AppendText(RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new MethodInvoker(delegate () { AppendText(box, text, color, addNewLine); }));
            }
            else
            {
                box.SuspendLayout();
                Color old = box.SelectionColor;
                box.SelectionColor = color;
                box.AppendText(addNewLine
                    ? $"{text}{Environment.NewLine}"
                    : text);
                box.ScrollToCaret();
                box.SelectionColor = old;
                box.ResumeLayout();
            }
        }
    }
}
