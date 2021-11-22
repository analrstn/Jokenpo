using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jokenpo
{
    [Activity(Label = "Activity1")]
    public class JogoActivity : Activity
    {
        ImageButton btnPedra;
        ImageButton btnPapel;
        ImageButton btnTesoura;
        TextView textpontuacao;
        TextView textResultado;
        const string VITORIA = "Vitória", DERROTA = "Derrota", EMPATE = "Empate";
        const int PEDRA = 0, PAPEL = 1, TESOURA = 2;
        string resultado;
        const string VENCEDOR = "Parabéns você venceu!!!!";
        const string PERDEDOR = "Você é fraco, lhe falta ódio!!!!";
        string placar;
        int pontosBot = 0;
        int pontosPlayer = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.jogo);

            btnPapel = FindViewById<ImageButton>(Resource.Id.btnPapel);
            btnPedra = FindViewById<ImageButton>(Resource.Id.btnPedra);
            btnTesoura = FindViewById<ImageButton>(Resource.Id.btnTesoura);
            textpontuacao = FindViewById<TextView>(Resource.Id.textpontuacao);
            textResultado = FindViewById<TextView>(Resource.Id.textResultado);

            btnPedra.Click += BtnPedra_Click;
            btnPapel.Click += BtnPapel_Click;
            btnTesoura.Click += BtnTesoura_Click;
        }

        private void BtnTesoura_Click(object sender, EventArgs e)
        {
            jogar(TESOURA);
        }

        private void BtnPapel_Click(object sender, EventArgs e)
        {
            jogar(PAPEL);
        }

        private void BtnPedra_Click(object sender, EventArgs e)
        {
            jogar(PEDRA);
        }

        public void comparar(int escolha)
        {
            int sorteio = sortear();
            if (escolha == sorteio)
            {
                resultado = EMPATE;
            }
            else if (escolha == PEDRA && sorteio == TESOURA)
            {
                resultado = VITORIA;
            }
            else if (escolha == PEDRA && sorteio == PAPEL)
            {
                resultado = DERROTA;
            }
            else if (escolha == TESOURA && sorteio == PAPEL)
            {
                resultado = VITORIA;
            }
            else if (escolha == TESOURA && sorteio == PEDRA)
            {
                resultado = DERROTA;
            }
            else if (escolha == PAPEL && sorteio == PEDRA)
            {
                resultado = VITORIA;
            }
            else if (escolha == PAPEL && sorteio == TESOURA)
            {
                resultado = DERROTA;
            }

        }

        public int sortear()
        {
            Random random = new Random();
            return random.Next(3);

        }

        public void contabilizar(string resultado)
        {
            if (resultado == VITORIA)
            {
                pontosPlayer++;
                textResultado.Text = VITORIA;
            }
            else if (resultado == DERROTA)
            {
                pontosBot++;
                textResultado.Text = DERROTA;
            }
        }

        public void jogar(int escolha)
        {
            if (pontosPlayer < 3 && pontosBot < 3)
            {
                comparar(escolha);
                contabilizar(resultado);
                calcularPlacar();
            }
            else
            {
                if (pontosPlayer > pontosBot)
                {
                    //alguma coisa deveria acontecer LABEL = VENCEDOR
                }
                else
                {
                    //outra coisa deveria acontecer LABEL = PERDEDOR
                }

                zerarPontos();
            }
        }

        public void zerarPontos()
        {
            pontosBot = 0;
            pontosPlayer = 0;
            textpontuacao.Text = placar;
        }

        public void calcularPlacar()
        {
            placar = "Jogador " + pontosPlayer + " x " + pontosBot + "Bot";
            textpontuacao.Text = placar;
        }
    }
}