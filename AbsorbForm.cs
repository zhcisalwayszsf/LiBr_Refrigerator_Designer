﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiBr_Refrigerator_Design
{
    public partial class AbsorbForm : Form
    {

        //确保输入
        private void NoInputMessage()
        {
            string Message = "请输入完整数据";
            string Caption = "提示";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(Message, Caption, buttons, icon);

        }
        //输入框只能输入数字0-9和退格以及小数点和delete。
        private void OnlyNumbles(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete)  // 检查输入的字符是否退格，delete
            {
                e.Handled = false;//处理输入
                if (e.KeyChar == '.' && (((System.Windows.Forms.TextBox)sender).Text.IndexOf(".") != -1 | ((System.Windows.Forms.TextBox)sender).Text.Length == 0))
                //判断输入框已经有小数点或是为空
                {
                    e.Handled = true;//符合条件，屏蔽输入
                }
            }
            else
            {
                // 检查输入的字符是否为数字（0-9）
                char[] digits = e.KeyChar.ToString().ToCharArray();
                foreach (char digit in digits)
                {
                    if (!Char.IsDigit(digit))
                    {
                        e.Handled = true; // 不是数字，不处理输入
                        break;
                    }
                    e.Handled = false; // 是数字，处理输入
                }
            }
        }


        Function myFunction = new Function();

        public AbsorbForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_d0.Text == string.Empty | textBox_di.Text ==string.Empty|
                textBox_r0.Text == string.Empty | textBox_ri.Text == string.Empty|
                textBox_tw.Text == string.Empty | textBox_tw1.Text == string.Empty|
                textBox_t9.Text == string.Empty | textBox_t2.Text == string.Empty|
                textBox_xi.Text == string.Empty | textBox_gamma.Text == string.Empty|
                textBox_tube_lambda.Text == string.Empty | textBox_t_inTube.Text == string.Empty|
                textBox_absorb_q.Text == string.Empty | textBox_flu_qv.Text == string.Empty|
                textBox_tube_length.Text == string.Empty| textBox_m.Text == string.Empty)
            {
                NoInputMessage();
            }
            else
            {
                double k, a, l, n, speed, a0, ai, k0, ki, d0, di, r0, ri, tw, tw1, t9, t2, m, flu_qv, t_inTube, q_a, tube_lambda, xi, gamma;
                d0 = double.Parse(textBox_d0.Text);
                di = double.Parse(textBox_di.Text);
                r0 = double.Parse(textBox_r0.Text);
                ri = double.Parse(textBox_ri.Text);
                tw = double.Parse(textBox_tw.Text);
                tw1 = double.Parse(textBox_tw1.Text);
                t9 = double.Parse(textBox_t9.Text);
                t2 = double.Parse(textBox_t2.Text);
                xi = double.Parse(textBox_xi.Text);
                gamma = double.Parse(textBox_gamma.Text);
                tube_lambda = double.Parse(textBox_tube_lambda.Text);
                t_inTube = double.Parse(textBox_t_inTube.Text);
                q_a = double.Parse(textBox_absorb_q.Text);
                flu_qv = double.Parse(textBox_flu_qv.Text);
                l = double.Parse(textBox_tube_length.Text);
                m = double.Parse(textBox_m.Text);
                double mess = double.Parse(textBox_first_K.Text);

                for (int i = 1000; i > 0; i--)
                {
                    a = myFunction.Absorb_Area(q_a, mess, tw1, tw, t9, t2);
                    n = myFunction.tubeNumb(a, l, d0);
                    speed = myFunction.fluSpeed(flu_qv, n, m, di);
                    ai = myFunction.Absorb_ai(speed, di, t_inTube);
                    a0 = myFunction.Absorb_a0(xi, gamma);
                    ki = myFunction.K_in(a0, ai, r0, ri, d0, di, tube_lambda);
                    k0 = myFunction.K_out(a0, ai, r0, ri, d0, di, tube_lambda);
                    k = myFunction.average_K2(ki, k0);

                    if (Math.Abs(mess - k) > 0.1)
                    {
                        Console.WriteLine("a:" + a + "     n:" + n + "      speed:" + speed + "    ai:" + ai + "     a0:" + a0 + "    ki:" + ki + "     k0:" + k0 + "     k:" + k);
                        mess = k;
                    }
                    else
                    {
                        textBox_result.Text = mess.ToString();
                        textBox_area.Text = a.ToString();
                        break;
                    }
                }
            
            }
        }
    }
}