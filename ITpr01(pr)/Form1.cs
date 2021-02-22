using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITpr01_pr_
{
  public partial class Form1 : Form
  {
    int[,] a = new int[3,3];
    int kol_ed = 0;
    public Form1()
    {
      InitializeComponent();
      Random rng = new Random();
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
           int ch = rng.Next(0, 2);
           a[i, j] = ch;
          if (ch == 1)
            kol_ed++;
        }
      }
    }



    private void provercl(int c, int b, int kolvo_kn)
    {
      if (a[c, b] == 1)
      {
        BackColor = Color.OrangeRed;
        label1.Text = "DEAD!!!!!";
      }
      if (a[c, b] == 0)
      {
        label1.Text = Convert.ToString(kol_ed);
      }
      
    }

    private void Form1_Load(object sender, EventArgs e)
        {

        }

    private void button1_Click(object sender, EventArgs e)
    {
      BackColor = Color.OrangeRed;
     
    }

    private void button2_Click(object sender, EventArgs e)
    {
      BackColor = Color.MediumSeaGreen;
     
    }

    private void button3_Click(object sender, EventArgs e)
    {
      BackColor = Color.MediumBlue;
    
    }

    private void button4_Click(object sender, EventArgs e)
    {
      BackColor = Color.Yellow;
  
    }
    private void button00_Click(object sender, EventArgs e)
    {
      // 0,0
      provercl(0,0);
      
    }

    private void button01_Click(object sender, EventArgs e)
    {
      provercl(0, 1);

    }

    private void button02_Click(object sender, EventArgs e)
    {
      provercl(0, 2);

    }

    private void button10_Click(object sender, EventArgs e)
    {
      provercl(1, 0);
  
    }

    private void button11_Click(object sender, EventArgs e)
    {
      provercl(1, 1);

    }

    private void button12_Click(object sender, EventArgs e)
    {
      provercl(1, 2);
    
    }

    private void button20_Click(object sender, EventArgs e)
    {
      provercl(2, 0);
    
    }

    private void button21_Click(object sender, EventArgs e)
    {
      provercl(2, 1);
    
    }

    private void button13_Click(object sender, EventArgs e)
    {
      provercl(2, 2);

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button_0_0_Click(object sender, EventArgs e)
    {
      // 0,0
      provercl(0, 0);
    }
  }
}
