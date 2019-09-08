using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;

    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += new EventHandler(ButOpenFile_Click);
            butSaveFile.Click += new EventHandler(ButSave_Click);
            fldContent.TextChanged += new EventHandler(FldContent_TextChanged);
            butSelectFile.Click += new EventHandler(ButSelectFile_Click);
            numFont.ValueChanged += new EventHandler(NumFont_ValueChanged);
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }

        #region Проброс событий
        private void FldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm
        public string FilePath
        {
            get { return filePathSelection.Text; }
        }

        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }

        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePathSelection.Text = dlg.FileName;

                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
