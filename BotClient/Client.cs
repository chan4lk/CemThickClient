using Microsoft.Bot.Connector.DirectLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotClient
{
    public partial class Client : Form
    {
        private static string directLineSecret = ConfigurationManager.AppSettings["DirectLineSecret"];
        private static string botId = ConfigurationManager.AppSettings["BotId"];
        private static string fromUser = "DirectLineSampleClientUser";
        private DirectLineClient client;
        private Conversation conversation;

        public Client()
        {
            InitializeComponent();
            StartBotConversation();

        }

        private async Task StartBotConversation()
        {
           client = new DirectLineClient(directLineSecret);

            conversation = await client.Conversations.StartConversationAsync();

            new System.Threading.Thread(async () => await ReadBotMessagesAsync(client, conversation.ConversationId)).Start();

            SetText(sendText, "Hi");          
                       
        }

        private async Task ReadBotMessagesAsync(DirectLineClient client, string conversationId)
        {
            string watermark = null;

            while (true)
            {
                var activitySet = await client.Conversations.GetActivitiesAsync(conversationId, watermark);
                watermark = activitySet?.Watermark;

                var activities = from x in activitySet.Activities
                                 where x.From.Id == botId
                                 select x;

                foreach (Activity activity in activities)
                {
                    SetText(chatHistoryText, activity.Text);

                    if (activity.Attachments != null)
                    {
                        foreach (Attachment attachment in activity.Attachments)
                        {
                            switch (attachment.ContentType)
                            {
                                case "application/vnd.microsoft.card.hero":
                                    RenderHeroCard(attachment);
                                    break;

                                case "image/png":
                                    SetText(metaText, $"Opening the requested image '{attachment.ContentUrl}'");

                                    Process.Start(attachment.ContentUrl);
                                    break;
                            }
                        }
                    }

                   SetText(metaText, "command\n");
                }

                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            }
        }

        private void SetText(TextBox txt, string text)
        {
            if (txt.InvokeRequired)
            {
                Invoke((MethodInvoker)(() => txt.AppendText(text + "\n")));
            }
            else
            {
                txt.AppendText(text);
            }
        }

        private void RenderHeroCard(Attachment attachment)
        {
            const int Width = 70;
            Func<string, string> contentLine = (content) => string.Format($"{{0, -{Width}}}", string.Format("{0," + ((Width + content.Length) / 2).ToString() + "}", content));

            var heroCard = JsonConvert.DeserializeObject<HeroCard>(attachment.Content.ToString());

            if (heroCard != null)
            {
                SetText(chatHistoryText,string.Format("/{0}", new string('*', Width + 1)));
                SetText(chatHistoryText, string.Format("*{0}*", contentLine(heroCard.Title)));
                SetText(chatHistoryText,string.Format("*{0}*", new string(' ', Width)));
                SetText(chatHistoryText,string.Format("*{0}*", contentLine(heroCard.Text)));
                SetText(chatHistoryText, string.Format("{0}/", new string('*', Width + 1)));
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Send(sendText.Text);
            sendText.Clear();
        }

        private async void Send(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Activity userMessage = new Activity
                {
                    From = new ChannelAccount(fromUser),
                    Text = input,
                    Type = ActivityTypes.Message
                };

                await client.Conversations.PostActivityAsync(conversation.ConversationId, userMessage);
            }
        }
    }
}
