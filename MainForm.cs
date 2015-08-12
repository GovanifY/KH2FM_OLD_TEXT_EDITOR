using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BAR_Editor;
using System.IO;
using System.Linq;
using Eventviewer_Editor;


namespace KH2FM_TEXT_EDITOR
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private BAR.BARFile b;
        private BAR bar = null;
        private string fileName;
        private uint newentry;
        private uint nentriesStr;
        internal Dictionary<uint, STRING> STRINGS = new Dictionary<uint, STRING>();
        internal Dictionary<uint, STRING> STRINGS2 = new Dictionary<uint, STRING>();
		private static readonly System.Diagnostics.FileVersionInfo program = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
		public MainForm()
		{
			InitializeComponent();
			this.Text = program.ProductName + " " + program.FileVersion + " [" + program.CompanyName + "]";
		}
		        private void Cleanup()
        {
                this.buttonSave.Enabled =
                this.buttonImport.Enabled =
            	this.buttonExport.Enabled = false;
                this.listText.Items.Clear();
                STRINGS.Clear();
        }

        private void SetUp()
        {
                this.buttonSave.Enabled =
                this.buttonImport.Enabled =
            	this.buttonExport.Enabled = true;
        }
         private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BAR file|*.bar|BIN file|*.bin";
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = "bar";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog1.FileName, openFileDialog1.ReadOnlyChecked);
            }
        }

        private void buttonOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void buttonOpen_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[]) (e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    if (System.IO.File.Exists(fileLoc))
                    {
                        openFile(fileLoc);
                        break;
                    }
                }
            }
        }
                private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "BAR file|*.bar|BIN file|*.bin";
            saveFileDialog1.FileName = "";
            saveFileDialog1.DefaultExt = "bar";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //RebuildFile(saveFileDialog1.FileName);
            }
        }
                private void openFile(string filename, bool ro = false)
                {
                	    try
            {
                Cleanup();
                try
                {
                    bar =
                        new BAR(System.IO.File.Open(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read,
                            System.IO.FileShare.None));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Fatal error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bar = null;
                    return;
                }
                fileName = System.IO.Path.GetFileName(filename);
                b = this.bar.fileList[0];
                //Now let's extract the file
                if (bar.fileCount != 2)
                {
                    MessageBox.Show("This BAR file doesn't exactly contains two files!\nAre you sure it is a text file?",
                        "Fatal error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bar = null;
                    return;
                }
                               string nameextractedtext =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        System.IO.Path.GetTempFileName());
                try
                {
                    System.IO.File.WriteAllBytes(nameextractedtext, b.data);
                }
                catch
                {
                    MessageBox.Show(
                        "String file can't be extracted in temp folder!\nDo you have enough access to write in the TEMP folder?",
                        "Fatal error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bar = null;
                    return;
                }
                BinaryReader br = new BinaryReader(new FileStream(nameextractedtext, FileMode.Open));
            br.BaseStream.Position = 0;
            var version = br.ReadUInt32();
            nentriesStr = br.ReadUInt32();
            bool jap = false;
            for (int i = 0; i < nentriesStr; i++)
            {
                var Contents = new STRING();
                Contents.ID = br.ReadUInt32();
                var brpos = br.BaseStream.Position + 4;
                br.BaseStream.Position = br.ReadUInt32();
                //Contents.Offset = (uint) br.BaseStream.Position;
                //MessageBox.Show(Contents.Offset.ToString(), nameextractedstr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bar = null;
                byte c = br.ReadByte();
                while (true)
                {
                    Contents.text = Contents.bytetotext(c, Contents.text, jap);
                        c = br.ReadByte();
                    if (c == 0)
                    {
                        goto next;
                    }
                }
                next:
                //MessageBox.Show(Contents.text, nameextractedstr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bar = null;
                if (Jap_mapping.Checked){jap = true;}
                STRINGS.Add(Contents.ID, Contents);
                br.BaseStream.Position = brpos;
                this.listText.Items.Add(Contents.ID.ToString("X4"));
            }
                SetUp();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fatal error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bar = null;
            }
                }
                   
                private void listText_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = "";
            retry:
            try { curItem = listText.SelectedItem.ToString(); }
            catch { listText.SelectedIndex = 0; goto retry; }
            uint key = Convert.ToUInt16(curItem, 16);
            if (STRINGS.ContainsKey(key))
            {
                var Values = STRINGS[key];
                this.textBox1.Text  = Values.text;
            }
            else
            {
                MessageBox.Show("Contents of the strings cannot be loaded!", "Fatal error opening file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bar = null;
                return;
            }
        }
                        private void listText_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listText.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    listText.SelectedIndex = item;
                    contextMenuStrip1.Show(listText, e.Location);
                }
            }
        }
                                private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        string curItem = listText.SelectedItem.ToString();
            uint key = Convert.ToUInt16(curItem, 16);
            if (STRINGS.ContainsKey(key))
            {
                STRINGS.Remove(key);
            }
            int i = this.listText.SelectedIndex;
            if (i != -1)
            { listText.Items.RemoveAt(i); }
            try { this.listText.SelectedIndex = i + 1; }
            catch { this.listText.SelectedIndex = 1; }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Contents = new STRING();
            foreach (var entry2 in STRINGS)
                STRINGS2.Add(entry2.Value.ID, entry2.Value);
            STRINGS.Clear();
            int y = this.listText.SelectedIndex + 1;
            int i = 0;
            listText.BeginUpdate();
            listText.Items.Clear();
            foreach (var entry in STRINGS2)
            {
                i++;
                if (i == y)
                {
                    Contents.ID = 0x5500 + newentry;
                    Contents.Offset = 0;
                    Contents.data = new byte[] {0x01};
                    Contents.lastbyte = 0;
                    Contents.lastbyte2 = 0;
                    Contents.text = "New entry" + newentry;
                    STRINGS.Add(entry.Value.ID, entry.Value);
                    this.listText.Items.Add(entry.Value.ID.ToString("X4"));
                }
                else
                {
                    STRINGS.Add(entry.Value.ID, entry.Value);
                    this.listText.Items.Add(entry.Value.ID.ToString("X4"));
                }
            }
            newentry++;
            nentriesStr++;
            STRINGS2.Clear();
            listText.SelectedItem = Contents.ID.ToString("X4");
            listText.EndUpdate();
        }
	}
}
	
