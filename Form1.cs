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

        /// <summary>
        /// ドラッグ完了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragDrop(object sender, DragEventArgs e)
        {
            dragSpaceArea.Text = "";

            // ドロップされたファイルのファイル名を取得する
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];

                string fileName = Path.GetFileNameWithoutExtension(filePath);

                var fileExits = Directory
                    .GetFiles(this.outDirTextBox.Text, $"{fileName}*")
                    .Any();

                if (fileExits)
                {
                    dragSpaceArea.Text += $"{fileName} は既に存在しています。\r\n";
                }
                else
                {
                    // Zip化
                    ZipFile.CreateFromDirectory(
                        filePath,
                        Path.Combine(this.outDirTextBox.Text, fileName + ".zip")
                        );
                    dragSpaceArea.Text += filePath + " Done! \r\n";

                }
            }


        }

        /// <summary>
        /// ドラッグ＆ドロップしたときのイベント（受け入れチェック）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragEnter(object sender, DragEventArgs e)
        {
            // 正しい出力ディレクトリが指定されていなければ受け入れない
            if (!Directory.Exists(outDirTextBox.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }


            // エクスプローラーからのファイルのドロップでなければ受け入れない
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
