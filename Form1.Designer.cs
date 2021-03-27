
namespace DropZip
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.outDirTextBox = new System.Windows.Forms.TextBox();
            this.outDirLabel = new System.Windows.Forms.Label();
            this.dragSpaceArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outDirTextBox
            // 
            this.outDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outDirTextBox.Location = new System.Drawing.Point(96, 6);
            this.outDirTextBox.Name = "outDirTextBox";
            this.outDirTextBox.Size = new System.Drawing.Size(117, 19);
            this.outDirTextBox.TabIndex = 1;
            this.outDirTextBox.TextChanged += new System.EventHandler(this.textBoxOutDir_TextChanged);
            // 
            // outDirLabel
            // 
            this.outDirLabel.AutoSize = true;
            this.outDirLabel.Location = new System.Drawing.Point(12, 9);
            this.outDirLabel.Name = "outDirLabel";
            this.outDirLabel.Size = new System.Drawing.Size(78, 12);
            this.outDirLabel.TabIndex = 3;
            this.outDirLabel.Text = "出力ディレクトリ";
            // 
            // dragSpaceArea
            // 
            this.dragSpaceArea.AllowDrop = true;
            this.dragSpaceArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragSpaceArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dragSpaceArea.Location = new System.Drawing.Point(14, 43);
            this.dragSpaceArea.Name = "dragSpaceArea";
            this.dragSpaceArea.Size = new System.Drawing.Size(199, 59);
            this.dragSpaceArea.TabIndex = 4;
            this.dragSpaceArea.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.dragSpaceArea.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 108);
            this.Controls.Add(this.dragSpaceArea);
            this.Controls.Add(this.outDirLabel);
            this.Controls.Add(this.outDirTextBox);
            this.MinimumSize = new System.Drawing.Size(240, 120);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox outDirTextBox;
        private System.Windows.Forms.Label outDirLabel;
        private System.Windows.Forms.Label dragSpaceArea;
    }
}

