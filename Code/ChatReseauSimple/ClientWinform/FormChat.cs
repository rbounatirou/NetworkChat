using BibliClient.ClientTools;
using BibliClient.ObserverEvents.Observers;

namespace ClientWinform
{
    public partial class FormChat : Form
    {
        private Client client;
        private ClientManager cm;


        public FormChat()
        {
           

            InitializeComponent();
            client = Client.getInstance();
            cm = new ClientManager(this);
            client.AddSubscriber((IClientConnectObserver)cm);
            client.AddSubscriber((IClientReceiveMessageObserver)cm);
        }

        public void AddMessageOnList(string _str)
        {
            if (listBoxMessage.InvokeRequired)
            {
                listBoxMessage.Invoke(() => listBoxMessage.Items.Add(_str));
            }
        }

        public void AddMessageOnList(BibliClient.Message _message) => AddMessageOnList(_message.Content);

        private void buttonEnvoi_Click(object sender, EventArgs e)
        {
            client.Send(textBoxMessage.Text);
            textBoxMessage.Text = "";
        }

        private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ICI LA FENETRE SE FERME
        }
    }
}
