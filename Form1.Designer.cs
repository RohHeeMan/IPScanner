
namespace IPScanner
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.Schedule_Timer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_FilePath = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lbl_FileChoice = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button2 = new System.Windows.Forms.Button();
			this.lblTmr = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button1.Location = new System.Drawing.Point(41, 269);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(335, 60);
			this.button1.TabIndex = 0;
			this.button1.Text = "작업 시작";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
			// 
			// Schedule_Timer
			// 
			this.Schedule_Timer.Interval = 1000;
			this.Schedule_Timer.Tick += new System.EventHandler(this.Schedule_Timer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(37, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(354, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "작동시간 설정(1Day 1,440분)";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.numericUpDown1.Location = new System.Drawing.Point(41, 68);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(169, 35);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.ThousandsSeparator = true;
			this.numericUpDown1.Value = new decimal(new int[] {
            1440,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(37, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(249, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "장비 설정 파일 찾기";
			// 
			// lbl_FilePath
			// 
			this.lbl_FilePath.AutoSize = true;
			this.lbl_FilePath.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbl_FilePath.Location = new System.Drawing.Point(37, 177);
			this.lbl_FilePath.Name = "lbl_FilePath";
			this.lbl_FilePath.Size = new System.Drawing.Size(0, 24);
			this.lbl_FilePath.TabIndex = 6;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "FolderOpen");
			this.imageList1.Images.SetKeyName(1, "FolderChoice");
			// 
			// lbl_FileChoice
			// 
			this.lbl_FileChoice.AutoSize = true;
			this.lbl_FileChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lbl_FileChoice.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbl_FileChoice.ForeColor = System.Drawing.Color.Black;
			this.lbl_FileChoice.Location = new System.Drawing.Point(86, 227);
			this.lbl_FileChoice.Name = "lbl_FileChoice";
			this.lbl_FileChoice.Size = new System.Drawing.Size(35, 16);
			this.lbl_FileChoice.TabIndex = 7;
			this.lbl_FileChoice.Text = "   ";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::IPScanner.Properties.Resources.Folder_svg;
			this.pictureBox1.Location = new System.Drawing.Point(41, 210);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(39, 41);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
			this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button2.Location = new System.Drawing.Point(216, 68);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(70, 38);
			this.button2.TabIndex = 8;
			this.button2.Tag = "button2";
			this.button2.Text = "설정";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblTmr
			// 
			this.lblTmr.AutoSize = true;
			this.lblTmr.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTmr.ForeColor = System.Drawing.Color.Green;
			this.lblTmr.Location = new System.Drawing.Point(132, 112);
			this.lblTmr.Name = "lblTmr";
			this.lblTmr.Size = new System.Drawing.Size(43, 41);
			this.lblTmr.TabIndex = 30;
			this.lblTmr.Text = "0";
			this.lblTmr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 343);
			this.Controls.Add(this.lblTmr);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.lbl_FileChoice);
			this.Controls.Add(this.lbl_FilePath);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "통신 체커";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer Schedule_Timer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbl_FilePath;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lbl_FileChoice;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblTmr;
	}
}

