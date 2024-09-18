namespace Pluralsight.CShPlaybook.AsyncDemo;

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
			this.lbxCourses = new System.Windows.Forms.ListBox();
			this.btnLoadCourseNames = new System.Windows.Forms.Button();
			this.tbxTypeStuff = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbxCoursesWithLinq = new System.Windows.Forms.ListBox();
			this.lbxCoursesNoLinq = new System.Windows.Forms.ListBox();
			this.btnSearchForLinq = new System.Windows.Forms.Button();
			this.lblSearchStatus = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lblLoadStatus = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbxCourses
			// 
			this.lbxCourses.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbxCourses.FormattingEnabled = true;
			this.lbxCourses.ItemHeight = 32;
			this.lbxCourses.Location = new System.Drawing.Point(6, 62);
			this.lbxCourses.Name = "lbxCourses";
			this.lbxCourses.Size = new System.Drawing.Size(466, 484);
			this.lbxCourses.TabIndex = 0;
			// 
			// btnLoadCourseNames
			// 
			this.btnLoadCourseNames.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnLoadCourseNames.Location = new System.Drawing.Point(3, 6);
			this.btnLoadCourseNames.Name = "btnLoadCourseNames";
			this.btnLoadCourseNames.Size = new System.Drawing.Size(237, 50);
			this.btnLoadCourseNames.TabIndex = 1;
			this.btnLoadCourseNames.Text = "Load course names";
			this.btnLoadCourseNames.UseVisualStyleBackColor = true;
			this.btnLoadCourseNames.Click += new System.EventHandler(this.btnLoadCourseNames_Click);
			// 
			// tbxTypeStuff
			// 
			this.tbxTypeStuff.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbxTypeStuff.Location = new System.Drawing.Point(521, 91);
			this.tbxTypeStuff.Multiline = true;
			this.tbxTypeStuff.Name = "tbxTypeStuff";
			this.tbxTypeStuff.Size = new System.Drawing.Size(406, 154);
			this.tbxTypeStuff.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(521, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(391, 76);
			this.label1.TabIndex = 3;
			this.label1.Text = "Type stuff in this text box to check if UI is reponsive:";
			// 
			// lbxCoursesWithLinq
			// 
			this.lbxCoursesWithLinq.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbxCoursesWithLinq.FormattingEnabled = true;
			this.lbxCoursesWithLinq.ItemHeight = 32;
			this.lbxCoursesWithLinq.Location = new System.Drawing.Point(6, 94);
			this.lbxCoursesWithLinq.Name = "lbxCoursesWithLinq";
			this.lbxCoursesWithLinq.Size = new System.Drawing.Size(466, 164);
			this.lbxCoursesWithLinq.TabIndex = 4;
			// 
			// lbxCoursesNoLinq
			// 
			this.lbxCoursesNoLinq.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbxCoursesNoLinq.FormattingEnabled = true;
			this.lbxCoursesNoLinq.ItemHeight = 32;
			this.lbxCoursesNoLinq.Location = new System.Drawing.Point(3, 301);
			this.lbxCoursesNoLinq.Name = "lbxCoursesNoLinq";
			this.lbxCoursesNoLinq.Size = new System.Drawing.Size(469, 228);
			this.lbxCoursesNoLinq.TabIndex = 5;
			// 
			// btnSearchForLinq
			// 
			this.btnSearchForLinq.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnSearchForLinq.Location = new System.Drawing.Point(6, 6);
			this.btnSearchForLinq.Name = "btnSearchForLinq";
			this.btnSearchForLinq.Size = new System.Drawing.Size(129, 50);
			this.btnSearchForLinq.TabIndex = 6;
			this.btnSearchForLinq.Text = "Search for LINQ";
			this.btnSearchForLinq.UseVisualStyleBackColor = true;
			this.btnSearchForLinq.Click += new System.EventHandler(this.btnSearchForLinq_Click);
			// 
			// lblSearchStatus
			// 
			this.lblSearchStatus.AutoSize = true;
			this.lblSearchStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblSearchStatus.Location = new System.Drawing.Point(150, 15);
			this.lblSearchStatus.Name = "lblSearchStatus";
			this.lblSearchStatus.Size = new System.Drawing.Size(0, 32);
			this.lblSearchStatus.TabIndex = 9;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(503, 594);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblSearchStatus);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.btnSearchForLinq);
			this.tabPage1.Controls.Add(this.lbxCoursesWithLinq);
			this.tabPage1.Controls.Add(this.lbxCoursesNoLinq);
			this.tabPage1.Location = new System.Drawing.Point(4, 41);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(495, 549);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Search courses";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 266);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(167, 32);
			this.label4.TabIndex = 10;
			this.label4.Text = "Other courses:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(267, 32);
			this.label3.TabIndex = 9;
			this.label3.Text = "Courses featuring LINQ:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lblLoadStatus);
			this.tabPage2.Controls.Add(this.btnLoadCourseNames);
			this.tabPage2.Controls.Add(this.lbxCourses);
			this.tabPage2.Location = new System.Drawing.Point(4, 41);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(495, 549);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Load courses list";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// lblLoadStatus
			// 
			this.lblLoadStatus.AutoSize = true;
			this.lblLoadStatus.Location = new System.Drawing.Point(246, 15);
			this.lblLoadStatus.Name = "lblLoadStatus";
			this.lblLoadStatus.Size = new System.Drawing.Size(0, 32);
			this.lblLoadStatus.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 614);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbxTypeStuff);
			this.Name = "Form1";
			this.Text = "Async demo";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private ListBox lbxCourses;
	private Button btnLoadCourseNames;
	private TextBox tbxTypeStuff;
	private Label label1;
	private ListBox lbxCoursesWithLinq;
	private ListBox lbxCoursesNoLinq;
	private Button btnSearchForLinq;
	private Label lblSearchStatus;
	private TabControl tabControl1;
	private TabPage tabPage1;
	private TabPage tabPage2;
	private Label label4;
	private Label label3;
	private Label lblLoadStatus;
}
