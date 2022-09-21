namespace GOL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCellCount = new System.Windows.Forms.TextBox();
            this.txtAvgFrameTime = new System.Windows.Forms.TextBox();
            this.txtNumOfStartCells = new System.Windows.Forms.TextBox();
            this.txtGens = new System.Windows.Forms.TextBox();
            this.txtGrowthPercent = new System.Windows.Forms.TextBox();
            this.txtGrowthCells = new System.Windows.Forms.TextBox();
            this.txtMaxGrowthPercent = new System.Windows.Forms.TextBox();
            this.txtMaxGrowthCells = new System.Windows.Forms.TextBox();
            this.txtMaxGrowthGeneration = new System.Windows.Forms.TextBox();
            this.txtMaxCellCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCellCount
            // 
            this.txtCellCount.BackColor = System.Drawing.Color.Black;
            this.txtCellCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCellCount.ForeColor = System.Drawing.Color.White;
            this.txtCellCount.Location = new System.Drawing.Point(168, 12);
            this.txtCellCount.Name = "txtCellCount";
            this.txtCellCount.Size = new System.Drawing.Size(142, 25);
            this.txtCellCount.TabIndex = 1;
            // 
            // txtAvgFrameTime
            // 
            this.txtAvgFrameTime.BackColor = System.Drawing.Color.Black;
            this.txtAvgFrameTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAvgFrameTime.ForeColor = System.Drawing.Color.White;
            this.txtAvgFrameTime.Location = new System.Drawing.Point(23, 41);
            this.txtAvgFrameTime.Name = "txtAvgFrameTime";
            this.txtAvgFrameTime.Size = new System.Drawing.Size(139, 25);
            this.txtAvgFrameTime.TabIndex = 2;
            this.txtAvgFrameTime.TextChanged += new System.EventHandler(this.txtAvgFrameTime_TextChanged);
            // 
            // txtNumOfStartCells
            // 
            this.txtNumOfStartCells.BackColor = System.Drawing.Color.Black;
            this.txtNumOfStartCells.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNumOfStartCells.ForeColor = System.Drawing.Color.White;
            this.txtNumOfStartCells.Location = new System.Drawing.Point(23, 12);
            this.txtNumOfStartCells.Name = "txtNumOfStartCells";
            this.txtNumOfStartCells.Size = new System.Drawing.Size(139, 25);
            this.txtNumOfStartCells.TabIndex = 3;
            // 
            // txtGens
            // 
            this.txtGens.BackColor = System.Drawing.Color.Black;
            this.txtGens.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtGens.ForeColor = System.Drawing.Color.White;
            this.txtGens.Location = new System.Drawing.Point(168, 41);
            this.txtGens.Name = "txtGens";
            this.txtGens.Size = new System.Drawing.Size(142, 25);
            this.txtGens.TabIndex = 4;
            // 
            // txtGrowthPercent
            // 
            this.txtGrowthPercent.BackColor = System.Drawing.Color.Black;
            this.txtGrowthPercent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtGrowthPercent.ForeColor = System.Drawing.Color.White;
            this.txtGrowthPercent.Location = new System.Drawing.Point(316, 12);
            this.txtGrowthPercent.Name = "txtGrowthPercent";
            this.txtGrowthPercent.Size = new System.Drawing.Size(132, 25);
            this.txtGrowthPercent.TabIndex = 5;
            this.txtGrowthPercent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtGrowthCells
            // 
            this.txtGrowthCells.BackColor = System.Drawing.Color.Black;
            this.txtGrowthCells.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtGrowthCells.ForeColor = System.Drawing.Color.White;
            this.txtGrowthCells.Location = new System.Drawing.Point(454, 12);
            this.txtGrowthCells.Name = "txtGrowthCells";
            this.txtGrowthCells.Size = new System.Drawing.Size(161, 25);
            this.txtGrowthCells.TabIndex = 6;
            // 
            // txtMaxGrowthPercent
            // 
            this.txtMaxGrowthPercent.BackColor = System.Drawing.Color.Black;
            this.txtMaxGrowthPercent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMaxGrowthPercent.ForeColor = System.Drawing.Color.White;
            this.txtMaxGrowthPercent.Location = new System.Drawing.Point(316, 41);
            this.txtMaxGrowthPercent.Name = "txtMaxGrowthPercent";
            this.txtMaxGrowthPercent.Size = new System.Drawing.Size(132, 25);
            this.txtMaxGrowthPercent.TabIndex = 7;
            // 
            // txtMaxGrowthCells
            // 
            this.txtMaxGrowthCells.BackColor = System.Drawing.Color.Black;
            this.txtMaxGrowthCells.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMaxGrowthCells.ForeColor = System.Drawing.Color.White;
            this.txtMaxGrowthCells.Location = new System.Drawing.Point(454, 41);
            this.txtMaxGrowthCells.Name = "txtMaxGrowthCells";
            this.txtMaxGrowthCells.Size = new System.Drawing.Size(161, 25);
            this.txtMaxGrowthCells.TabIndex = 8;
            // 
            // txtMaxGrowthGeneration
            // 
            this.txtMaxGrowthGeneration.BackColor = System.Drawing.Color.Black;
            this.txtMaxGrowthGeneration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMaxGrowthGeneration.ForeColor = System.Drawing.Color.White;
            this.txtMaxGrowthGeneration.Location = new System.Drawing.Point(621, 41);
            this.txtMaxGrowthGeneration.Name = "txtMaxGrowthGeneration";
            this.txtMaxGrowthGeneration.Size = new System.Drawing.Size(167, 25);
            this.txtMaxGrowthGeneration.TabIndex = 9;
            // 
            // txtMaxCellCount
            // 
            this.txtMaxCellCount.BackColor = System.Drawing.Color.Black;
            this.txtMaxCellCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMaxCellCount.ForeColor = System.Drawing.Color.White;
            this.txtMaxCellCount.Location = new System.Drawing.Point(621, 12);
            this.txtMaxCellCount.Name = "txtMaxCellCount";
            this.txtMaxCellCount.Size = new System.Drawing.Size(167, 25);
            this.txtMaxCellCount.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 891);
            this.Controls.Add(this.txtMaxCellCount);
            this.Controls.Add(this.txtMaxGrowthGeneration);
            this.Controls.Add(this.txtMaxGrowthCells);
            this.Controls.Add(this.txtMaxGrowthPercent);
            this.Controls.Add(this.txtGrowthCells);
            this.Controls.Add(this.txtGrowthPercent);
            this.Controls.Add(this.txtGens);
            this.Controls.Add(this.txtNumOfStartCells);
            this.Controls.Add(this.txtAvgFrameTime);
            this.Controls.Add(this.txtCellCount);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtCellCount;
        private TextBox txtAvgFrameTime;
        private TextBox txtNumOfStartCells;
        private TextBox txtGens;
        private TextBox txtGrowthPercent;
        private TextBox txtGrowthCells;
        private TextBox txtMaxGrowthPercent;
        private TextBox txtMaxGrowthCells;
        private TextBox txtMaxGrowthGeneration;
        private TextBox txtMaxCellCount;
    }
}