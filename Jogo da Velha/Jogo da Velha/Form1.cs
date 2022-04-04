using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{
    public partial class Form1 : Form
    {
        int Xpoints = 0, Opoints = 0, Empat = 0, Rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        private void button18_Click(object sender, EventArgs e)
        {

            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            button17.Text = "";
            //Botões

            Rodadas = 0;
            jogo_final = false;
            for(int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Button button9 = (Button)sender;

            int buttonIndex = button9.TabIndex;

            if (button9.Text == "" && jogo_final == false)// fixar seleção do botão
            {

                if (turno)//alternar seleção de X e O
                {
                    button9.Text = "X";
                    texto[buttonIndex] = button9.Text;
                    Rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    button9.Text = "O";
                    texto[buttonIndex] = button9.Text;
                    Rodadas++;
                    turno = !turno;
                    Checagem(2);
                } // final da estrutura
            }
        }// final metodo botão

        void Vencedor(int PlayerWinnner)
        {
            jogo_final = true;
            if(PlayerWinnner == 1)
            {
                Xpoints++;
                label6.Text = Convert.ToString(Xpoints);
                MessageBox.Show("Jogador X Ganhou!!");

                turno = true;
            }
            else
            {
                Opoints++;
                label7.Text = Convert.ToString(Opoints);
                MessageBox.Show("Jogador O Ganhou!!");
                turno = false;
            }

        }

        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if(ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }// final do suporte

            //Verificação Horizontal

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {

                if (suporte == texto[horizontal])
                {
                    //Checagem Horizontal
                    if(texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }// final checagem horizontal
                }
            }// Final do Loop horizontal

            //Verificação Vertical

            for (int Vertical = 0; Vertical < 3; Vertical ++)
            {

                if (suporte == texto[Vertical])
                {
                    //Checagem Vertical
                    if (texto[Vertical] == texto[Vertical + 3] && texto[Vertical] == texto[Vertical + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }//Final checagem Vertical
                }
            }// Final do Loop Vertical

            //Verificação Diagonal

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto [8])
                {

                    Vencedor(ChecagemPlayer);
                    return;

                }// Diagonal Principal
            }
            
            if(texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {

                    Vencedor(ChecagemPlayer);
                    return;

                }//Diagonal Secundaria
            }

            if (Rodadas == 9 && jogo_final == false)
            {
                Empat++;
                label8.Text = Convert.ToString(Empat);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }

        }


    }
}
