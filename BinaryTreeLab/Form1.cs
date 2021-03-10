using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTreeLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BinaryTree btree = new BinaryTree();

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            int newtemp = int.Parse(temp);
            btree.Insert(newtemp);
            textBox1.Text = " ";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string temp = textBox3.Text;
            int newtemp = int.Parse(temp);
            textBox3.Text = " ";
            int retval = btree.Find(newtemp);
            string retvalstring = retval.ToString();
            textBox3.Text = retvalstring += " Was found.";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string temp = textBox2.Text;
            textBox2.Text = " ";
            int newtemp = int.Parse(temp);
            int newnewtemp = btree.Remove(newtemp);
            string tempdisplay = newnewtemp.ToString();
            textBox2.Text = tempdisplay += " Was removed. ";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string temp = btree.Print();
            textBox4.Text = temp;
        }
    }
}

