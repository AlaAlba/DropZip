﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dragSpaceArea.Text = "ここにフォルダをドラッグしてください";
        }

        private void textBoxOutDir_TextChanged(object sender, EventArgs e)
        {

        }


        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// ドラッグ完了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new async void DragDrop(object sender, DragEventArgs e)
        {
            await semaphore.WaitAsync(); // ロックを取得

            try
            {
                // フォルダ名を取得する
                string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                // ドロップされたフォルダ分処理を行う
                for (int i = 0; i < folders.Length; i++)
                {
                    string folderPath = folders[i];

                    string folderName = Path.GetFileName(folderPath);

                    // 出力先に同名のファイルが存在している場合は処理を行わない
                    var fileExits = Directory
                        .GetFiles(this.outDirTextBox.Text, $"{folderName}*")
                        .Any();

                    if (fileExits)
                    {
                        resultTextBox.Text += $"{folderName} は既に存在しています。\r\n";
                    }
                    else
                    {
                        // 非同期でZipファイル作成を行う
                        var result = await CreateZipFile(
                            folderPath,
                            Path.Combine(this.outDirTextBox.Text, folderName + ".zip")
                        );

                        if (result)
                        {
                            resultTextBox.Text += folderPath + " Done! \r\n";
                        }

                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
            
        }

        /// <summary>
        /// ドラッグ＆ドロップしたときのイベント（受け入れチェック）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void DragEnter(object sender, DragEventArgs e)
        {
            // 正しい出力ディレクトリが指定されていなければ受け入れない
            if (!Directory.Exists(outDirTextBox.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // フォルダ以外がドロップされた場合は受け入れない
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            bool isFolder = true;

            foreach (string file in files)
            {
                if (!System.IO.Directory.Exists(file))
                {
                    isFolder = false;
                    break;
                }
            }

            if (isFolder)
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
        /// <param name="srcFolderPath">Zip化するフォルダのパス(絶対パス)</param>
        /// <param name="dstFilePath">Zip化後のファイルのパス(絶対パス)</param>
        /// <returns></returns>
        private async Task<Boolean> CreateZipFile(string srcFolderPath, string dstFilePath)
        {
            // TODO: 例外処理 (現在は常にtrueを返す)

            await Task.Run(() =>
            {
                // Zip化
                ZipFile.CreateFromDirectory(
                    srcFolderPath,
                    dstFilePath
                );
            });

            return true;
        }

        /// <summary>
        /// 結果表示スペースのテキストをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
        }
    }
}
