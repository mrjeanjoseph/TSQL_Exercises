namespace Pluralsight.CShPlaybook.Oop;

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
			this.lbxModels = new System.Windows.Forms.ListBox();
			this.pbxPhoto = new System.Windows.Forms.PictureBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblOwner = new System.Windows.Forms.Label();
			this.tbxName = new System.Windows.Forms.TextBox();
			this.tbxHuman = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// lbxModels
			// 
			this.lbxModels.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbxModels.FormattingEnabled = true;
			this.lbxModels.ItemHeight = 32;
			this.lbxModels.Location = new System.Drawing.Point(12, 12);
			this.lbxModels.Name = "lbxModels";
			this.lbxModels.Size = new System.Drawing.Size(228, 420);
			this.lbxModels.TabIndex = 0;
			this.lbxModels.SelectedIndexChanged += new System.EventHandler(this.lbxModels_SelectedIndexChanged);
			// 
			// pbxPhoto
			// 
			this.pbxPhoto.Location = new System.Drawing.Point(388, 12);
			this.pbxPhoto.Name = "pbxPhoto";
			this.pbxPhoto.Size = new System.Drawing.Size(400, 338);
			this.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbxPhoto.TabIndex = 1;
			this.pbxPhoto.TabStop = false;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblName.Location = new System.Drawing.Point(388, 363);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(83, 32);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name:";
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblOwner.Location = new System.Drawing.Point(246, 400);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(228, 32);
			this.lblOwner.TabIndex = 3;
			this.lblOwner.Text = "Companion Human:";
			// 
			// tbxName
			// 
			this.tbxName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbxName.Location = new System.Drawing.Point(480, 356);
			this.tbxName.Name = "tbxName";
			this.tbxName.Size = new System.Drawing.Size(308, 39);
			this.tbxName.TabIndex = 4;
			// 
			// tbxHuman
			// 
			this.tbxHuman.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbxHuman.Location = new System.Drawing.Point(480, 400);
			this.tbxHuman.Name = "tbxHuman";
			this.tbxHuman.Size = new System.Drawing.Size(308, 39);
			this.tbxHuman.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tbxHuman);
			this.Controls.Add(this.tbxName);
			this.Controls.Add(this.lblOwner);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.pbxPhoto);
			this.Controls.Add(this.lbxModels);
			this.Name = "Form1";
			this.Text = "Models";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private ListBox lbxModels;
	private PictureBox pbxPhoto;
	private Label lblName;
	private Label lblOwner;
	private TextBox tbxName;
	private TextBox tbxHuman;
}
