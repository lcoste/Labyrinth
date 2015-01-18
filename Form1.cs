/**************************************************************************\
 **                    LABYRINTH GENERATOR AND SOLVER                    **
 **                                                                      **
 ** Programmer: Louis Coste                                              **
 ** Date: 18th of October 2014                                           **
 ** Version: 2.1                                                         **
 **                                                                      **
 ** Summary: Produces a random generator and then has the possibility    **
 **          to find the shortest path from the start point to the       **
 **          finish point.                                               **
 **                                                                      **
 ** How: Generation: Based on a grid of wall it destroys some to         **
 **                  create paths. The algorythme makes sure that        **
 **                  every path is connected.                            **  
 **      Research: From the start point sets every adjacent path as a    **
 **                possible shortest path and gives the cell a value     **
 **                indicating the lenght of the path so far.             **
 **                                                                      **
 ** Why: To have fun! But also this is the second version of the same    **
 **      program I had done in Python and was less efficient as it       **
 **      couldn't build or solve big labyrinths. It used recursive       **
 **      functions.                                                      **
 **                                                                      **
 ** Thank you to Marc-Antoinne for the idea of creating such a program.  **
 ** Merci Marc-Antoinne pour m'avoir donne l'idee de cree ce programme.  **
 **                                                                      **
 \*************************************************************************/



using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
/*using System.Drawing;*/

namespace Labyrinth
{
    public partial class Labyrinth_win : Form
    {
        public Labyrinth_win()
        {
            InitializeComponent();
        }


        private int[,] grid;
        private int length;
        private int height;

        private int finish_x;
        private int finish_y;
        private int path_lenght;
        private Bitmap b;

        private bool started = false;
        private bool path_known = false;

        private void height_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only accepting numbers for the text box
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void height_box_KeyDown(object sender, KeyEventArgs e)
        {
            //Making sure that the input is veryfing the size conditions of the labyrinth
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                int x = int.Parse(height_box.Text);
                if (x < 10)
                {
                    height_box.Text = "10";
                }
                else if (x % 2 == 1)
                {
                    height_box.Text = (x - 1).ToString();
                }

                height_box.Select(0, height_box.Text.Length);
                if (!started || path_known || int.Parse(height_box.Text)+1 != height)
                    Generation_Click(sender, e);
                else
                    Research_Click(sender, e);
            }
        }

        private void height_box_Validated(object sender, EventArgs e)
        {
            //Making sure that the input is veryfing the size conditions of the labyrinth
            int x = int.Parse(height_box.Text);
            if (x < 10)
            {
                height_box.Text = "10";
            }
            else if (x % 2 == 1)
            {
                height_box.Text = (x - 1).ToString();
            }
            height_box.Select(0, height_box.Text.Length);
        }

        private void width_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only accepting numbers for the text box
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void width_box_KeyDown(object sender, KeyEventArgs e)
        {
            //Making sure that the input is veryfing the size conditions of the labyrinth
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                int x = int.Parse(width_box.Text);
                if (x < 10)
                {
                    width_box.Text = "10";
                }
                else if (x % 2 == 1)
                {
                    width_box.Text = (x - 1).ToString();
                }
                width_box.Select(0, width_box.Text.Length);
                if (!started || path_known || int.Parse(width_box.Text)+1 != length)
                    Generation_Click(sender, e);
                else
                    Research_Click(sender, e);
            }
        }

        private void width_box_Validated(object sender, EventArgs e)
        {
            //Making sure that the input is veryfing the size conditions of the labyrinth
            int x = int.Parse(width_box.Text);
            if (x < 10)
            {
                width_box.Text = "10";
            }
            else if (x % 2 == 1)
            {
                width_box.Text = (x - 1).ToString();
            }
            width_box.Select(0, width_box.Text.Length);
        }

        private void generate_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Generation_Click(sender, e);
            }
        }

        private void Generation_Click(object sender, EventArgs e)
        {
            started = true;
            path_known = false;

            //Let's time our program
            DateTime start_time = DateTime.Now;

            Random rnd = new Random();

            bool finished = false;
            length = int.Parse(width_box.Text) + 1;
            height = int.Parse(height_box.Text) + 1;

            try
            {
                b = new Bitmap(height, length, System.Drawing.Imaging.PixelFormat.Format24bppRgb) ;
            }
            catch(System.ArgumentException)
            {
                info_label1.Text = "Your labyrinth is too big.";
                info_label2.Text = "Please choose smaller a size.";
                return;
            }

            bool corrected;
            bool modified;

            //start and finish point variables
            int special_x=0;
            int special_y=0;
            int random_corner = rnd.Next(3);  //We generate one random number to know which corners will have the start and finish

            //Creation of the grid
            grid = new int[height,length];

            info_label1.Text = "Generating...";
            info_label1.Refresh();

            //Basic generation
            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < length; j++)
                {
                    if (j % 2 == 1 && i % 2 == 1)				//Grid generation
                    {
                        grid[i, j] = 1;
                    }
                    else if ((j % 2 == 1 || i % 2 == 1) && !(j % 2 == 1 && i % 2 == 1) && !((i == 0 || j == 0) || (i == height - 1 || j == length - 1)))
                    {
                        if (rnd.Next(3) == 0)				//Wall generation (random)
                        {
                            grid[i, j] = 1;
                        }
                    }
                }
            }

            //Correction to make sure every path is linked
            while (!finished )
            {
                info_label2.Text = "Creating new paths";
                info_label2.Refresh();
                //We create new paths if they are not connected
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (j % 2 == 1 && i % 2 == 1 && grid[i,j]==1)
                        {
                            corrected = false;
                            while (!corrected)
                            {

                                //Random creation of new paths to link everything
                                switch (rnd.Next(3))
                                {
                                    case 0:
                                        if (i > 1 && grid[i - 2, j] != 0 )
                                        {
                                            grid[i - 1, j] = 1;
                                            corrected = true;
                                        }
                                        break;
                                    case 1:
                                        if (i < height - 2 && grid[i + 2, j] != 0 )
                                        {
                                            grid[i + 1, j] = 1;
                                            corrected = true;
                                        }
                                        break;
                                    case 2:
                                        if (j < length - 2 && grid[i, j + 2] != 0 )
                                        {
                                            grid[i, j + 1] = 1;
                                            corrected = true;
                                        }
                                        break;
                                    case 3:
                                        if (j > 1 && grid[i, j - 2] != 0 )
                                        {
                                            grid[i, j - 1] = 1;
                                            corrected = true;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }

                info_label2.Text = "Removing 4 way intersections";
                info_label2.Refresh();
                //We don't want a grid where there are 4 way intersections everywhere
                //So we need to remove the 4 way intersections, randomly
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if ((j % 2 == 1 && i % 2 == 1) && (grid[i + 1, j] != 0 && grid[i - 1, j] != 0 && grid[i, j + 1] != 0 && grid[i, j - 1] != 0))
                        {
                            switch (rnd.Next(3))
                            {
                                case 0:
                                    if (grid[i - 1, j] != 2)
                                    {
                                        grid[i - 1, j] = 0;
                                    }
                                    break;

                                case 1:
                                    if (grid[i + 1, j] != 2)
                                    {
                                        grid[i + 1, j] = 0;
                                    }
                                    break;

                                case 2:
                                    if (grid[i, j + 1] != 2)
                                    {
                                        grid[i, j + 1] = 0;
                                    }
                                    break;

                                case 3:
                                    if (grid[i, j - 1] != 2)
                                    {
                                        grid[i, j - 1] = 0;
                                    }
                                    break;                          
                            }                            
                        }
                    }
                }

                info_label2.Text = "Looking for isolated cells";
                info_label2.Refresh();
                //Checking for isolated cells so we don't end up with a single cell alone not connected to anything
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (grid[i, j] != 0 && grid[i + 1, j] == 0 && grid[i - 1, j] == 0 && grid[i, j + 1] == 0 && grid[i, j - 1] == 0)
                        {
                            corrected = false;
                            while (!corrected)
                            {
                                switch (rnd.Next(3))
                                {
                                    case 0:

                                        if (i > 1)
                                        {
                                            grid[i - 1, j] = 1;
                                            corrected = true;
                                        }
                                        break;

                                    case 1:

                                        if (i < height - 2)
                                        {
                                            grid[i + 1, j] = 1;
                                            corrected = true;
                                        }
                                        break;

                                    case 2:

                                        if (j < length - 2)
                                        {
                                            grid[i, j + 1] = 1;
                                            corrected = true;
                                        }
                                        break;

                                    case 3:

                                        if (j > 2)
                                        {
                                            grid[i, j - 1] = 1;
                                            corrected = true;
                                        }
                                        break;

                                }
                            }
                        }
                    }
                }

                info_label2.Text = "Looking for connected paths";
                info_label2.Refresh();
                //The verified path is marked by "2"
                grid[1, 1] = 2;
                do
                {
                    modified = false;
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (grid[i, j] == 1 && ((grid[i + 1, j] == 2) || (grid[i - 1, j] == 2) || (grid[i, j - 1] == 2) || (grid[i, j + 1] == 2)))	//If a 2 beside
                            {																								                        //becomes permanent
                                grid[i, j] = 2;
                                modified = true;
                            }

                        }
                    }
                } while (modified);


                info_label2.Text = "Looking for 1s";
                info_label2.Refresh();
                //Checking for remaining 1s
                //If there is a 1 then we are not finished
                // We also try to fix if there is a nearby 2
                finished = true;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            finished = false;
                            if (i % 2 == 1 && j % 2 == 1)
                            {
                                if (i > 1 && grid[i - 2, j] == 2)
                                {
                                    grid[i - 1, j] = 2;
                                }
                                else if (i < height - 2 && grid[i + 2, j] == 2)
                                {
                                    grid[i + 1, j] = 2;
                                }
                                else if (j < length - 2 && grid[i, j + 2] == 2)
                                {
                                    grid[i, j + 1] = 2;
                                }
                                else if (j > 1 && grid[i, j - 2] == 2)
                                {
                                    grid[i, j - 1] = 2;
                                }
                            }
                        }
                    }
                }
            }

            info_label2.Text = "Cleaning the labyrinth back into 1";
            info_label2.Refresh();
            //Transforms back the 2 in 1
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (grid[i, j] !=0)
                        grid[i, j] = 1;
                }
            }

            info_label2.Text = "Start and finish";
            info_label2.Refresh();
            //Generation of the start and finish point
            //They are in opposite corners (nicer, at least they are not side to side)
            for (int k=2; k<=3; k++)
            {
                switch (random_corner)
                {
                    case 0:
                        do
                        {
                            special_x = rnd.Next(height / 4);
                            special_y = rnd.Next(length / 4);
                        } while (grid[special_x, special_y] != 1);
                        grid[special_x, special_y] = k;
                        random_corner = 2;
                        break;
                    case 1:
                        do
                        {
                            special_x = rnd.Next(3*height / 4, height);
                            special_y = rnd.Next(length / 4);
                        } while (grid[special_x, special_y] != 1);
                        grid[special_x, special_y] = k;
                        random_corner = 3;
                        break;
                    case 2:
                        do
                        {
                            special_x = rnd.Next(3*height / 4, height);
                            special_y = rnd.Next(3*length / 4, length);
                        } while (grid[special_x, special_y] != 1);
                        grid[special_x, special_y] = k;
                        random_corner = 0;
                        break;
                    case 3:
                        do
                        {
                            special_x = rnd.Next(height / 4);
                            special_y = rnd.Next(3*length / 4, length);
                        } while (grid[special_x, special_y] != 1);
                        grid[special_x, special_y] = k;
                        random_corner = 1;
                        break;
                }
                if (k==3)
                {
                    finish_x = special_x;
                    finish_y = special_y;
                }
            }
            info_label1.Text = "Generation finished in " + (((DateTime.Now - start_time).TotalMilliseconds) / 1000.0) + " s";
            info_label1.Refresh();
            start_time = DateTime.Now;
            info_label2.Text = "Drawing...";
            info_label2.Refresh();

            //Drawing of our labyrinth
            PaintPng();

            info_label2.Text = "Drawing done in " + (((DateTime.Now - start_time).TotalMilliseconds) / 1000.0) + " s";
            research_button.Enabled = true;
        }

        private void Research_Click(object sender, EventArgs e)
        {
            DateTime start_time;

            if (!path_known)
            {
                //Let's time our program
                start_time = DateTime.Now;

                //Researches the shortest path by a web-like research method 
                int start_x = 0;
                int start_y = 0;
                int limit_x;
                int limit_y;
                path_lenght = 10;
                bool finish_found = false;

                info_label1.Text = "Researching...";
                info_label1.Refresh();
                info_label2.Text = "Researching starting point";
                info_label2.Refresh();
                //Research of the starting point
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (grid[i, j] == 2)
                        {
                            grid[i, j] = 10;    //We then set it as 10 to specify its the origin of all the paths
                            start_x = i;
                            start_y = j;
                            i = height;         //We get out of the loop as soon as possible ==> More efficient
                            break;
                        }
                    }
                }

                info_label2.Text = "Web dispertion";
                info_label2.Refresh();
                //Research section
                //Each cell next to one possible path becomes path
                //EX: if next to path of lenght k the cell becomes k+1
                for (int k = 11; !finish_found; k++)
                {

                    limit_x = start_x - (k - 10);
                    limit_y = start_y - (k - 10);
                    if (limit_x < 0)
                        limit_x = 0;
                    if (limit_y < 0)
                        limit_y = 0;
                    for (int i = limit_x; i <= start_x + (k - 10) && i < height; i++)
                    {
                        for (int j = limit_y; j <= start_y + k - 10 && j < length; j++)
                        {
                            if (grid[i, j] == 1 && (grid[i + 1, j] == k - 1 || grid[i - 1, j] == k - 1 || grid[i, j + 1] == k - 1 || grid[i, j - 1] == k - 1))    //Found possible path
                            {
                                grid[i, j] = k;
                            }

                            else if (grid[i, j] == 3 && (grid[i + 1, j] == k - 1 || grid[i - 1, j] == k - 1 || grid[i, j + 1] == k - 1 || grid[i, j - 1] == k - 1)) //Found exit
                            {
                                finish_x = i;
                                finish_y = j;
                                path_lenght = k;
                                finish_found = true;
                                i = height;
                                break;
                            }
                        }
                    }
                }

                info_label1.Text = "Research finished in " + (((DateTime.Now - start_time).TotalMilliseconds) / 1000.0) + " s";
                info_label1.Refresh();
                path_known = true;
            }

            //Creation of drawing specs(size of each cell)
            start_time = DateTime.Now;

            PaintPathPng();

            info_label2.Text = "Drawing done in " + (((DateTime.Now - start_time).TotalMilliseconds) / 1000.0) + " s";

        }

        private void PaintPng()
        {
            Brush white = new SolidBrush(Color.White);
            Brush start = new SolidBrush(Color.Red);
            Brush finish = new SolidBrush(Color.Blue);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.Black);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (grid[i,j]==1)
                            g.FillRectangle(white, i, j, 1, 1);
                        else if (grid[i,j]==2)
                            g.FillRectangle(start, i, j, 1, 1);
                        else if (grid[i,j]==3)
                            g.FillRectangle(finish, i, j, 1, 1);
                    }
                }
            }
            b.Save(@"Labyrinth.png");
            System.Diagnostics.Process.Start(@"Labyrinth.png");


        }
        private void PaintPathPng()
        {
            info_label2.Text = "Drawing...";
            info_label2.Refresh();

            Brush path = new SolidBrush(Color.Green);

            int x = finish_x;
            int y = finish_y;
            using (Graphics g = Graphics.FromImage(b))
            {
                //We go from finish to start as the "k"s will decrement along the shortest path
                for (int k = path_lenght; k > 11; k--)
                {

                    if (grid[x - 1, y] == k - 1)
                    {
                        g.FillRectangle(path, x - 1, y, 1, 1);
                        x--;
                    }
                    else if (grid[x + 1, y] == k - 1)
                    {
                        g.FillRectangle(path, x + 1, y, 1, 1);
                        x++;
                    }
                    else if (grid[x, y + 1] == k - 1)
                    {
                        g.FillRectangle(path, x, y + 1, 1, 1);
                        y++;
                    }
                    else
                    {
                        g.FillRectangle(path, x, y - 1, 1, 1);
                        y--;
                    }

                }
            }
            b.Save(@"Labyrinth.png");
            System.Diagnostics.Process.Start(@"Labyrinth.png");
        }

    }
}
