namespace ISET2018_TCPIP
{
    partial class EcranPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.mcListenerClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mcLCEcouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcLCConnecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDPListenerUDPClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDPEcouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDPConnecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mUtilitaires = new System.Windows.Forms.ToolStripMenuItem();
            this.muVerifier = new System.Windows.Forms.ToolStripMenuItem();
            this.mQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServeur = new System.Windows.Forms.TextBox();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.bValider = new System.Windows.Forms.Button();
            this.lblReponse = new System.Windows.Forms.Label();
            this.lbReponses = new System.Windows.Forms.ListBox();
            this.btnCloseConn = new System.Windows.Forms.Button();
            this.mcSocket = new System.Windows.Forms.ToolStripMenuItem();
            this.mcsEcouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcsConnecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcsDeconnecter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCommunication,
            this.mUtilitaires,
            this.mQuitter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mCommunication
            // 
            this.mCommunication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcListenerClient,
            this.mcUDPListenerUDPClient,
            this.mcSocket});
            this.mCommunication.Name = "mCommunication";
            this.mCommunication.Size = new System.Drawing.Size(106, 20);
            this.mCommunication.Text = "Communication";
            // 
            // mcListenerClient
            // 
            this.mcListenerClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcLCEcouter,
            this.mcLCConnecter});
            this.mcListenerClient.Name = "mcListenerClient";
            this.mcListenerClient.Size = new System.Drawing.Size(203, 22);
            this.mcListenerClient.Text = "TCPListener / TCPClient";
            // 
            // mcLCEcouter
            // 
            this.mcLCEcouter.Name = "mcLCEcouter";
            this.mcLCEcouter.Size = new System.Drawing.Size(129, 22);
            this.mcLCEcouter.Text = "Ecouter";
            this.mcLCEcouter.Click += new System.EventHandler(this.mcLCEcouter_Click);
            // 
            // mcLCConnecter
            // 
            this.mcLCConnecter.Name = "mcLCConnecter";
            this.mcLCConnecter.Size = new System.Drawing.Size(129, 22);
            this.mcLCConnecter.Text = "Connecter";
            this.mcLCConnecter.Click += new System.EventHandler(this.mcLCConnecter_Click);
            // 
            // mcUDPListenerUDPClient
            // 
            this.mcUDPListenerUDPClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcUDPEcouter,
            this.mcUDPConnecter});
            this.mcUDPListenerUDPClient.Name = "mcUDPListenerUDPClient";
            this.mcUDPListenerUDPClient.Size = new System.Drawing.Size(203, 22);
            this.mcUDPListenerUDPClient.Text = "UDPListener / UDPClient";
            // 
            // mcUDPEcouter
            // 
            this.mcUDPEcouter.Name = "mcUDPEcouter";
            this.mcUDPEcouter.Size = new System.Drawing.Size(129, 22);
            this.mcUDPEcouter.Text = "Ecouter";
            this.mcUDPEcouter.Click += new System.EventHandler(this.mcUDPEcouter_Click);
            // 
            // mcUDPConnecter
            // 
            this.mcUDPConnecter.Name = "mcUDPConnecter";
            this.mcUDPConnecter.Size = new System.Drawing.Size(129, 22);
            this.mcUDPConnecter.Text = "Connecter";
            this.mcUDPConnecter.Click += new System.EventHandler(this.mcUDPConnecter_Click);
            // 
            // mUtilitaires
            // 
            this.mUtilitaires.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muVerifier});
            this.mUtilitaires.Name = "mUtilitaires";
            this.mUtilitaires.Size = new System.Drawing.Size(68, 20);
            this.mUtilitaires.Text = "Utilitaires";
            // 
            // muVerifier
            // 
            this.muVerifier.Name = "muVerifier";
            this.muVerifier.Size = new System.Drawing.Size(110, 22);
            this.muVerifier.Text = "Vérifier";
            this.muVerifier.Click += new System.EventHandler(this.muVerifier_Click);
            // 
            // mQuitter
            // 
            this.mQuitter.Name = "mQuitter";
            this.mQuitter.Size = new System.Drawing.Size(56, 20);
            this.mQuitter.Text = "Quitter";
            this.mQuitter.Click += new System.EventHandler(this.mQuitter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serveur";
            // 
            // tbServeur
            // 
            this.tbServeur.Location = new System.Drawing.Point(12, 40);
            this.tbServeur.Name = "tbServeur";
            this.tbServeur.Size = new System.Drawing.Size(340, 20);
            this.tbServeur.TabIndex = 2;
            this.tbServeur.Text = "DESKTOP-7JT29FN";
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(12, 88);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(340, 20);
            this.tbQuestion.TabIndex = 4;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(12, 72);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(49, 13);
            this.lblQuestion.TabIndex = 3;
            this.lblQuestion.Text = "Question";
            // 
            // bValider
            // 
            this.bValider.Location = new System.Drawing.Point(12, 114);
            this.bValider.Name = "bValider";
            this.bValider.Size = new System.Drawing.Size(340, 23);
            this.bValider.TabIndex = 5;
            this.bValider.Text = "Envoyer";
            this.bValider.UseVisualStyleBackColor = true;
            this.bValider.Click += new System.EventHandler(this.bValider_Click);
            // 
            // lblReponse
            // 
            this.lblReponse.AutoSize = true;
            this.lblReponse.Location = new System.Drawing.Point(12, 140);
            this.lblReponse.Name = "lblReponse";
            this.lblReponse.Size = new System.Drawing.Size(49, 13);
            this.lblReponse.TabIndex = 6;
            this.lblReponse.Text = "Question";
            // 
            // lbReponses
            // 
            this.lbReponses.FormattingEnabled = true;
            this.lbReponses.Location = new System.Drawing.Point(15, 156);
            this.lbReponses.Name = "lbReponses";
            this.lbReponses.Size = new System.Drawing.Size(337, 173);
            this.lbReponses.TabIndex = 7;
            // 
            // btnCloseConn
            // 
            this.btnCloseConn.Location = new System.Drawing.Point(15, 335);
            this.btnCloseConn.Name = "btnCloseConn";
            this.btnCloseConn.Size = new System.Drawing.Size(340, 23);
            this.btnCloseConn.TabIndex = 8;
            this.btnCloseConn.Text = "Fermer la connexion TCP/UDP";
            this.btnCloseConn.UseVisualStyleBackColor = true;
            this.btnCloseConn.Click += new System.EventHandler(this.btnCloseConn_Click);
            // 
            // mcSocket
            // 
            this.mcSocket.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcsEcouter,
            this.mcsConnecter,
            this.mcsDeconnecter});
            this.mcSocket.Name = "mcSocket";
            this.mcSocket.Size = new System.Drawing.Size(203, 22);
            this.mcSocket.Text = "Socket";
            // 
            // mcsEcouter
            // 
            this.mcsEcouter.Name = "mcsEcouter";
            this.mcsEcouter.Size = new System.Drawing.Size(180, 22);
            this.mcsEcouter.Text = "Ecouter";
            this.mcsEcouter.Click += new System.EventHandler(this.mcsEcouter_Click);
            // 
            // mcsConnecter
            // 
            this.mcsConnecter.Name = "mcsConnecter";
            this.mcsConnecter.Size = new System.Drawing.Size(180, 22);
            this.mcsConnecter.Text = "Connecter";
            this.mcsConnecter.Click += new System.EventHandler(this.mcsConnecter_Click);
            // 
            // mcsDeconnecter
            // 
            this.mcsDeconnecter.Name = "mcsDeconnecter";
            this.mcsDeconnecter.Size = new System.Drawing.Size(180, 22);
            this.mcsDeconnecter.Text = "Deconnecter";
            this.mcsDeconnecter.Click += new System.EventHandler(this.mcsDeconnecter_Click);
            // 
            // EcranPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 369);
            this.Controls.Add(this.btnCloseConn);
            this.Controls.Add(this.lbReponses);
            this.Controls.Add(this.lblReponse);
            this.Controls.Add(this.bValider);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.tbServeur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EcranPrincipal";
            this.Text = "Communication TCPIP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mCommunication;
        private System.Windows.Forms.ToolStripMenuItem mUtilitaires;
        private System.Windows.Forms.ToolStripMenuItem mQuitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServeur;
        private System.Windows.Forms.ToolStripMenuItem muVerifier;
        private System.Windows.Forms.ToolStripMenuItem mcListenerClient;
        private System.Windows.Forms.ToolStripMenuItem mcLCEcouter;
        private System.Windows.Forms.ToolStripMenuItem mcLCConnecter;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button bValider;
        private System.Windows.Forms.Label lblReponse;
        private System.Windows.Forms.ListBox lbReponses;
        private System.Windows.Forms.ToolStripMenuItem mcUDPListenerUDPClient;
        private System.Windows.Forms.ToolStripMenuItem mcUDPEcouter;
        private System.Windows.Forms.ToolStripMenuItem mcUDPConnecter;
        private System.Windows.Forms.Button btnCloseConn;
        private System.Windows.Forms.ToolStripMenuItem mcSocket;
        private System.Windows.Forms.ToolStripMenuItem mcsEcouter;
        private System.Windows.Forms.ToolStripMenuItem mcsConnecter;
        private System.Windows.Forms.ToolStripMenuItem mcsDeconnecter;
    }
}

