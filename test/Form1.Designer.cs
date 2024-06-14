using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;

namespace test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        [STAThread]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label_Line = new System.Windows.Forms.Label();
            this.Label_Point = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Button_Create = new System.Windows.Forms.Button();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Button_Open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Change = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label_Messenger = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Bar_Speed = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Line
            // 
            this.Label_Line.AutoSize = true;
            this.Label_Line.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_Line.Location = new System.Drawing.Point(23, 11);
            this.Label_Line.Name = "Label_Line";
            this.Label_Line.Size = new System.Drawing.Size(76, 28);
            this.Label_Line.TabIndex = 3;
            this.Label_Line.Text = "label3";
            this.Label_Line.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Point
            // 
            this.Label_Point.AutoSize = true;
            this.Label_Point.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_Point.Location = new System.Drawing.Point(149, 11);
            this.Label_Point.Name = "Label_Point";
            this.Label_Point.Size = new System.Drawing.Size(76, 28);
            this.Label_Point.TabIndex = 4;
            this.Label_Point.Text = "label4";
            this.Label_Point.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(929, 308);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(332, 464);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Button_Create
            // 
            this.Button_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Create.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Create.Location = new System.Drawing.Point(929, 179);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(156, 37);
            this.Button_Create.TabIndex = 6;
            this.Button_Create.Text = "Create Line";
            this.Button_Create.UseVisualStyleBackColor = true;
            this.Button_Create.Click += new System.EventHandler(this.Button_Creat_Click);
            // 
            // Label_Mode
            // 
            this.Label_Mode.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_Mode.Location = new System.Drawing.Point(285, 5);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(288, 41);
            this.Label_Mode.TabIndex = 7;
            this.Label_Mode.Text = "label5";
            this.Label_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Delete
            // 
            this.Button_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Delete.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Delete.Location = new System.Drawing.Point(929, 265);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(156, 37);
            this.Button_Delete.TabIndex = 8;
            this.Button_Delete.Text = "Delete Line";
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Save.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Save.Location = new System.Drawing.Point(1105, 222);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(156, 37);
            this.Button_Save.TabIndex = 9;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Exit.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Exit.Location = new System.Drawing.Point(1105, 265);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(156, 37);
            this.Button_Exit.TabIndex = 10;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // Button_Open
            // 
            this.Button_Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Open.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Open.Location = new System.Drawing.Point(1105, 179);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(156, 37);
            this.Button_Open.TabIndex = 11;
            this.Button_Open.Text = "Open File";
            this.Button_Open.UseVisualStyleBackColor = true;
            this.Button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::test.Properties.Resources.Background_Image_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(28, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(850, 850);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Button_Change
            // 
            this.Button_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Change.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button_Change.Location = new System.Drawing.Point(929, 222);
            this.Button_Change.Name = "Button_Change";
            this.Button_Change.Size = new System.Drawing.Size(156, 37);
            this.Button_Change.TabIndex = 12;
            this.Button_Change.Text = "Tournament";
            this.Button_Change.UseVisualStyleBackColor = true;
            this.Button_Change.Click += new System.EventHandler(this.Button_Change_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(1022, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 40);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "test";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(862, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "File name :";
            // 
            // Label_Messenger
            // 
            this.Label_Messenger.AutoSize = true;
            this.Label_Messenger.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_Messenger.ForeColor = System.Drawing.Color.Red;
            this.Label_Messenger.Location = new System.Drawing.Point(610, 12);
            this.Label_Messenger.Name = "Label_Messenger";
            this.Label_Messenger.Size = new System.Drawing.Size(0, 28);
            this.Label_Messenger.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(906, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 28);
            this.label6.TabIndex = 17;
            this.label6.Text = "Speed :";
            // 
            // Bar_Speed
            // 
            this.Bar_Speed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Bar_Speed.Location = new System.Drawing.Point(1004, 69);
            this.Bar_Speed.Maximum = 2409;
            this.Bar_Speed.Name = "Bar_Speed";
            this.Bar_Speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Bar_Speed.Size = new System.Drawing.Size(236, 28);
            this.Bar_Speed.TabIndex = 18;
            this.Bar_Speed.Value = 1800;
            this.Bar_Speed.ValueChanged += new System.EventHandler(this.Bar_Speed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1243, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1243, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 28);
            this.label3.TabIndex = 22;
            this.label3.Text = "30";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(1004, 120);
            this.hScrollBar1.Maximum = 59;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hScrollBar1.Size = new System.Drawing.Size(236, 28);
            this.hScrollBar1.TabIndex = 21;
            this.hScrollBar1.Value = 30;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(906, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 28);
            this.label4.TabIndex = 20;
            this.label4.Text = "Point :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1312, 788);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Bar_Speed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Label_Messenger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Button_Change);
            this.Controls.Add(this.Button_Open);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.Label_Mode);
            this.Controls.Add(this.Button_Create);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Label_Point);
            this.Controls.Add(this.Label_Line);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Route Plan";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Label_Line;
        private System.Windows.Forms.Label Label_Point;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Button_Create;
        private System.Windows.Forms.Label Label_Mode;
        private Button Button_Delete;
        private Button Button_Save;
        private Button Button_Exit;
        private Button Button_Open;
        private Button Button_Change;
        private TextBox textBox1;
        private Label label1;
        private Label Label_Messenger;
        private Label label6;
        private HScrollBar Bar_Speed;
        private Label label2;
        private Label label3;
        private HScrollBar hScrollBar1;
        private Label label4;
    }
}

