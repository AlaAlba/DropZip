
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
            this.textBoxOutDir = new System.Windows.Forms.TextBox();
            this.labelOutDir = new System.Windows.Forms.Label();
            this.labelDragSpace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxOutDir
            // 
            this.textBoxOutDir.Location = new System.Drawing.Point(96, 6);
            this.textBoxOutDir.Name = "textBoxOutDir";
            this.textBoxOutDir.Size = new System.Drawing.Size(313, 19);
            this.textBoxOutDir.TabIndex = 1;
            this.textBoxOutDir.TextChanged += new System.EventHandler(this.textBoxOutDir_TextChanged);
            // 
            // labelOutDir
            // 
            this.labelOutDir.AutoSize = true;
            this.labelOutDir.Location = new System.Drawing.Point(12, 9);
            this.labelOutDir.Name = "labelOutDir";
            this.labelOutDir.Size = new System.Drawing.Size(78, 12);
            this.labelOutDir.TabIndex = 3;
            this.labelOutDir.Text = "出力ディレクトリ";
            // 
            // labelDragSpace
            // 
            this.labelDragSpace.AllowDrop = true;
            this.labelDragSpace.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelDragSpace.Location = new System.Drawing.Point(14, 43);
            this.labelDragSpace.Name = "labelDragSpace";
            this.labelDragSpace.Size = new System.Drawing.Size(395, 229);
            this.labelDragSpace.TabIndex = 4;
            this.labelDragSpace.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.labelDragSpace.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 278);
            this.Controls.Add(this.labelDragSpace);
            this.Controls.Add(this.labelOutDir);
            this.Controls.Add(this.textBoxOutDir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxOutDir;
        private System.Windows.Forms.Label labelOutDir;
        private System.Windows.Forms.Label labelDragSpace;
    }
}

