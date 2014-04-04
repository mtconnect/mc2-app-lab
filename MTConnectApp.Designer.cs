namespace MTConnectApplication
{
    partial class MTConnectApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.connected = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spindleTimeBar = new System.Windows.Forms.ProgressBar();
            this.availabilityValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.availability = new System.Windows.Forms.ProgressBar();
            this.spindleTime1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.utilizationValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.utilization = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.controllerMode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.execution = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.functionalMode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.avgNoise = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.magnitude = new System.Windows.Forms.TextBox();
            this.waveViewer = new NAudio.Gui.WaveViewer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.conditions = new System.Windows.Forms.ListBox();
            this.producing = new System.Windows.Forms.Label();
            this.metricBar1 = new System.Windows.Forms.ProgressBar();
            this.metricValue1 = new System.Windows.Forms.TextBox();
            this.metricBar2 = new System.Windows.Forms.ProgressBar();
            this.metricValue2 = new System.Windows.Forms.TextBox();
            this.metricBar4 = new System.Windows.Forms.ProgressBar();
            this.metricValue4 = new System.Windows.Forms.TextBox();
            this.metricBar3 = new System.Windows.Forms.ProgressBar();
            this.metricValue3 = new System.Windows.Forms.TextBox();
            this.dataItem1 = new System.Windows.Forms.TextBox();
            this.dataItem2 = new System.Windows.Forms.TextBox();
            this.dataItem3 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL: ";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(121, 29);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(228, 20);
            this.url.TabIndex = 1;
            this.url.Text = "http://127.0.0.1:5000/MC2_LAB";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(355, 27);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // connected
            // 
            this.connected.AutoSize = true;
            this.connected.Enabled = false;
            this.connected.Location = new System.Drawing.Point(121, 62);
            this.connected.Name = "connected";
            this.connected.Size = new System.Drawing.Size(78, 17);
            this.connected.TabIndex = 6;
            this.connected.Text = "Connected";
            this.connected.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metricBar4);
            this.groupBox1.Controls.Add(this.metricValue4);
            this.groupBox1.Controls.Add(this.metricBar3);
            this.groupBox1.Controls.Add(this.metricValue3);
            this.groupBox1.Controls.Add(this.metricBar2);
            this.groupBox1.Controls.Add(this.metricValue2);
            this.groupBox1.Controls.Add(this.metricBar1);
            this.groupBox1.Controls.Add(this.metricValue1);
            this.groupBox1.Controls.Add(this.spindleTimeBar);
            this.groupBox1.Controls.Add(this.availabilityValue);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.availability);
            this.groupBox1.Controls.Add(this.spindleTime1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.utilizationValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.utilization);
            this.groupBox1.Location = new System.Drawing.Point(24, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 222);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metrics";
            // 
            // spindleTimeBar
            // 
            this.spindleTimeBar.Location = new System.Drawing.Point(92, 78);
            this.spindleTimeBar.Name = "spindleTimeBar";
            this.spindleTimeBar.Size = new System.Drawing.Size(228, 23);
            this.spindleTimeBar.Step = 1;
            this.spindleTimeBar.TabIndex = 32;
            // 
            // availabilityValue
            // 
            this.availabilityValue.Enabled = false;
            this.availabilityValue.Location = new System.Drawing.Point(326, 22);
            this.availabilityValue.Name = "availabilityValue";
            this.availabilityValue.Size = new System.Drawing.Size(92, 20);
            this.availabilityValue.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Availability";
            // 
            // availability
            // 
            this.availability.Location = new System.Drawing.Point(92, 19);
            this.availability.Name = "availability";
            this.availability.Size = new System.Drawing.Size(228, 23);
            this.availability.Step = 1;
            this.availability.TabIndex = 29;
            // 
            // spindleTime1
            // 
            this.spindleTime1.Enabled = false;
            this.spindleTime1.Location = new System.Drawing.Point(326, 78);
            this.spindleTime1.Name = "spindleTime1";
            this.spindleTime1.Size = new System.Drawing.Size(92, 20);
            this.spindleTime1.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Spindle Time";
            // 
            // utilizationValue
            // 
            this.utilizationValue.Enabled = false;
            this.utilizationValue.Location = new System.Drawing.Point(326, 52);
            this.utilizationValue.Name = "utilizationValue";
            this.utilizationValue.Size = new System.Drawing.Size(92, 20);
            this.utilizationValue.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Utilization";
            // 
            // utilization
            // 
            this.utilization.Location = new System.Drawing.Point(92, 49);
            this.utilization.Name = "utilization";
            this.utilization.Size = new System.Drawing.Size(228, 23);
            this.utilization.Step = 1;
            this.utilization.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "ControllerMode:";
            // 
            // controllerMode
            // 
            this.controllerMode.Enabled = false;
            this.controllerMode.Location = new System.Drawing.Point(100, 25);
            this.controllerMode.Name = "controllerMode";
            this.controllerMode.Size = new System.Drawing.Size(228, 20);
            this.controllerMode.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Execution";
            // 
            // execution
            // 
            this.execution.Enabled = false;
            this.execution.Location = new System.Drawing.Point(100, 51);
            this.execution.Name = "execution";
            this.execution.Size = new System.Drawing.Size(228, 20);
            this.execution.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataItem3);
            this.groupBox2.Controls.Add(this.dataItem2);
            this.groupBox2.Controls.Add(this.dataItem1);
            this.groupBox2.Controls.Add(this.functionalMode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.execution);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.controllerMode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(24, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 186);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // functionalMode
            // 
            this.functionalMode.Enabled = false;
            this.functionalMode.Location = new System.Drawing.Point(100, 77);
            this.functionalMode.Name = "functionalMode";
            this.functionalMode.Size = new System.Drawing.Size(228, 20);
            this.functionalMode.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Functional Mode";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.avgNoise);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.magnitude);
            this.groupBox4.Controls.Add(this.waveViewer);
            this.groupBox4.Location = new System.Drawing.Point(493, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 193);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sound";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Avg Noise Level";
            // 
            // avgNoise
            // 
            this.avgNoise.Enabled = false;
            this.avgNoise.Location = new System.Drawing.Point(307, 21);
            this.avgNoise.Name = "avgNoise";
            this.avgNoise.Size = new System.Drawing.Size(92, 20);
            this.avgNoise.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Max Noise Level";
            // 
            // magnitude
            // 
            this.magnitude.Enabled = false;
            this.magnitude.Location = new System.Drawing.Point(114, 18);
            this.magnitude.Name = "magnitude";
            this.magnitude.Size = new System.Drawing.Size(92, 20);
            this.magnitude.TabIndex = 26;
            // 
            // waveViewer
            // 
            this.waveViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveViewer.Location = new System.Drawing.Point(13, 45);
            this.waveViewer.Name = "waveViewer";
            this.waveViewer.SamplesPerPixel = 20;
            this.waveViewer.Size = new System.Drawing.Size(409, 132);
            this.waveViewer.StartPosition = ((long)(0));
            this.waveViewer.TabIndex = 14;
            this.waveViewer.WaveStream = null;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.conditions);
            this.groupBox5.Location = new System.Drawing.Point(493, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(433, 220);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Conditions";
            // 
            // conditions
            // 
            this.conditions.FormattingEnabled = true;
            this.conditions.HorizontalScrollbar = true;
            this.conditions.Location = new System.Drawing.Point(13, 19);
            this.conditions.Name = "conditions";
            this.conditions.ScrollAlwaysVisible = true;
            this.conditions.Size = new System.Drawing.Size(409, 186);
            this.conditions.TabIndex = 22;
            // 
            // producing
            // 
            this.producing.BackColor = System.Drawing.Color.Red;
            this.producing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.producing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producing.ForeColor = System.Drawing.Color.White;
            this.producing.Location = new System.Drawing.Point(573, 27);
            this.producing.Name = "producing";
            this.producing.Size = new System.Drawing.Size(228, 24);
            this.producing.TabIndex = 23;
            this.producing.Text = "Not Producing";
            this.producing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metricBar1
            // 
            this.metricBar1.Location = new System.Drawing.Point(92, 107);
            this.metricBar1.Name = "metricBar1";
            this.metricBar1.Size = new System.Drawing.Size(228, 23);
            this.metricBar1.Step = 1;
            this.metricBar1.TabIndex = 34;
            // 
            // metricValue1
            // 
            this.metricValue1.Enabled = false;
            this.metricValue1.Location = new System.Drawing.Point(326, 107);
            this.metricValue1.Name = "metricValue1";
            this.metricValue1.Size = new System.Drawing.Size(92, 20);
            this.metricValue1.TabIndex = 33;
            // 
            // metricBar2
            // 
            this.metricBar2.Location = new System.Drawing.Point(92, 134);
            this.metricBar2.Name = "metricBar2";
            this.metricBar2.Size = new System.Drawing.Size(228, 23);
            this.metricBar2.Step = 1;
            this.metricBar2.TabIndex = 36;
            // 
            // metricValue2
            // 
            this.metricValue2.Enabled = false;
            this.metricValue2.Location = new System.Drawing.Point(326, 134);
            this.metricValue2.Name = "metricValue2";
            this.metricValue2.Size = new System.Drawing.Size(92, 20);
            this.metricValue2.TabIndex = 35;
            // 
            // metricBar4
            // 
            this.metricBar4.Location = new System.Drawing.Point(92, 190);
            this.metricBar4.Name = "metricBar4";
            this.metricBar4.Size = new System.Drawing.Size(228, 23);
            this.metricBar4.Step = 1;
            this.metricBar4.TabIndex = 40;
            // 
            // metricValue4
            // 
            this.metricValue4.Enabled = false;
            this.metricValue4.Location = new System.Drawing.Point(326, 190);
            this.metricValue4.Name = "metricValue4";
            this.metricValue4.Size = new System.Drawing.Size(92, 20);
            this.metricValue4.TabIndex = 39;
            // 
            // metricBar3
            // 
            this.metricBar3.Location = new System.Drawing.Point(92, 163);
            this.metricBar3.Name = "metricBar3";
            this.metricBar3.Size = new System.Drawing.Size(228, 23);
            this.metricBar3.Step = 1;
            this.metricBar3.TabIndex = 38;
            // 
            // metricValue3
            // 
            this.metricValue3.Enabled = false;
            this.metricValue3.Location = new System.Drawing.Point(326, 163);
            this.metricValue3.Name = "metricValue3";
            this.metricValue3.Size = new System.Drawing.Size(92, 20);
            this.metricValue3.TabIndex = 37;
            // 
            // dataItem1
            // 
            this.dataItem1.Enabled = false;
            this.dataItem1.Location = new System.Drawing.Point(100, 103);
            this.dataItem1.Name = "dataItem1";
            this.dataItem1.Size = new System.Drawing.Size(228, 20);
            this.dataItem1.TabIndex = 24;
            // 
            // dataItem2
            // 
            this.dataItem2.Enabled = false;
            this.dataItem2.Location = new System.Drawing.Point(100, 129);
            this.dataItem2.Name = "dataItem2";
            this.dataItem2.Size = new System.Drawing.Size(228, 20);
            this.dataItem2.TabIndex = 25;
            // 
            // dataItem3
            // 
            this.dataItem3.Enabled = false;
            this.dataItem3.Location = new System.Drawing.Point(100, 155);
            this.dataItem3.Name = "dataItem3";
            this.dataItem3.Size = new System.Drawing.Size(228, 20);
            this.dataItem3.TabIndex = 26;
            // 
            // MTConnectApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(938, 513);
            this.Controls.Add(this.producing);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.connected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label1);
            this.Name = "MTConnectApp";
            this.Text = "MTConnect App Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox connected;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox utilizationValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar utilization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox controllerMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox execution;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private NAudio.Gui.WaveViewer waveViewer;
        private System.Windows.Forms.TextBox spindleTime1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox conditions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox magnitude;
        private System.Windows.Forms.Label producing;
        private System.Windows.Forms.TextBox functionalMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox availabilityValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar availability;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox avgNoise;
        private System.Windows.Forms.ProgressBar spindleTimeBar;
        private System.Windows.Forms.ProgressBar metricBar4;
        private System.Windows.Forms.TextBox metricValue4;
        private System.Windows.Forms.ProgressBar metricBar3;
        private System.Windows.Forms.TextBox metricValue3;
        private System.Windows.Forms.ProgressBar metricBar2;
        private System.Windows.Forms.TextBox metricValue2;
        private System.Windows.Forms.ProgressBar metricBar1;
        private System.Windows.Forms.TextBox metricValue1;
        private System.Windows.Forms.TextBox dataItem1;
        private System.Windows.Forms.TextBox dataItem2;
        private System.Windows.Forms.TextBox dataItem3;
    }
}

