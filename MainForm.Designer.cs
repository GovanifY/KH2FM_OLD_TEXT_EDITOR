/*
 * Created by SharpDevelop.
 * User: User
 * Date: 29/11/2014
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace KH2FM_TEXT_EDITOR
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox listText;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonNew;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.RadioButton Eur_mapping;
		private System.Windows.Forms.RadioButton Jap_mapping;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button buttonChars;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listText = new System.Windows.Forms.ListBox();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonNew = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.Eur_mapping = new System.Windows.Forms.RadioButton();
			this.Jap_mapping = new System.Windows.Forms.RadioButton();
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.buttonChars = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 254);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(542, 20);
			this.textBox1.TabIndex = 0;
			// 
			// listText
			// 
			this.listText.FormattingEnabled = true;
			this.listText.Location = new System.Drawing.Point(22, 41);
			this.listText.Name = "listText";
			this.listText.Size = new System.Drawing.Size(243, 199);
			this.listText.TabIndex = 1;
			this.listText.SelectedIndexChanged += new System.EventHandler(this.listText_SelectedIndexChanged);
			this.listText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listText_MouseUp);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(22, 12);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 2;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			this.buttonOpen.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonOpen_DragDrop);
			this.buttonOpen.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonOpen_DragEnter);
			// 
			// buttonNew
			// 
			this.buttonNew.Location = new System.Drawing.Point(103, 12);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new System.Drawing.Size(75, 23);
			this.buttonNew.TabIndex = 3;
			this.buttonNew.Text = "New...";
			this.buttonNew.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(184, 12);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save as...";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// Eur_mapping
			// 
			this.Eur_mapping.Location = new System.Drawing.Point(271, 41);
			this.Eur_mapping.Name = "Eur_mapping";
			this.Eur_mapping.Size = new System.Drawing.Size(146, 24);
			this.Eur_mapping.TabIndex = 5;
			this.Eur_mapping.TabStop = true;
			this.Eur_mapping.Text = "European String Mapping";
			this.Eur_mapping.UseVisualStyleBackColor = true;
			this.Eur_mapping.Checked = true;
			// 
			// Jap_mapping
			// 
			this.Jap_mapping.Location = new System.Drawing.Point(271, 71);
			this.Jap_mapping.Name = "Jap_mapping";
			this.Jap_mapping.Size = new System.Drawing.Size(146, 24);
			this.Jap_mapping.TabIndex = 5;
			this.Jap_mapping.TabStop = true;
			this.Jap_mapping.Text = "Japanese String Mapping";
			this.Jap_mapping.UseVisualStyleBackColor = true;
			// 
			// buttonExport
			// 
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(22, 281);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(105, 23);
			this.buttonExport.TabIndex = 7;
			this.buttonExport.Text = "Export as a txt";
			this.buttonExport.UseVisualStyleBackColor = true;
			// 
			// buttonImport
			// 
			this.buttonImport.Enabled = false;
			this.buttonImport.Location = new System.Drawing.Point(133, 280);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(105, 23);
			this.buttonImport.TabIndex = 8;
			this.buttonImport.Text = "Import a txt";
			this.buttonImport.UseVisualStyleBackColor = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.addToolStripMenuItem,
			this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// buttonChars
			// 
			this.buttonChars.Location = new System.Drawing.Point(436, 280);
			this.buttonChars.Name = "buttonChars";
			this.buttonChars.Size = new System.Drawing.Size(128, 23);
			this.buttonChars.TabIndex = 9;
			this.buttonChars.Text = "View special chars";
			this.buttonChars.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(576, 316);
			this.Controls.Add(this.buttonChars);
			this.Controls.Add(this.buttonImport);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.Eur_mapping);
			this.Controls.Add(this.Jap_mapping);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonNew);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.listText);
			this.Controls.Add(this.textBox1);
			this.Name = "MainForm";
			this.Text = "KH2FM_TEXT_EDITOR";
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
