using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KelimeTahminOyunuForm
{
    public partial class Form1 : Form
    {
        private bool btnKelimeGirDurum;
        private int dakikka;
        private int saniye;
        private int salise;
        private Label[] lDizi = new Label[29];
        private Tree t;
        private TreeNode current;
        private TreeNode users_guess;
        private string yol;
        private int user_point;
        string secretWord;
        bool btnEkleDurum;

        public Form1()
        {
            InitializeComponent();
        }

        public void load_bar_setMax(int max)
        {
            loading_bar.Maximum = max;
        }
        public void load_bar_incValue(int i)
        {
            loading_bar.Value += i;
        }

        public void load_bar_resetVal()
        {
            loading_bar.Value = 0;
        }

        public void load_bar_visibility(bool nState)
        {
            loading_bar.Visible = nState;
        }
        private void FormItemsGameStartState()
        {
            txtKelimeGiris.Clear();
            btnBaslat.Enabled = false;
            btnDurdur.Visible = true;
            btnBaslat.Visible = false;
            sMenuItem.Enabled = false;
            txtKelimeGiris.Enabled = true;
            btnKelimeGir.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            user_point = 0;
            dakikka = 0;
            saniye = 0;
            salise = 0;
            labelSure.Text = " 00:00:00";

        }
        private void timerStart()
        {
            timerDakika.Start();
            timerSaniye.Start();
            timerSalise.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_bar_visibility(false);
            radioBtnBilgInsn.Checked = true;
            radioBtnSirali.Checked = true;
            txtKelimeGiris.Enabled = false;
            btnKelimeGir.Enabled = false;
            btnKelimeGirDurum = false;
            btnEkle.Visible = false;
            btnEkleDurum = false;
            timerDakika.Interval = 60000;
            timerSaniye.Interval = 1000;
            timerSalise.Interval = 10;

            //Alphabet Label Create
           /* int x = 13, y = 293;
            char[] alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ".ToCharArray();
            for (int i = 0; i < 29; i++)
            {
                lDizi[i] = new Label();
                lDizi[i].Text = alfabe[i].ToString();
                //lDizi[i].BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                //lDizi[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                lDizi[i].ForeColor = System.Drawing.SystemColors.Info;
                lDizi[i].Location = new System.Drawing.Point(x, y);
                lDizi[i].Margin = new System.Windows.Forms.Padding(0);
                lDizi[i].Name = "Label" + i.ToString();
                lDizi[i].Size = new System.Drawing.Size(18, 18);
                lDizi[i].TabIndex = 8;
                lDizi[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lDizi[i].Enabled = false;
                Controls.Add(lDizi[i]);
                if (x >= 249)
                {
                    x = 22;
                    y += 18;
                }
                else
                    x += 18;
            }*/

            yol = @"sozluk.txt";
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            FormItemsGameStartState();
            timerStart();
            t = new Tree(this);
            //Bilgisayar İnsan ve Sıralı
            if (radioBtnBilgInsn.Checked && radioBtnSirali.Checked)
            {
                t.game_init(yol, false);
                current = t.getRoot();
                listBoxGirilenKelime.Items.Add(current.str_+"\t\t(kalan : " + current._word_left+")");
            }
            //Bilgisayar İnsan ve Kartezyen
            else if (radioBtnBilgInsn.Checked && radioBtnKartezyen.Checked)
            {
                t.game_init(yol, true);
                current = t.getRoot();
                listBoxGirilenKelime.Items.Add(current.str_ + "\t\t(kalan : " + current._word_left + ")");
            }
            //İnsan Bilgisayar ve Sıralı
            else if (radioBtnInsBilg.Checked && radioBtnSirali.Checked)
            {
                t.game_(yol);
                secretWord = t.getRandomWord();
                current = new TreeNode();
                users_guess = new TreeNode();
                current.str_ = secretWord;
                //listBoxGirilenKelime.Items.Add(secretWord);
            }
            //İnsan Bilgisayar ve Kartezyen
            else
            {
                t.game_(yol);
                secretWord = t.getRandomWord();
                current = new TreeNode();
                users_guess = new TreeNode();
                current.str_ = secretWord;
                //listBoxGirilenKelime.Items.Add(secretWord);
            }


        }

        public void gamePause()
        {
            btnKelimeGir.Visible = false;
            btnEkle.Visible = true;
            txtKelimeGiris.Enabled = true;

            timerDakika.Stop();
            timerSaniye.Stop();
            timerSalise.Stop();

        }
        public void btnDurdur_Click(object sender, EventArgs e)
        {
            txtKelimeGiris.Enabled = false;
            btnKelimeGir.Enabled = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            btnBaslat.Visible = true;
            btnBaslat.Enabled = true;
            btnDurdur.Visible = false;
            btnEkle.Visible = false;
            btnKelimeGir.Visible = true;
            btnEkleDurum = false;
            sMenuItem.Enabled = true;
            timerDakika.Stop();
            timerSaniye.Stop();
            timerSalise.Stop();
            dakikka = 0;
            saniye = 0;
            salise = 0;
            listBoxPuan.Items.Clear();
            listBoxGirilenKelime.Items.Clear();
            user_point = 0;
        }
        private void btnKelimeGir_Click(object sender, EventArgs e)
        {
            //TextBox daki değer istenilen şekilde mi?
            if (btnKelimeGirDurum)
            {
                if (txtKelimeGiris.Text.Trim() == "" || (new Regex(@"^[0-9]+$")).IsMatch(txtKelimeGiris.Text.Trim()))
                {
                    txtKelimeGiris.Focus();
                    txtKelimeGiris.Clear();
                    return;
                }
            }
            else
            {
                if (txtKelimeGiris.Text.Trim() == "" ||
                    !(new Regex(@"^[0-9]+$")).IsMatch(txtKelimeGiris.Text.Trim()) || 
                    txtKelimeGiris.Text.Length > 3 )
                {
                    txtKelimeGiris.Focus();
                    txtKelimeGiris.Clear();
                    return;
                }
                
            }

            if (btnKelimeGirDurum && radioBtnSirali.Checked)//İnsan Bilgisayar
            {
                string word = txtKelimeGiris.Text.ToLower();
                users_guess.str_ = word;
                int n_point = t.nPoint(users_guess, current);

                listBoxGirilenKelime.Items.Add(word);
                listBoxPuan.Items.Add(n_point);

                if (users_guess.str_ == current.str_)
                {
                    btnDurdur_Click(this, new EventArgs());
                    MessageBox.Show("Doğru Tahmin :)", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            //İnsan Bilgisayar Kartezyen
            else if (btnKelimeGirDurum && radioBtnKartezyen.Checked)
            {
                string word = txtKelimeGiris.Text.ToLower();
                users_guess.str_ = word;
                int k_point = t.kPoint(users_guess, current);

                listBoxGirilenKelime.Items.Add(word);
                listBoxPuan.Items.Add(k_point);

                if (users_guess.str_ == current.str_)
                {
                    btnDurdur_Click(this, new EventArgs());
                    MessageBox.Show("Doğru Tahmin :)", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            //Bilgisayar İnsan
            else
            {
                user_point = Convert.ToInt32(txtKelimeGiris.Text);

                if (user_point >= 0)
                {
                    if (current.getChild(user_point) == null)
                    {
                        listBoxGirilenKelime.Items.Add("Bulamadım :( ");
                        listBoxPuan.Items.Add(user_point);
                        btnEkleDurum = true;
                        gamePause();
                    }
                    else
                    {
                        listBoxPuan.Items.Add(user_point);
                        current = current.getChild(user_point);
                        listBoxGirilenKelime.Items.Add(current.str_ + "\t\t(kalan : " + current._word_left + ")");
                        txtKelimeGiris.Focus();
                    }
                }

            }
            listBoxGirilenKelime.TopIndex = listBoxGirilenKelime.Items.Count - 1;
            listBoxPuan.TopIndex = listBoxPuan.Items.Count - 1;
            txtKelimeGiris.Clear();
        }

        private void radioBtnBilgInsn_CheckedChanged(object sender, EventArgs e)
        {
            btnKelimeGirDurum = false;
            btnKelimeGir.Text = "Puan Gir";
        }

        private void radioBtnInsBilg_CheckedChanged(object sender, EventArgs e)
        {
            btnKelimeGirDurum = true;
            btnKelimeGir.Text = "Kelime Gir";
        }

        private void timerDakika_Tick(object sender, EventArgs e)
        {
            dakikka++;
            labelSure.Text = "Süre: " + ((dakikka <= 9) ? "0" + dakikka.ToString() : dakikka.ToString()) + ":" + ((saniye <= 9) ? "0" + saniye.ToString() : saniye.ToString()) + ":" + ((salise <= 9) ? "0" + salise.ToString() : salise.ToString());
        }

        private void timerSaniye_Tick(object sender, EventArgs e)
        {
            if (saniye == 60)
                saniye = 0;
            labelSure.Text = "Süre: " + ((dakikka <= 9) ? "0" + dakikka.ToString() : dakikka.ToString()) + ":" + ((saniye <= 9) ? "0" + saniye.ToString() : saniye.ToString()) + ":" + ((salise <= 9) ? "0" + salise.ToString() : salise.ToString());
            saniye++;
        }

        private void timerSalise_Tick(object sender, EventArgs e)
        {
            if (salise == 100)
                salise = 0;
            labelSure.Text = "Süre: " + ((dakikka <= 9) ? "0" + dakikka.ToString() : dakikka.ToString()) + ":" + ((saniye <= 9) ? "0" + saniye.ToString() : saniye.ToString()) + ":" + ((salise <= 9) ? "0" + salise.ToString() : salise.ToString());
            salise++;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtKelimeGiris.Text.Trim() == "" || (new Regex(@"^[0-9]+$")).IsMatch(txtKelimeGiris.Text.Trim()))
            {
                
                txtKelimeGiris.Focus();
                txtKelimeGiris.Clear();
                return;
            }
            if (t.is_there(txtKelimeGiris.Text))
            {
                MessageBox.Show("Kelime Sözlükte Mevcut", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKelimeGiris.Focus();
                txtKelimeGiris.Clear();
                return;
            }

            t.addNode(txtKelimeGiris.Text.ToLower());
            t.add_to_dict(txtKelimeGiris.Text.ToLower());
            MessageBox.Show("Kelime Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtKelimeGiris.Clear();
            btnDurdur_Click(this, new EventArgs());
        }

        private void txtKelimeGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (btnEkleDurum)
                    btnEkle_Click(this, new EventArgs());
                else
                    btnKelimeGir_Click(this, new EventArgs());
            }
        }

        //private void sözlükYoluToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            
            
        //}

        private void sMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Sözlük Dosyası |*.txt";
            //file.InitialDirectory = Environment.GetFolderPath(Environment.);
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Sözlük Seçiniz";
            if (file.ShowDialog() == DialogResult.OK)
            {
                string filePath = file.FileName;
                //string fileName = file.SafeFileName;
                yol = @filePath;
            }
        }

       
    }
}
