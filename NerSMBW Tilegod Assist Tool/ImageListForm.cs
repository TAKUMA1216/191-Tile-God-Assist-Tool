using System;
using System.IO;
using System.Windows.Forms;


namespace NerSMBW_Tilegod_Assist_Tool
{
    public partial class ImageListForm : Form
    {
        private const int ImageSize = 384; // 画像のサイズ（ピクセル）
        private const int CellSize = 24;   // セルのサイズ（ピクセル）
        private Bitmap imageBitmap;        // 読み込んだ画像を格納
        private DataGridView dataGridView; // グリッド表示用のDataGridView

        public ImageListForm()
        {

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }


       


       



        private void ImageListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
