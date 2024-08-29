using System;
using System.Drawing;
using System.Windows.Forms;

namespace NerSMBW_Tilegod_Assist_Tool
{
    public partial class Form1 : Form
    {
        private const int CellSize = 24; // 各セルのサイズを24x24ピクセルに設定
        private const int ImageSize = 384; // 画像サイズを384x384ピクセルに設定
        private Bitmap imageBitmap = null; // 読み込んだ画像を格納する変数


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }



        private void InitializeGrid()
        {
            int gridSize = ImageSize / CellSize; // グリッドサイズは16x16になる

            // 列と行の追加
            for (int i = 0; i < gridSize; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.Width = CellSize;
                dataGridView1.Columns.Add(col);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = CellSize;
            }

            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter; // マウスオーバーイベントを追加
        }

        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 有効なセル範囲内であることを確認
            {
                string message = $"({e.ColumnIndex}, {e.RowIndex})";
                string msgRow = $" {e.RowIndex}";
                string msgColumn = $" {e.ColumnIndex}";
                //
                //
                //this.Text = message; // フォームのタイトルバーにマス番号を表示
                columnBox.Text = msgColumn;
                rowBox.Text = msgRow;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PopulateGridWithImage()
        {
            if (imageBitmap == null)
                return;

            int gridSize = ImageSize / CellSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Rectangle cropArea = new Rectangle(col * CellSize, row * CellSize, CellSize, CellSize);
                    Bitmap cellImage = imageBitmap.Clone(cropArea, imageBitmap.PixelFormat);
                    DataGridViewImageCell cell = new DataGridViewImageCell();
                    cell.Value = cellImage;
                    dataGridView1[col, row] = cell;
                }
            }
        }










        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("version: β", "Version");
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This App is Assist Tool for Reggie Next(NewerMode)!" + "\r\n" + "Needs Exported 384 x 384 Tileset image from Puzzle !", "About App");
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ImageFiles (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageBitmap = new Bitmap(openFileDialog.FileName);
                    if (imageBitmap.Width != ImageSize || imageBitmap.Height != ImageSize)
                    {
                        MessageBox.Show("Image Pixel needs 384 x 384!" + "\n\r" + "Any other pixels are not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        imageBitmap = null;
                    }
                    else
                    {
                        PopulateGridWithImage();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}

