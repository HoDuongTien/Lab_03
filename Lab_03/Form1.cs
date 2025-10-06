using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateRichTextBoxFont() {
            if (cmbFonts.SelectedItem != null && cmbSizes.SelectedItem != null)
            {
                string selectedFont = cmbFonts.SelectedItem.ToString();
                float selectedSize = Convert.ToSingle(cmbSizes.SelectedItem);

                richTextBox1.SelectionFont = new Font(selectedFont, selectedSize);
            }
        }
        private string currentFile = "";   

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                DinhDang.ForeColor = fontDlg.Color;
                DinhDang.Font = fontDlg.Font;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
            cmbFonts.SelectedItem = "Tahoma";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28 };
            foreach (int size in fontSizes)
            {
                cmbSizes.Items.Add(size);
            }
            cmbSizes.SelectedItem = 14;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void tạoVănToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            cmbFonts.Text = "Tahoma";
            cmbSizes.Text = "14";
            DinhDang.Font = new Font("Tahoma", 14);
            currentFile = "";
        }
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                currentFile = openFile.FileName;
                if (openFile.FileName.EndsWith(".rtf"))
                    richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Rich Text Format (*.rtf)|*.rtf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    currentFile = saveFile.FileName;
                    richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Đã lưu tập tin thành công!", "Thông báo");
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo");
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            cmbFonts.SelectedItem = "Tahoma";
            cmbSizes.SelectedItem = 14;
            UpdateRichTextBoxFont();
            //end
            //end
        }
    }
}
