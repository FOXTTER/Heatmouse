using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using ExtensionMethods;
namespace HeatMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class drawParams {
            public int[,] rawData { get;set; }
            public Bitmap container { get; set; }
            public int radius { get; set; }
            public int bredde { get; set; }
            public int højde { get; set; }
            public int off { get; set; }
        };
        int bredde = 1920;
        int højde = 1080;
        //Bitmap heatmap = new Bitmap(1920, 1080);
        int[,] XY = new int[1920, 1080];
        //int r = 20;
        private void mouseKeyEventProvider1_MouseClick(object sender, MouseEventArgs e)
        {
            //Try to increase the heatmap factor for the mouse position
            //An exception will be thrown if the mouse is on a different screen than the primary
            try
            {
                XY[e.X, e.Y]++;
            }
            catch (Exception)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mouseKeyEventProvider1.Enabled = true;
            label1.Text = "Status: Tracker kører...";
            pictureBox2.BackColor = Color.FromArgb(0, 254, 0);
        }
        
        private void Stop_Click(object sender, EventArgs e)
        {
            mouseKeyEventProvider1.Enabled = false;
            label1.Text = "Status: Tracker kører ikke";
            pictureBox2.BackColor = Color.Red;
        }

        /// <summary>
        /// The function which set the color of the pixel in the heatmap
        /// </summary>
        /// <param name="styrke">The value to map a color to</param>
        /// <param name="max">The maximum value to scale to</param>
        /// <param name="offset">The offset off the color (higher = redder)</param>
        /// <returns></returns>
        public Color getColor(double styrke,double max,double offset)
        {
            Color res = new Color();
            max += offset;
            styrke += offset;
            if (styrke > 0.5 * max)
            {
                int val = 254-Remap(styrke, (0.5 * max), max, 0, 254);
                res = Color.FromArgb(254, val, 0);
            }
            else
            {
                //int val = (styrke*254)/(1+max/2);
                int val = Remap(styrke, 0, (max / 2), 0, 254);
                res = Color.FromArgb(val, 254, 0);
            }
            //res = Color.Red;
            return res;
        }
        Series series = new Series();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Gets the screen width and height and initiates the array
            try
            {
                var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                bredde = screen.Width;
                højde = screen.Height;
                XY = new int[bredde, højde];
                for (int i = 0; i < bredde; i++)
                {
                    for (int k = 0; k < højde; k++)
                    {
                        XY[i, k] = 0;
                    }
                }
            }
            catch (Exception k)
            {
                MessageBox.Show("Hey dude! skriv lige hvad den siger her:" + System.Environment.NewLine + k.Message + System.Environment.NewLine + k.InnerException);
            }
        }

        /// <summary>
        /// Begins the drawing of the heatmap from the current values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void draw_Click(object sender, EventArgs e)
        {
            rad.Enabled = false;
            offset.Enabled = false;

            drawParams para = new drawParams()
            {
                rawData = XY,
                bredde = bredde,
                højde = højde,
                radius = (int)rad.Value,
                off = (int)offset.Value
            };
            imageDrawer.RunWorkerAsync(para);
        }
        public int Remap (double value, double from1, double to1, double from2, double to2)
        {
            return (int)(((value - from1) * (to2 - from2)) / (to1 - from1) + from2);
        }
        /// <summary>
        /// Creates and array of the screen clicks with the correct factors for each pixel,
        /// depending on the defined radius.
        /// </summary>
        /// <param name="ind">The array with all the clicks</param>
        /// <param name="radius">The radius each click will get</param>
        /// <returns></returns>
        public int[,] createData(int[,] ind, int radius)
        {
            int[,] temp = new int[ind.GetLength(0),ind.GetLength(1)];
            temp = temp.fill(0);
            for (int i = 0; i < ind.GetLength(0); i++)
            {
                for (int k = 0; k < ind.GetLength(1); k++)
                {
                    if (ind[i,k]>0)
                    {
                        for (int ii = i - radius; ii <= (i + radius); ii++)
                        {
                            for (int kk = k - radius; kk < (k + radius); kk++)
                            {
                                if (ii > 0 && kk > 0 && ii < bredde && kk < højde && Math.Sqrt(Math.Pow(i - ii, 2) + Math.Pow(k - kk, 2)) <= radius)
                                {
                                    temp[ii, kk] += ind[i, k];
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }
        /// <summary>
        /// The background worker which draws the bitmap, without freezing the GUI thread.
        /// Also updates the progress bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageDrawer_DoWork(object sender, DoWorkEventArgs e)
        {
            drawParams plotData = e.Argument as drawParams;
            Bitmap temp = new Bitmap(plotData.bredde, plotData.højde);
            LockBitmap lockBitmap = new LockBitmap(temp);
            lockBitmap.LockBits();
            //int[,] xy = plotData.rawData;
            int[,] xy = createData(plotData.rawData, plotData.radius);
            int max = xy.Cast<int>().Max();
            Color farve = Color.Black;
            int count = 0;
            int done = bredde*højde;
            for (int i = 0; i < bredde; i++)
            {
                for (int k = 0; k < højde; k++)
                {
                    imageDrawer.ReportProgress((count*100)/done);
                    count++;
                    if (xy[i, k] != 0)
                    {
                        farve = getColor(xy[i, k],max,plotData.off);
                        //Color farve = Color.Red;
                    }
                    else
                    {
                        farve = Color.Black;
                    }
                    lockBitmap.SetPixel(i, k, farve);
                }
            }
            lockBitmap.UnlockBits();
            e.Result = temp;
        }

        private void imageDrawer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void imageDrawer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = e.Result as Bitmap;
            progressBar1.Value = 0;
            rad.Enabled = true;
            offset.Enabled = true;
        }
        /// <summary>
        /// Resets the click factors in the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bredde; i++)
            {
                for (int k = 0; k < højde; k++)
                {
                    XY[i, k] = 0;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "HeatMap.png";
            saveFileDialog1.Filter = "png filer (*.png)|*.png";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }
        /// <summary>
        /// Initiates an array full of random values, for debugging the heatmap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rand = new Random(System.DateTime.Now.Second);
            for (int i = 0; i < (int)debugValue.Value; i++)
            {
                int x = rand.Next(0, bredde);
                int y = rand.Next(0, højde);
                XY[x, y]++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            debug.Enabled = !debug.Enabled;
            debugValue.Enabled = !debugValue.Enabled;
        }   

  }

    public class LockBitmap
    {
        Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // get total locked pixels count
                int PixelCount = Width * Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
                                             source.PixelFormat);

                // create byte array to copy pixel values
                int step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24) // For 24 bpp set Red, Green and Blue
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            // For 8 bpp set color value (Red, Green and Blue values are the same)
            {
                Pixels[i] = color.B;
            }
        }
    }
}
namespace ExtensionMethods
{
    public static class MyExtensions
    {
        /// <summary>
        /// Extends the integer array with the possibility to fill the array with a certain integer.
        /// </summary>
        /// <param name="datArray"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[,] fill(this int[,] datArray, int value)
        {
            int[,] temp = datArray;
            for (int i = 0; i < datArray.GetLength(0); i++)
            {
                for (int k = 0; k < datArray.GetLength(1); k++)
                {
                    temp[i, k] = value;
                }
            }
            return temp;
        }
    }
}
