using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;
        enum PhepToan { Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;

        double nho;

        private void NhapSo(object sender, EventArgs e)
        {
            string so = ((Button)sender).Text;
            NhapSo(so);
        }
        private void NhapSo(string so)
        {
            if (isTypingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            TinhKetQua();
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }

            nho = double.Parse(lblDisplay.Text);
            isTypingNumber = false;

        }

        private void TinhKetQua()
        {
            // tinh toan dua tren: nho, pheptoan, lblDisplay.Text
            double tam = double.Parse(lblDisplay.Text);
            double Ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: Ketqua = nho + tam; break;
                case PhepToan.Tru: Ketqua = nho - tam; break;
                case PhepToan.Nhan: Ketqua = nho * tam; break;
                case PhepToan.Chia: Ketqua = nho / tam; break;
            }
            // gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = Ketqua.ToString();

        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
        }
    }
}


   
