using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxOutDir_TextChanged(object sender, EventArgs e)
        {

        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            labelDragSpace.Text = "";

            // ドロップされたファイルのファイル名を取得する
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];

                string fileName = Path.GetFileNameWithoutExtension(filePath);

                var fileExits = Directory
                    .GetFiles(this.textBoxOutDir.Text, $"{fileName}*")
                    .Any();

                if (fileExits)
                {
                    labelDragSpace.Text += $"{fileName} は既に存在しています。\r\n";
                }
                else
                {
                    // Zip化
                    ZipFile.CreateFromDirectory(
                        filePath,
                        Path.Combine(this.textBoxOutDir.Text, fileName + ".zip")
                        );
                    labelDragSpace.Text += filePath + " Done! \r\n";

                }
            }


        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            // 出力ディレクトリが指定されているときのみ、ドラッグ＆ドロップを受け入れる
            if (!Directory.Exists(textBoxOutDir.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }


            // エクスプローラーからのファイルのドロップの場合、ドラッグ＆ドロップを受け入れる
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
