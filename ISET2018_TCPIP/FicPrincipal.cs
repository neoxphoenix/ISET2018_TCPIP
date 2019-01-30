using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ISET2018_TCPIP
{
    public partial class EcranPrincipal : Form
    {

        #region Récupération du mode Debug
        delegate void RenvoiVersInserer(string text);

        
        private void InsererItemThread(string texte)
        {
            Thread ThreadInsererItem = new Thread(new ParameterizedThreadStart(InsererItem));
            ThreadInsererItem.Start(texte);
        }
        

        private void InsererItem(object texte)
        {
            Console.WriteLine("THREAD");
            if (lbReponses.InvokeRequired)
            {
                RenvoiVersInserer d = new RenvoiVersInserer(InsererItem);
                Invoke(d, new object[] { texte });
            }
            else lbReponses.Items.Insert(0, (string)texte); //c'est ucu que l'on interagit avec le jeu
        }
        #endregion



        //Variable TCP et UDO
        public string mode, ServOrClient;
        IPAddress IPServeur;
        IPAddress IPLocal;

        TcpListener MonServeurTCP;
        TcpClient MonClientTCP;

        UdpClient MonServeurUDP;
        UdpClient MonClientUDP;
        IPEndPoint IPEP_UDP;

        //Variable pour Socket
        private Socket socServeur, socClient;
        private byte[] socBuffer = new byte[256];
        private int socFlag = 0;
        
        //Constructeur
        public EcranPrincipal()
        {
            InitializeComponent();
        }

        //Methodes
        private void mQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void muVerifier_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipaTmp = Utilitaires.Verifier(tbServeur.Text);
                if (ipaTmp == null)
                    MessageBox.Show("Problème d'adresse");
                else
                    MessageBox.Show("Test OK");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Problème de 'ping' : " + ex);
            }
        }

        /// <summary>
        /// TCP
        /// </summary>

        private void mcLCEcouter_Click(object sender, EventArgs e)
        {
            ServOrClient = "Serveur";
            mcLCConnecter.Enabled = mcLCEcouter.Enabled = false;
            IPLocal = Utilitaires.Verifier(tbServeur.Text);
            MonServeurTCP = new TcpListener(IPLocal, 8000);
            MonServeurTCP.Start();
            TcpClient MonClient = MonServeurTCP.AcceptTcpClient();
            NetworkStream flux = MonClient.GetStream();
            BinaryWriter bw = new BinaryWriter(flux);
            bw.Write("Connexion initialisée");

            BinaryReader br = new BinaryReader(flux);
            lbReponses.Items.Add(br.ReadString());

            //bw.Write("Ordre de déconnexion");
            //lbReponses.Items.Add(br.ReadString());
            //MonClient.Close();
            //MonServeur.Stop();

            //mcLCConnecter.Enabled = mcLCEcouter.Enabled = true;
        }

        private void mcLCConnecter_Click(object sender, EventArgs e)
        {
            mode = "TCP";
            ServOrClient = "Client";
            mcLCConnecter.Enabled = mcLCEcouter.Enabled = false;
            IPServeur = Utilitaires.Verifier(tbServeur.Text);
            MonClientTCP = new TcpClient();
            MonClientTCP.Connect(IPServeur, 8000);
            NetworkStream flux = MonClientTCP.GetStream();
            BinaryReader br = new BinaryReader(flux);
            lbReponses.Items.Add(br.ReadString());

            BinaryWriter bw = new BinaryWriter(flux);
            IPServeur = Utilitaires.Verifier(Dns.GetHostName());
            bw.Write("Machine " + IPServeur.ToString() + " connectée");
            lbReponses.Items.Add(br.ReadString());
            bw.Write("Déconnexion effectuée");

            MonClientTCP.Close();
            mcLCConnecter.Enabled = mcLCEcouter.Enabled = true;
        }


        /// <summary>
        /// UDP
        /// </summary>
        private void mcUDPEcouter_Click(object sender, EventArgs e)
        {
            ServOrClient = "Serveur";
            mcLCConnecter.Enabled = mcLCEcouter.Enabled = false;
            string Donnees;
            byte[] tabOctets;
            IPLocal = Utilitaires.Verifier(tbServeur.Text);
            IPEP_UDP = new IPEndPoint(IPLocal, 8000);
            MonServeurUDP = new UdpClient(8000);

            lbReponses.Items.Add("UDP prêt à recevoir des données de " + IPEP_UDP.ToString());
            tabOctets = MonServeurUDP.Receive(ref IPEP_UDP); // Fonction bloquante
            Donnees = Encoding.ASCII.GetString(tabOctets, 0, tabOctets.Length);
            lbReponses.Items.Add("Données reçues : ");
            lbReponses.Items.Add(Donnees);
            
            //lbReponses.Items.Add("Fermeture serveur");
            //MonServeurUDP.Close();
            //mcLCConnecter.Enabled = mcLCEcouter.Enabled = true;
        }

        private void mcUDPConnecter_Click(object sender, EventArgs e)
        {
            mode = "UDP";
            ServOrClient = "Client";
            mcLCConnecter.Enabled = mcLCEcouter.Enabled = false;
            IPServeur = Utilitaires.Verifier(tbServeur.Text);
            MonClientUDP = new UdpClient();
            MonClientUDP.Connect(IPServeur, 8000);
            lbReponses.Items.Add("Client connecté à " + IPServeur.ToString() + ":8000");

            //byte[] tabOctets = Encoding.ASCII.GetBytes(tbQuestion.Text);
            //MonClientUDP.Send(tabOctets, tabOctets.Length);

            lbReponses.Items.Add("Message envoyé");
            lbReponses.Items.Add(tbQuestion.Text);
            lbReponses.Items.Add("fermeture de la connexion");
            //MonClientUDP.Close();
            
        }

        private void bValider_Click(object sender, EventArgs e)
        {
            /*
            if (mode == "UDP")
            {
                Console.WriteLine("Envoi message UDP");
                byte[] tabOctets = Encoding.ASCII.GetBytes(tbQuestion.Text);
                MonClientUDP.Send(tabOctets, tabOctets.Length);
            }
            else if (mode =="TCP")
            {

            }
            */
            if ((socFlag == 1 && socClient != null) || socFlag == 2)
            {
                socClient.Send(Encoding.Unicode.GetBytes(tbQuestion.Text));
            }
        }

        private void btnCloseConn_Click(object sender, EventArgs e)
        {
            if (mode == "UDP")
            {
                if (ServOrClient == "Client") { MonClientUDP.Close(); }
                else { MonServeurUDP.Close(); }
                mcLCConnecter.Enabled = mcLCEcouter.Enabled = true;
            }
                
            else if (mode =="TCP")
            {
                if (ServOrClient == "Client") { MonClientTCP.Close(); }
                else
                {
                    MonClientTCP.Close();
                    MonServeurTCP.Stop();
                }
                mcLCConnecter.Enabled = mcLCEcouter.Enabled = true;
            }
        }



        /// <summary>
        /// Socket
        /// </summary>

        private void mcsEcouter_Click(object sender, EventArgs e)
        {
            mcsEcouter.Enabled = mcsConnecter.Enabled = false;
            mcsDeconnecter.Enabled = true;
            socFlag = 1; //je suis sensé etre serveur
            socClient = null; 
            IPAddress IPServeur = Utilitaires.Verifier(Dns.GetHostName());
            socServeur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socServeur.Bind(new IPEndPoint(IPServeur, 8000));
            socServeur.Listen(1);
            socServeur.BeginAccept(new AsyncCallback(SurDemandeConnexion), socServeur);
        }

        private void SurDemandeConnexion(IAsyncResult iAR)
        {
            //Corrigé
            if(socFlag == 1)
            { 
                Socket sTmp = (Socket)iAR.AsyncState;
                socClient = sTmp.EndAccept(iAR);
                socClient.Send(Encoding.Unicode.GetBytes("Connexion acceptée"));
                InsererItemThread("Connexion effectuée par " + ((IPEndPoint)socClient.RemoteEndPoint).Address);
                //lbReponses.Items.Add("Connexion effectuée par " + ((IPEndPoint)socClient.RemoteEndPoint).Address);
                InitialiserReception(socClient);
            }
        }

        private void InitialiserReception(Socket sArg)
        {
            try
            {
                sArg.BeginReceive(socBuffer, 0, socBuffer.Length, SocketFlags.None, new AsyncCallback(Reception), sArg);
            }
            catch
            {
                MessageBox.Show("Réception impossible!");
            }
        }

        private void Reception(IAsyncResult iAR)
        {
            if (socFlag > 0)
            {
                Socket sTmp = (Socket)iAR.AsyncState;
                try
                {
                    int nRec = sTmp.EndReceive(iAR);
                    if (nRec > 0)
                    {
                        //lbReponses.Items.Add(Encoding.Unicode.GetString(socBuffer));
                        //InsererItemThread(Encoding.Unicode.GetString(socBuffer));

                        Thread ThreadInsererItem = new Thread(new ParameterizedThreadStart(InsererItem));
                        ThreadInsererItem.Start(Encoding.Unicode.GetString(socBuffer));

                        InitialiserReception(sTmp);
                    }
                    else
                    {
                        sTmp.Disconnect(true);
                        sTmp.Close();
                        socServeur.BeginAccept(new AsyncCallback(SurDemandeConnexion), socServeur);
                        //Corrigé
                        socClient = null;
                    }
                }
                catch
                {
                    MessageBox.Show("Erreur pendant la répcetion");
                }
            }
        }


        private void mcsConnecter_Click(object sender, EventArgs e)
        {
            mcsEcouter.Enabled = mcsConnecter.Enabled = false;
            mcsDeconnecter.Enabled = true;
            socFlag = 2;
            try
            {
                socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socClient.Blocking = false;
                IPAddress IPDistant = Utilitaires.Verifier(tbServeur.Text);
                socClient.BeginConnect(new IPEndPoint(IPDistant, 8000), new AsyncCallback(SurConnexion), socClient); //demande de connexion
            }
            catch
            {
                MessageBox.Show("Connexion au serveur impossible");
            }
        }

        private void SurConnexion(IAsyncResult iAR)
        {
            Socket sTmp = (Socket)iAR.AsyncState;
            if (sTmp.Connected) InitialiserReception(sTmp);
            else MessageBox.Show("Serveur inaccessible");
        }

        private void mcsDeconnecter_Click(object sender, EventArgs e)
        {
            if (socFlag == 1)
            {
                if (socClient == null)
                {
                    socFlag = 0;
                    mcsEcouter.Enabled = mcsConnecter.Enabled = true;
                    mcsDeconnecter.Enabled = false;
                    socServeur.Close();
                }
                else MessageBox.Show("Un client est connecté"); //on ne permet pas la déconnexion
            }
            else if (socFlag == 2)
            {
                socClient.Send(Encoding.Unicode.GetBytes("Déconnexion de " + ((IPEndPoint)socClient.LocalEndPoint).Address));
                socClient.Shutdown(SocketShutdown.Both);
                socFlag = 0;
                socClient.BeginDisconnect(false, new AsyncCallback(DemandeDeconnexion), socClient);
                mcsEcouter.Enabled = mcsConnecter.Enabled = true;
                mcsDeconnecter.Enabled = false;
            }
        }

        private static void DemandeDeconnexion(IAsyncResult iAR)
        {
            Socket sTmp = (Socket)iAR.AsyncState;
            sTmp.EndDisconnect(iAR);
        }

    }
}
