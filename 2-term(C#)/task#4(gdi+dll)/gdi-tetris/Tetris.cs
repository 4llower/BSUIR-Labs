using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace subtask_1
{
    class Tetris
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        private const int valueBlocksHeight = 10;
        private const int valueBlocksWidth = 5;
        private const int blockSize = 50;

        private int topX;
        private int topY;

        private int curX = 0;
        private int curY = 0;

        private int score = 0;
        private System.Timers.Timer timer;
        private Pen penBlocks = new Pen(Brushes.Yellow) 
        { 
            Width = 1
        };
        private Pen penBackground = new Pen(Brushes.Black)
        {
            Width = 1
        };

        private int[,] blocks = new int[valueBlocksWidth, valueBlocksHeight];

        public Tetris(int x, int y)
        {
            /* Pixel(0, 0) in desktop window */
            topX = x;
            topY = y;
            
            /* Timer declaration */
            timer = new System.Timers.Timer(500);
            timer.Elapsed += DrawField;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void DrawField(Object source, ElapsedEventArgs e)
        {
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics graphics = Graphics.FromHdc(desktopDC);
            DrawBackground(topX, topY, graphics);
            graphics.DrawString(score.ToString(), new Font("Arial", 16), Brushes.Yellow, new PointF(topX + blockSize * (valueBlocksWidth - 1), topY));

            CheckLineCollected();

            for (int i = 0; i < valueBlocksWidth; ++i)
            {
                for (int j = 0; j < valueBlocksHeight; ++j)
                {
                    if (blocks[i, j] != 0)
                    {
                        DrawBlock(topX + i * blockSize, topY + j * blockSize, graphics);
                    }
                }
            }

            if (curY == valueBlocksHeight - 1)
            {
                blocks[curX, curY] = 1;
                curX = 0;
                curY = 0;
                return;
            }

            if (blocks[curX, curY + 1] != 0)
            {
                blocks[curX, curY] = 1;
                curX = 0;
                curY = 0;
                return;
            }

            curY++;

            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                if (curX == 0) return;
                if (blocks[curX - 1, curY] != 0) return;
                curX--;
                DrawBlock(topX + curX * blockSize, topY + curY * blockSize, graphics);
                return;
            }

            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                if (curX == valueBlocksWidth - 1) return;
                if (blocks[curX + 1, curY] != 0) return;
                curX++;
                DrawBlock(topX + curX * blockSize, topY + curY * blockSize, graphics);
                return;
            }
            DrawBlock(topX + curX * blockSize, topY + curY * blockSize, graphics);
        }

        private void CheckLineCollected()
        {
            bool isLine = true;
            for (int i = 0; i < valueBlocksWidth; ++i) 
            {
                if (blocks[i, valueBlocksHeight - 1] == 0)
                {
                    isLine = false;
                    break;
                }
            }
            if (isLine)
            {
                score += valueBlocksWidth;
                for (int i = 0; i < valueBlocksWidth; ++i) blocks[i, valueBlocksHeight - 1] = 0;

                for (int j = valueBlocksHeight - 1; j >= 1; j--)
                {
                    for (int i = 0; i < valueBlocksWidth; ++i) 
                    {
                        if (blocks[i, j] == 0)
                        {
                            if (blocks[i, j - 1] == 1)
                            {
                                Swap<int>(ref blocks[i, j - 1], ref blocks[i, j]);
                            }
                        }
                    }
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        private void DrawBlock(int x, int y, Graphics graphics)
        {
            Rectangle rect = new Rectangle(x, y, blockSize, blockSize);
            graphics.FillRectangle(Brushes.Yellow, rect);
            graphics.DrawRectangle(penBlocks, rect);
        }

        private void DrawBackground(int x, int y, Graphics graphics)
        {
            Rectangle rect = new Rectangle(x, y, valueBlocksWidth * blockSize, valueBlocksHeight * blockSize);
            graphics.FillRectangle(Brushes.Black, rect);
            graphics.DrawRectangle(penBackground, rect);
        }
    }
}
