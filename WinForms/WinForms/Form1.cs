using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Shapes;
using WinForms.Utils;
using WinForms.CircleBL;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private bool isSave = false;
        private int pointX = 0;
        private int pointY = 0;
        private Graphics graphics;
        private SolidBrush brush;
        private List<Circle> listShape = new List<Circle>();
        private Circle circle;
        private Color color;

        public Form1()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.TryParse(textBox1.Text, out var radius))
                {
                    Circle item = new Circle();
                    item.Name = "Circle" + listShape.Count.ToString();
                    item.Radius = radius;
                    item.Centre = new Point(pointX, pointY);
                    item.CircleColor = color;

                    graphics.FillEllipse(brush, pointX - radius, pointY - radius,
                      radius + radius, radius + radius);

                    listShape.Add(item);

                    ToolStripItem subItem = new ToolStripMenuItem(item.Name);
                    shapesToolStripMenuItem.DropDownItems.Add(subItem);
                }
                else
                {
                    MessageBox.Show("Error! Radius must be number");
                }
            }
            panel1.BackColor = Color.White;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Error! Please enter radius");
                }
                else
                {
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {

                        brush = new SolidBrush(colorDialog.Color);
                        color = colorDialog.Color;
                        pointX = e.X;
                        pointY = e.Y;
                        isSave = false;
                        panel1_Paint(this, null);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (circle == null)
                {
                    MessageBox.Show("Please select circle!");
                }
                else
                {
                    listShape.Remove(circle);
                    circle.Move(e);
                    listShape.Add(circle);

                    textBox1.Clear();
                    panel1.Refresh();
                    foreach (var it in listShape)
                    {
                        graphics.FillEllipse(new SolidBrush(it.CircleColor), it.Centre.X - it.Radius, it.Centre.Y - it.Radius,
                     it.Radius + it.Radius, it.Radius + it.Radius);
                    }
                    isSave = false;
                }
            }
        }

        private void shapesToolStripMenuItem_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedname = e.ClickedItem.Text;
            circle = listShape.Find(x => x.Name == clickedname);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSave == false)
            {
                DialogResult result1 = MessageBox.Show("Is Dot Net Perls awesome?",
    "Important Question",
    MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    textBox1.Clear();
                    panel1.Refresh();
                    listShape.Clear();
                    shapesToolStripMenuItem.DropDownItems.Clear();
                    isSave = false;
                }
            }
            else
            {
                textBox1.Clear();
                panel1.Refresh();
                listShape.Clear();
                shapesToolStripMenuItem.DropDownItems.Clear();
                isSave = false;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = UI.CreateOpenFile();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            textBox1.Clear();
            panel1.Refresh();
            listShape = CircleBL.CircleBL.DeserializeList(openFileDialog.FileName);
            foreach (var it in listShape)
            {
                graphics.FillEllipse(new SolidBrush(it.CircleColor), it.Centre.X - it.Radius, it.Centre.Y - it.Radius,
                    it.Radius + it.Radius, it.Radius + it.Radius);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = UI.CreateSaveFile();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CircleBL.CircleBL.SerializeList(listShape, saveFileDialog.FileName);
                isSave = true;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UI.CreateInformationWindow() == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
