namespace NVStreamer1080 {
    partial class ActionEdit {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioKill = new System.Windows.Forms.RadioButton();
            this.RadioClose = new System.Windows.Forms.RadioButton();
            this.RadioLaunch = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NumDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.Label();
            this.TextDetails = new System.Windows.Forms.TextBox();
            this.CbAbortOnInput = new System.Windows.Forms.CheckBox();
            this.RadioSleep = new System.Windows.Forms.RadioButton();
            this.RadioHibernate = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioHibernate);
            this.groupBox1.Controls.Add(this.RadioSleep);
            this.groupBox1.Controls.Add(this.RadioKill);
            this.groupBox1.Controls.Add(this.RadioClose);
            this.groupBox1.Controls.Add(this.RadioLaunch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // RadioKill
            // 
            this.RadioKill.AutoSize = true;
            this.RadioKill.Location = new System.Drawing.Point(6, 85);
            this.RadioKill.Name = "RadioKill";
            this.RadioKill.Size = new System.Drawing.Size(86, 24);
            this.RadioKill.TabIndex = 5;
            this.RadioKill.TabStop = true;
            this.RadioKill.Text = "Kill App";
            this.RadioKill.UseVisualStyleBackColor = true;
            this.RadioKill.CheckedChanged += new System.EventHandler(this.ActionTypeChanged);
            // 
            // RadioClose
            // 
            this.RadioClose.AutoSize = true;
            this.RadioClose.Location = new System.Drawing.Point(6, 55);
            this.RadioClose.Name = "RadioClose";
            this.RadioClose.Size = new System.Drawing.Size(107, 24);
            this.RadioClose.TabIndex = 4;
            this.RadioClose.TabStop = true;
            this.RadioClose.Text = "Close App";
            this.RadioClose.UseVisualStyleBackColor = true;
            this.RadioClose.CheckedChanged += new System.EventHandler(this.ActionTypeChanged);
            // 
            // RadioLaunch
            // 
            this.RadioLaunch.AutoSize = true;
            this.RadioLaunch.Location = new System.Drawing.Point(6, 25);
            this.RadioLaunch.Name = "RadioLaunch";
            this.RadioLaunch.Size = new System.Drawing.Size(87, 24);
            this.RadioLaunch.TabIndex = 3;
            this.RadioLaunch.TabStop = true;
            this.RadioLaunch.Text = "Launch";
            this.RadioLaunch.UseVisualStyleBackColor = true;
            this.RadioLaunch.CheckedChanged += new System.EventHandler(this.ActionTypeChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Configure";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnConfigure);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 473);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnOk);
            // 
            // NumDelay
            // 
            this.NumDelay.Location = new System.Drawing.Point(69, 262);
            this.NumDelay.Name = "NumDelay";
            this.NumDelay.Size = new System.Drawing.Size(95, 26);
            this.NumDelay.TabIndex = 4;
            this.NumDelay.ValueChanged += new System.EventHandler(this.NumDelay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Delay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seconds";
            // 
            // Details
            // 
            this.Details.AutoSize = true;
            this.Details.Location = new System.Drawing.Point(14, 347);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(58, 20);
            this.Details.TabIndex = 8;
            this.Details.Text = "Details";
            // 
            // TextDetails
            // 
            this.TextDetails.Location = new System.Drawing.Point(12, 370);
            this.TextDetails.Multiline = true;
            this.TextDetails.Name = "TextDetails";
            this.TextDetails.ReadOnly = true;
            this.TextDetails.Size = new System.Drawing.Size(254, 97);
            this.TextDetails.TabIndex = 9;
            // 
            // CbAbortOnInput
            // 
            this.CbAbortOnInput.AutoSize = true;
            this.CbAbortOnInput.Location = new System.Drawing.Point(18, 294);
            this.CbAbortOnInput.Name = "CbAbortOnInput";
            this.CbAbortOnInput.Size = new System.Drawing.Size(196, 24);
            this.CbAbortOnInput.TabIndex = 10;
            this.CbAbortOnInput.Text = "Abort on Key or Mouse";
            this.CbAbortOnInput.UseVisualStyleBackColor = true;
            this.CbAbortOnInput.CheckedChanged += new System.EventHandler(this.CbAbortOnInput_CheckedChanged);
            // 
            // RadioSleep
            // 
            this.RadioSleep.AutoSize = true;
            this.RadioSleep.Location = new System.Drawing.Point(6, 115);
            this.RadioSleep.Name = "RadioSleep";
            this.RadioSleep.Size = new System.Drawing.Size(75, 24);
            this.RadioSleep.TabIndex = 6;
            this.RadioSleep.TabStop = true;
            this.RadioSleep.Text = "Sleep";
            this.RadioSleep.UseVisualStyleBackColor = true;
            this.RadioSleep.CheckedChanged += new System.EventHandler(this.ActionTypeChanged);
            // 
            // RadioHibernate
            // 
            this.RadioHibernate.AutoSize = true;
            this.RadioHibernate.Location = new System.Drawing.Point(6, 145);
            this.RadioHibernate.Name = "RadioHibernate";
            this.RadioHibernate.Size = new System.Drawing.Size(104, 24);
            this.RadioHibernate.TabIndex = 7;
            this.RadioHibernate.TabStop = true;
            this.RadioHibernate.Text = "Hibernate";
            this.RadioHibernate.UseVisualStyleBackColor = true;
            this.RadioHibernate.CheckedChanged += new System.EventHandler(this.ActionTypeChanged);
            // 
            // ActionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 511);
            this.Controls.Add(this.CbAbortOnInput);
            this.Controls.Add(this.TextDetails);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumDelay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActionEdit";
            this.Text = "Action";
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioClose;
        private System.Windows.Forms.RadioButton RadioLaunch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown NumDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RadioKill;
        private System.Windows.Forms.Label Details;
        private System.Windows.Forms.TextBox TextDetails;
        private System.Windows.Forms.CheckBox CbAbortOnInput;
        private System.Windows.Forms.RadioButton RadioHibernate;
        private System.Windows.Forms.RadioButton RadioSleep;
    }
}