using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr9_02
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    //    private void button1_Click(object sender, EventArgs e)
      //  {
        // string s1 = textBox1.Text;
          //listBox1.Items.Insert(0,s1);
    //  listBox1.SetSelected(0, true);
      //  }

   // private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    private void button3_Click(object sender, EventArgs e)
    {
      string s1 = textBox2.Text;
      listBox2.Items.Insert(0, s1);
      listBox2.SetSelected(0, true);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      string s1 = textBox2.Text;
      listBox2.Items.Remove(s1);
    }
  }
}
