namespace MyPacketCapturer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.txtCaptureData = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(366, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(104, 47);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(115, 80);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(623, 24);
            this.cmbDevices.TabIndex = 1;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // txtCaptureData
            // 
            this.txtCaptureData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptureData.Location = new System.Drawing.Point(49, 123);
            this.txtCaptureData.Multiline = true;
            this.txtCaptureData.Name = "txtCaptureData";
            this.txtCaptureData.Size = new System.Drawing.Size(746, 630);
            this.txtCaptureData.TabIndex = 2;
            this.txtCaptureData.TextChanged += new System.EventHandler(this.txtCaptureData_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 775);
            this.Controls.Add(this.txtCaptureData);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.btnStartStop);
            this.Name = "Form1";
            this.Text = "Packet Capture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.TextBox txtCaptureData;
        private System.Windows.Forms.Timer timer1;
    }
}

