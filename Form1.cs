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
        private async void DragDrop(object sender, DragEventArgs e)
        {
            // dragSpaceArea.Text = "";

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
                    // 非同期でZipファイル作成を行う
                    var result = await CreateZipFile(
                        filePath,
                        Path.Combine(this.outDirTextBox.Text, fileName + ".zip")
                    );

                    if (result)
                    {
                        dragSpaceArea.Text += filePath + " Done! \r\n";
                    }

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

        /// <summary>
        /// Zipファイルの作成
        /// </summary>
        /// <param name="srcFilePath">Zip化するフォルダのパス(絶対パス)</param>
        /// <param name="dstFilePath">ZIp化後のファイルのパス(絶対パス)</param>
        /// <returns></returns>
        private async Task<Boolean> CreateZipFile(string srcFilePath, string dstFilePath)
        {
            // TODO: 例外処理

            await Task.Run(() =>
            {
                // Zip化
                ZipFile.CreateFromDirectory(
                    srcFilePath,
                    dstFilePath
                );
            });

            return true;
        }
    }
}
