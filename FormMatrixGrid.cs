using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixGridPattern
{
    public partial class FormMatrixGrid : Form
    {
        public int m_width;//Width of the grid cell
        public int m_Height;//Height of the cell
        public int m_NoOfRows;//No of Rows
        public int m_NoOfColoumns;//No of Coloumns
        public int m_XOffset;//Offset from wwhich drawing starts
        public int m_YOffset;
        public int m_iCounter=2;
        public int m_iGridMaxSize=2;


        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 3;
        public const int DEFAULT_NO_COLS = 3;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        //public const int m_iCounter=2;
        //public const int m_iGridMaxSize=2;
        public FormMatrixGrid()
        {
            Initialize();
            InitializeComponent();
            bThreadStatus = false;
        }

        private void OnPaint(object sender, EventArgs e)
        {
            DrawGrid();
        }
        public void Initialize()
        {
            //put all the default values
            m_NoOfRows = DEFAULT_NO_ROWS;
            m_NoOfColoumns = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;
        }

        private void DrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Red);
            layoutPen.Width = 5;
            //boardLayout.DrawLine(layoutPen,0,0,100,0);
            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

                //Draw the Rows

                for (int i = 0; i <= m_iCounter; i++)
                {
                    boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_iCounter, Y);
                    Y = Y + m_Height;
                }

            X = DEFAULT_X_OFFSET;
            Y = DEFAULT_Y_OFFSET;


            //Draw the Coloums

            for (int j = 0; j <= m_iCounter; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_iCounter);
                X = X + m_width;
            }


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        { m_iGridMaxSize=3;
        
           
            this.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 4;
           
            this.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 5;
           
            this.Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 6;
           
            this.Refresh();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 7;
            
            this.Refresh();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        { m_iGridMaxSize=8;
    
            this.Refresh();
        }

        

        private void FormMatrixGrid_Load(object sender, EventArgs e)
        {

        }

        public void ThreadCounter()
        {
            
            try
            {
                while (true)
                {
                    m_iCounter++;

                    if (m_iCounter > m_iGridMaxSize) 
                    { 
                        m_iCounter = 2; 
                    }
                    Invalidate();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MatrixGrid = new Thread(new ThreadStart(ThreadCounter));
            MatrixGrid.Start();
            bThreadStatus = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            MatrixGrid.Suspend();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MatrixGrid.Resume();
        }
    }
}