using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ai
{
    public partial class Form1 : Form, IView, IModelObserver
    {
        IController controller;
        public event ViewHandler<IView> changed;
        // View will set the associated controller, this is how view is linked to the controller.
        public void setController(IController cont)
        {
            controller = cont;
            
        }

        public Form1()
        {
            InitializeComponent();
            panel2.Paint += new PaintEventHandler(panel2_Paint);
            panel2.Refresh();
        }
        int square = 200;
        int stepsize = 20;
        int stacksize = 0;
        int[] vals = new int[10];
        string[] op; 
        string[] parse = new string[10];
        //Stack myStack = new Stack();
        int[] holders = new int[10];
        float holder;
        int length = 50;

        public string setText
        {
            set { richTextBox1.AppendText(value + " "); }
        }

        public void setOp(int size)
        {
            this.op = new string[size];
        }
        public void setHolder(float val)
        {
            this.holder = val;
        }
        public float getHolder()
        {
            return this.holder;
        }
        
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            Brush brush = new SolidBrush(Color.DarkGreen);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
             0, 0, square, square);


            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
            Point axisX;
            Point axisY;
            myPen.Color = System.Drawing.Color.Gray;
            int i, a, b, c, d, f;

            int steps = square / stepsize;
            if (steps % 2 == 0)
            {
                for (i = 0, a = invert(square / 2), b = square / 2, c = 0, d = 0, f = 15; i <= square; i += stepsize, a += stepsize, b -= stepsize, c++)
                {
                    if (c % 2 == 0)
                    {
                        d++;
                        if ((stepsize < 10) && (d % 2 == 0)) { axisX = new Point(i - ((stepsize / 2) - (stepsize / 3)), square + stepsize + f); }
                        else { axisX = new Point(i - ((stepsize / 2) - (stepsize / 3)), square + stepsize); }

                        axisY = new Point(square + stepsize, i - ((stepsize / 2) - (stepsize / 3)));

                        g.DrawString(a.ToString(), DefaultFont, brush, axisX);
                        g.DrawString(b.ToString(), DefaultFont, brush, axisY);
                    }

                    g.DrawLine(myPen, i, 0, i, square + stepsize);
                    g.DrawLine(myPen, 0, i, square + stepsize, i);

                }
            }
            else { System.Diagnostics.Debug.Write("The steps didnt fit the square"); }

            myPen.Color = System.Drawing.Color.Black;
            g.DrawRectangle(myPen, rectangle);
            g.DrawLine(myPen, 0, square / 2, square, square / 2);
            g.DrawLine(myPen, square / 2, 0, square / 2, square);
            axisX = new Point(square + stepsize, square - (stepsize / 2));
            axisY = new Point(square - (stepsize / 2), square + stepsize);
        }

        public float setCX(float vals)
        {
            float coords;
            int i;
            coords = vals + square / 2;
            return coords;
        }
        public float setCY(float vals)
        {
            float coords;
            int i;
            coords = square / 2 - vals;
            return coords;
        }
        public int findStart()
        {
            int var = square / 2;
            int start = 0;
            if (square % 2 == 0)
            {
                start = invert(var);
            }
            else
            {
                System.Diagnostics.Debug.Write("The square wasnt even");

            }
            return start;

        }
        public int invert(int inv)
        {
            int val = 0;
            int holder = 0;
            int lsize = 10000;

            if (inv < 0)
            {
                val = (int)Math.Sqrt(inv * inv);
            }
            else if (inv > 0)
            {
                holder = lsize - inv;
                val = holder - lsize;
            }

            return val;
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            square = Convert.ToInt32(txtSize.Text);
            stepsize = Convert.ToInt32(txtPart.Text);
            panel2.Paint += new PaintEventHandler(panel2_Paint);
            panel2.Refresh();
        }


        private int recur(string[] inputs, int val, int pos, string token)
        {

            string[] delimiterChars = { "*", "-", "+", "/" };
            string[] orderOps = { "(", ")", "^" };
            string[] trigOps = { "Cos", "Tan", "Sin" };


            for (int i = pos; i < inputs.Length; i++)
            {

            }

            return 0;
        }
        private float infix(string[] inputs, int val, int pos)
        {
            string[] delimiterChars = { "*", "-", "+", "/" };
            string[] orderOps = { "(", ")", "^", "*", "-", "+", "/", "Cos", "Tan", "Sin" };
            string[] trigOps = { "Cos", "Tan", "Sin" };

            int numValue;
            string[] operators = new string[10];
            int endbrace = 0;
            int inbrace = 1;
            int opset = 0;
            //holders[0] = val;
            for (int i = pos; i < inputs.Length; i++)
            {
                if (inputs[0].Equals("x") && i == 0) { setHolder(val); continue; }
                else if (Int32.TryParse(inputs[0], out numValue) && i == 0) { setHolder(numValue); continue; }
               
                else
                {
                    if (opset == 1)
                    {
                        switch (operators[0])
                        {
                            case "+":
                                if (inputs[i].Equals("Cos") || inputs[i].Equals("Sin") || inputs[i].Equals("Tan"))
                                {
                                    switch (inputs[i])
                                    {
                                        case "Sin":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() + Convert.ToInt32(Math.Sin(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() + Convert.ToInt32(Math.Sin(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Cos":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() + Convert.ToInt32(Math.Cos(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() + Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Tan":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() + Convert.ToInt32(Math.Tan(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() + Convert.ToInt32(Math.Tan(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                    }
                                    i += 2;
                                    opset = 0;
                                    break;
                                }
                                else
                                {
                                    if (inputs[i].Equals("x")) { setHolder(getHolder() + val); }
                                    else { setHolder(getHolder() + Convert.ToInt32(inputs[i]));}
                                    opset = 0;
                                    break;
                                }
                            case "-":
                                if (inputs[i].Equals("Cos") || inputs[i].Equals("Sin") || inputs[i].Equals("Tan"))
                                {
                                    switch (inputs[i])
                                    {
                                        case "Sin":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() - Convert.ToInt32(Math.Sin(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() - Convert.ToInt32(Math.Sin(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Cos":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() - Convert.ToInt32(Math.Cos(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() - Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Tan":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() - Convert.ToInt32(Math.Tan(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() - Convert.ToInt32(Math.Tan(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                    }
                                    i += 2;
                                    opset = 0;
                                    break;
                                }
                                else
                                {
                                    if (inputs[i].Equals("x")) { setHolder(getHolder() - val); }
                                    else { setHolder(getHolder() - Convert.ToInt32(inputs[i])); }
                                    opset = 0;
                                    break;
                                }
                            case "*":
                                if (inputs[i].Equals("Cos") || inputs[i].Equals("Sin") || inputs[i].Equals("Tan"))
                                {
                                    switch (inputs[i])
                                    {
                                        case "Sin":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() * Convert.ToInt32(Math.Sin(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() * Convert.ToInt32(Math.Sin(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Cos":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() * Convert.ToInt32(Math.Cos(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() * Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                        case "Tan":
                                            if (inputs[i + 2].Equals("x")) { setHolder(getHolder() * Convert.ToInt32(Math.Tan(Convert.ToDouble(val)))); }
                                            else { setHolder(getHolder() * Convert.ToInt32(Math.Tan(Convert.ToDouble(inputs[i + 2])))); }
                                            break;
                                    }
                                    i += 2;
                                    opset = 0;
                                    break;
                                }
                                else
                                {
                                    if (inputs[i].Equals("x")) { setHolder(getHolder() * val); }
                                    else { setHolder(getHolder() * Convert.ToInt32(inputs[i])); }
                                    opset = 0;
                                    break;
                                }
                            case "/":
                                if (inputs[i].Equals("Cos") || inputs[i].Equals("Sin") || inputs[i].Equals("Tan"))
                                {
                                    int rand = 0;
                                    if(inputs[i + 2].Equals("x")  && val == 0) { } 
                                    else
                                    {
                                        switch (inputs[i])
                                        {
                                            case "Sin":
                                                if (inputs[i + 2].Equals("x")) { if (Convert.ToInt32(Math.Sin(Convert.ToDouble(val))) > 0) { setHolder(Convert.ToInt32(getHolder() / Math.Sin(val))); } }
                                                else { setHolder(getHolder() / Convert.ToInt32(Math.Sin(Convert.ToDouble(inputs[i + 2])))); }
                                                break;
                                            case "Cos":
                                                if (inputs[i + 2].Equals("x"))
                                                {
                                                    if (Convert.ToInt32(Math.Sin(Convert.ToDouble(val))) > 0) { setHolder(Convert.ToInt32(getHolder() / Math.Cos(val))); }
                                                }
                                                else { setHolder(getHolder() / Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i + 2])))); }
                                                System.Console.WriteLine(Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i + 2]))));
                                                break;
                                            case "Tan":
                                                if (inputs[i + 2].Equals("x")) { setHolder(Convert.ToInt32(getHolder() / Math.Tan(val))); }
                                                else { setHolder(getHolder() / Convert.ToInt32(Math.Tan(Convert.ToDouble(inputs[i + 2])))); }
                                                break;
                                            }
                                        }
                                    i += 2;
                                    opset = 0;
                                    break;
                                }
                                else
                                {
                                    if (inputs[i].Equals("x")) { if (val == 0) { } else { setHolder(getHolder() / val);  } }
                                    else { 
                                        if (Convert.ToInt32(inputs[i]) != 0)
                                         {
                                            setHolder(getHolder() / Convert.ToInt32(inputs[i]));
                                            opset = 0;  
                                         }
                                    }
                                    opset = 0;
                                    break;
                                }
                            case "^":
                                if (inputs[i].Equals("Cos") || inputs[i].Equals("Sin") || inputs[i].Equals("Tan"))
                                {
                                    switch (inputs[i])
                                    {
                                        case "Sin":
                                            if (inputs[i + 2].Equals("x")) { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Sin(Convert.ToDouble(val)))))); }
                                            else { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Sin(Convert.ToDouble(inputs[i + 2])))))); }
                                            break;
                                        case "Cos":
                                            if (inputs[i + 2].Equals("x")) { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Cos(Convert.ToDouble(val)))))); }
                                            else { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Cos(Convert.ToDouble(inputs[i + 2])))))); }
                                            break;
                                        case "Tan":
                                            if (inputs[i + 2].Equals("x")) { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Tan(Convert.ToDouble(val)))))); }
                                            else { setHolder(Convert.ToInt32(Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(Math.Tan(Convert.ToDouble(inputs[i + 2])))))); }
                                            break;
                                    }
                                    i += 2; opset = 0;
                                    break;
                                }
                                else
                                {
                                    if (inputs[i].Equals("x")) { setHolder((float)Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(val))); }
                                    else { setHolder((float)Math.Pow(Convert.ToDouble(getHolder()), Convert.ToDouble(inputs[i]))); }
                                    opset = 0;
                                    break;
                                }
                            case "Cos":
                                if (inputs[i+2].Equals("x")) { setHolder(getHolder() + Convert.ToInt32(Math.Cos(Convert.ToDouble(val)))); }
                                else { setHolder(getHolder() + Convert.ToInt32(Math.Cos(Convert.ToDouble(inputs[i+2])))); }
                                i += 2;
                                opset = 0;
                                break;
                            case "Sin":
                                if (inputs[i+2].Equals("x")) { setHolder(getHolder() + (float) Math.Sin(Convert.ToDouble(val))); }
                                else { setHolder(getHolder() + Convert.ToInt32(Math.Sin(Convert.ToDouble(inputs[i+2])))); }
                                i += 2;
                                opset = 0;
                                break;
                            case "Tan":
                                if (inputs[i+2].Equals("x")) { setHolder(getHolder() + Convert.ToInt32(Math.Tan(Convert.ToDouble(val)))); }
                                else { setHolder(getHolder() + Convert.ToInt32(Math.Tan(Convert.ToDouble(inputs[i+2])))); }
                                i += 2;
                                opset = 0;
                                break;
                            case "(":
                                inbrace = 1;
                                break;
                            case ")":
                                endbrace = 1;
                                inbrace = 0;
                                break;
                        }
                    }

                    for (int b = 0; b < orderOps.Length; b++)
                    {
                        if (inputs[i].Equals(orderOps[b]))
                        {
                            operators[0] = orderOps[b];
                            if (operators[0].Equals("("))
                            {
                                //recur(inputs, val, i, "(");
                            }
                            opset = 1;
                            break;
                        }
                    }

                }

            }
            System.Console.WriteLine(holders[0]);
            return getHolder();

        }

        private void printfunc(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            float var1 = 0;
            object[] reverse = new object[10];
            int abc = 0;
            int points = Convert.ToInt32(txtrange.Text);

            Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

            int setX = 0;
            string last = "next";
            int i, b;
            length = Convert.ToInt32(txtrange.Text);
            PointF[] newP = new PointF[points];
            for (i = 0; i < op.Length; i++)
            {
                if (op[i].Equals("x"))
                {
                    if (i == 0) { break; }
                    else if (last.Equals("-"))
                    {
                        setX = 1; 
                    }
                }
                last = op[i];
            }

            for (i = Convert.ToInt32(txtspoint.Text), b = Convert.ToInt32(txtspoint.Text); i < length && -length < b; i++, b--)
            {
                setHolder(0);
                if (setX == 1) { i = b; }
                var1 = infix(op, i, 0);
                System.Diagnostics.Debug.Write(var1);
                if (abc < points)
                {
                    newP[abc] = new PointF(setCX(i), setCY(var1));
                }
                abc++;
            }
            //Point[] curvepoint = new Point[5] { newP[0], newP[1], newP[2], newP[3], newP[4] };
            g.DrawCurve(myPen, newP);


        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^', '(', ')', '*', '-', '+', '/' };
            string input;
            string last = " ";
            int i, b, c;
            int[] t = new int[10];
            int counter = 0;
            input = txtFunc.Text;

            for (c = 0, b = 0, i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('C'))
                {
                    counter++;
                }
                else if (input[i].Equals('S'))
                {
                    counter++;
                }
                else if (input[i].Equals('T'))
                {
                    counter++;
                }
                if ((int)char.GetNumericValue(input[i]) > -1)
                {
                    if (i == input.Length - 1)
                    {
                        if (b > 0)
                        {
                            t[c++] += b++;
                        }
                    }
                    b++;
                }
                else
                {
                    if (b > 1)
                    {
                        t[c++] += b;
                        b = 0;
                    }
                    b = 0;

                }
               
            }b = 0;
                for (i = 0; i < c; i++) { System.Console.WriteLine("total numbers conjoined = " + t[i]); if (t[i] > 2) { b += t[i] - 1; } else { b += t[i] - 1; } }
                System.Console.WriteLine("take away= " + b);

                setOp((input.Length - (counter * 2)) - b);
                counter = 0;
                for (i = 0; i < input.Length; i++)
                {
                    if (input[i].Equals('C'))
                    {
                        op[counter] = input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString();
                        i += 2;
                        counter++;
                    }
                    else if (input[i].Equals('S'))
                    {
                        op[i] = input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString();
                        i += 2;
                        counter++;
                    }
                    else if (input[i].Equals('T'))
                    {
                        op[i] = input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString();
                        i += 2;
                        counter++;
                    }
                    else if (i + 1 < input.Length && (int)char.GetNumericValue(input[i]) > -1 && (int)char.GetNumericValue(input[i + 1]) > -1)
                    {
                        string newstring = input[i].ToString();
                        op[counter] += input[i].ToString();
                    }
                    else
                    {
                        if ((int)char.GetNumericValue(input[i]) > -1)
                        {
                            op[counter] += input[i].ToString();
                        }
                        else
                        {
                            op[counter] = input[i].ToString();
                        }

                        counter++;
                    }

                }

                panel2.Paint += new PaintEventHandler(printfunc);
                panel2.Refresh();

            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //control.newSentence(txtInput.Text);
            // richTextBox1.AppendText(txtInput.Text + "\n");
            controller.sendText(richTextBox2.Text);
            //richTextBox3.AppendText(richTextBox2.Text + "\n");
            richTextBox2.Text = "";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //controller.incvalue();
            controller.makeNewConcept();
            
        }
        
        public void setNewText(IModel m, ModelEventArgs e)
        {
            
            richTextBox1.AppendText("" + e.newval + "\n");
            richTextBox3.AppendText("" + e.secondval + "\n");
        }
        public void setOtherText(IModel m, ModelEventArgs e)
        {
            richTextBox3.AppendText("" + e.newval + "\n");
        }
       
        // When this event is raised can mean the user must have changed the value.
        // Invoke the view changed event in the controller which will call the method
        // in IModel to set the new value, the user can enter a new value and the
        // incrementing starts from that value onwards
        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                //changed.Invoke(this, new ViewEventArgs(int.Parse(textBox1.Text)));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number");
            }
        }

        
    }
}
