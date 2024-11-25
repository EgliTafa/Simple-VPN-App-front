namespace Simple_VPN_App_front_.Forms
{
    partial class VpnForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI Components
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.RadioButton radioButtonTcp;
        private System.Windows.Forms.RadioButton radioButtonUdp;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.radioButtonTcp = new System.Windows.Forms.RadioButton();
            this.radioButtonUdp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();

            // buttonConnect
            this.buttonConnect.Location = new System.Drawing.Point(20, 20);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(94, 29);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);

            // buttonDisconnect
            this.buttonDisconnect.Location = new System.Drawing.Point(20, 60);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(94, 29);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);

            // buttonStatus
            this.buttonStatus.Location = new System.Drawing.Point(20, 100);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(94, 29);
            this.buttonStatus.TabIndex = 2;
            this.buttonStatus.Text = "Check Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);

            // labelStatus
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(20, 140);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(150, 20);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Status: Disconnected";

            // radioButtonTcp
            this.radioButtonTcp.AutoSize = true;
            this.radioButtonTcp.Location = new System.Drawing.Point(130, 25);
            this.radioButtonTcp.Name = "radioButtonTcp";
            this.radioButtonTcp.Size = new System.Drawing.Size(56, 24);
            this.radioButtonTcp.TabIndex = 4;
            this.radioButtonTcp.TabStop = true;
            this.radioButtonTcp.Text = "TCP";
            this.radioButtonTcp.UseVisualStyleBackColor = true;

            // radioButtonUdp
            this.radioButtonUdp.AutoSize = true;
            this.radioButtonUdp.Location = new System.Drawing.Point(130, 60);
            this.radioButtonUdp.Name = "radioButtonUdp";
            this.radioButtonUdp.Size = new System.Drawing.Size(59, 24);
            this.radioButtonUdp.TabIndex = 5;
            this.radioButtonUdp.TabStop = true;
            this.radioButtonUdp.Text = "UDP";
            this.radioButtonUdp.Checked = true;
            this.radioButtonUdp.UseVisualStyleBackColor = true;

            // VpnForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.radioButtonTcp);
            this.Controls.Add(this.radioButtonUdp);
            this.Name = "VpnForm";
            this.Text = "VPN Application";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
