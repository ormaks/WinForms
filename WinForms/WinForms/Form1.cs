using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinForms.Shapes;
using WinForms.Utils;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private bool _isSave;
        private int _pointX;
        private int _pointY;
        private readonly Graphics _graphics;
        private SolidBrush _brush;
        private List<Circle> _listShape = new List<Circle>();
        private Circle _circle;
        private Color _color;

        public Form1()
        {
            InitializeComponent();
            _graphics = panel1.CreateGraphics();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.TryParse(textBox1.Text, out var radius))
                {
                    Circle item = new Circle
                    {
                        Name = "Circle" + _listShape.Count,
                        Radius = radius,
                        Centre = new Point(_pointX, _pointY),
                        CircleColor = _color
                    };

                    _graphics.FillEllipse(_brush, _pointX - radius, _pointY - radius,
                        radius + radius, radius + radius);

                    _listShape.Add(item);

                    ToolStripItem subItem = new ToolStripMenuItem(item.Name);
                    shapesToolStripMenuItem.DropDownItems.Add(subItem);
                }
                else
                {
                    MessageBox.Show(@"Error! Radius must be number");
                }
            }

            panel1.BackColor = Color.White;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left when textBox1.Text == "":
                    MessageBox.Show(@"Error! Please enter radius");
                    break;

                case MouseButtons.Left:
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() != DialogResult.OK) return;

                    _brush = new SolidBrush(colorDialog.Color);
                    _color = colorDialog.Color;
                    _pointX = e.X;
                    _pointY = e.Y;
                    _isSave = false;
                    panel1_Paint(this, null);
                    break;

                case MouseButtons.Right when _circle == null:
                    MessageBox.Show(@"Please select circle!");
                    break;
                
                case MouseButtons.Right:
                    _listShape.Remove(_circle);
                    _circle.Move(e);
                    _listShape.Add(_circle);

                    textBox1.Clear();
                    panel1.Refresh();
                    foreach (var it in _listShape)
                    {
                        _graphics.FillEllipse(new SolidBrush(it.CircleColor), it.Centre.X - it.Radius,
                            it.Centre.Y - it.Radius,
                            it.Radius + it.Radius, it.Radius + it.Radius);
                    }

                    _isSave = false;
                    break;
            }
        }

        private void shapesToolStripMenuItem_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedname = e.ClickedItem.Text;
            _circle = _listShape.Find(x => x.Name == clickedname);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isSave == false)
            {
                DialogResult result1 = MessageBox.Show(@"File is not saved",
                    @"Important Question",
                    MessageBoxButtons.YesNo);
                if (result1 != DialogResult.Yes) return;
                textBox1.Clear();
                panel1.Refresh();
                _listShape.Clear();
                shapesToolStripMenuItem.DropDownItems.Clear();
                _isSave = false;
            }
            else
            {
                textBox1.Clear();
                panel1.Refresh();
                _listShape.Clear();
                shapesToolStripMenuItem.DropDownItems.Clear();
                _isSave = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = UI.CreateOpenFile();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            textBox1.Clear();
            panel1.Refresh();
            _listShape = CircleBL.CircleBL.DeserializeList(openFileDialog.FileName);
            foreach (var it in _listShape)
            {
                _graphics.FillEllipse(new SolidBrush(it.CircleColor), it.Centre.X - it.Radius, it.Centre.Y - it.Radius,
                    it.Radius + it.Radius, it.Radius + it.Radius);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = UI.CreateSaveFile();

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            CircleBL.CircleBL.SerializeList(_listShape, saveFileDialog.FileName);
            _isSave = true;
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