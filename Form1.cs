using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows; // Or use whatever point class you like for the implicit cast operator
using System.IO;

/// <summary>
/// Struct representing a point.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;

    public static implicit operator Point(POINT point)
    {
        return new Point(point.X, point.Y);
    }
}

namespace ebook2pdf
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //SelectArea area = new SelectArea(GetCursorPosition());
            //this.Hide();
            //area.Show();
            
        }


        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = GetCursorPosition();
            label2.Text="POSIZIONE MOUSE: " + p.X.ToString() + ";" + p.Y.ToString();
        }

        private void frmHome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.F3)
            {
                if (!Directory.Exists(textBox2.Text))
                    Directory.CreateDirectory(textBox2.Text);
                SelectArea area = new SelectArea(GetCursorPosition(), textBox1.Text, textBox2.Text, textBox3.Text);
                this.Hide();
                area.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\libro\\";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
