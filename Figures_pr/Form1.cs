using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures_pr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Figure.g = this.CreateGraphics();
            Figure.bkcolor = this.BackColor;
            caretaker = new Caretaker(this);
        }
        Graphics g;
        Caretaker caretaker;
        Random rand = new Random();
        string LastFig = "";
        Figures figures = new Figures();
        bool move = false;
        Color SaveColor = Color.Black;
        Point lastP;
        public IMemento Save()
        {
            return new VectorRedactorMemento(figures.SerializeFigures(), comboBox1.SelectedIndex); ;
        }
        public void Restore(IMemento memento)
        {
            Figure.g.Clear(Figure.bkcolor);
            figures.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LastFig = "";
            comboBox1.Items.AddRange(figures.DeserializeFiguresFromString(memento.GetState().FiguresCode));
            comboBox1.SelectedIndex = memento.GetState().SelectedIndex;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            caretaker.Backup();
            Rectangle_ rect = new Rectangle_();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
            caretaker.Backup();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            caretaker.Backup();
            Triangle triangle = new Triangle();
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = rand.Next(0, rand.Next(0, triangle.size.Width));
            triangle.type = "triangle";
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
            caretaker.Backup();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            caretaker.Backup();
            Circle circle = new Circle();
            circle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            circle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - circle.size.Height));
            circle.color = Color.Red;
            circle.show();
            figures.add(circle);
            comboBox1.Items.Add(circle);
            caretaker.Backup();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LastFig != "")
            {
                ((Figure)comboBox1.Items[Convert.ToInt32(LastFig)]).color = SaveColor;
                ((Figure)comboBox1.Items[Convert.ToInt32(LastFig)]).show();
            }
            SaveColor = ((Figure)comboBox1.SelectedItem).color;

            ((Figure)comboBox1.SelectedItem).color = Color.Orange;
            label1.Text = "S = " + ((Figure)comboBox1.SelectedItem).area();

            ((Figure)comboBox1.SelectedItem).show();
            LastFig = comboBox1.SelectedIndex.ToString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Figure f = figures.selected(e.X, e.Y);
            if (f != null)
            {
                caretaker.Backup();
                if (LastFig == "")
                {
                    SaveColor = f.color;
                }
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(f);

                f.color = Color.Orange;
                move = true;
                lastP = new Point(e.X, e.Y);

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (move)
            {
                caretaker.Backup();
                ((Figure)comboBox1.SelectedItem).color = SaveColor;
                ((Figure)comboBox1.SelectedItem).show();
            }
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                ((Figure)comboBox1.SelectedItem).move(e.X - lastP.X, e.Y - lastP.Y);
                lastP.X = e.X;
                lastP.Y = e.Y;
                figures.show();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            caretaker.Backup();
            Cube rect = new Cube();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
            caretaker.Backup();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            caretaker.Backup();
            Cilindr rect = new Cilindr();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            //  rect.d = rand.Next(10, 30);
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
            caretaker.Backup();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            caretaker.Backup();
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = 0;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
            caretaker.Backup();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            caretaker.Backup();
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = triangle.size.Width / 2;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
            caretaker.Backup();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            caretaker.Backup();
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            int a = rand.Next(50, 100);
            triangle.size = new Size(a, a);
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = triangle.size.Width / 2;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
            caretaker.Backup();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            caretaker.Backup();
            Ellipse rect = new Ellipse();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
            caretaker.Backup();
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caretaker.Backup();
                figures.save(saveFileDialog1.FileName);
            }
        }

        private void OpenB_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caretaker.Backup();
                comboBox1.Items.AddRange(figures.open(openFileDialog1.FileName, comboBox1.Items.Cast<Figure>().ToArray()));
            }
        }
        string s;
        private void button1_Click_1(object sender, EventArgs e)
        {
            s = figures.SerializeFigures();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Figure.g.Clear(Figure.bkcolor);
            figures.Clear();
            comboBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(figures.DeserializeFiguresFromString(s));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Z)
            {
                caretaker.Undo();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            caretaker.Undo();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            caretaker.Redo();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caretaker.Backup();
                figures.SaveToXml(new XMLVisitor(), saveFileDialog1.FileName);
            }
        }
    }
}
