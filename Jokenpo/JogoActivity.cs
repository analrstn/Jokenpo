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
        ImageView imageUsuario;
        ImageView imageBot;
        const string VITORIA = "Vitória", DERROTA = "Derrota", EMPATE = "Empate";
        const int PEDRA = 0, PAPEL = 1, TESOURA = 2;
        string resultado;
        const string VENCEDOR = "Parabéns você venceu!!!!";
        const string PERDEDOR = "Você é fraco, lhe falta ódio!!!!";
        string placar;
        int pontosBot = 0;
        int pontosPlayer = 0;
        public static string resultadoFinal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.jogo);

            btnPapel = FindViewById<ImageButton>(Resource.Id.btnPapel);
            btnPedra = FindViewById<ImageButton>(Resource.Id.btnPedra);
            btnTesoura = FindViewById<ImageButton>(Resource.Id.btnTesoura);
            textpontuacao = FindViewById<TextView>(Resource.Id.textpontuacao);
            textResultado = FindViewById<TextView>(Resource.Id.textResultado);
            imageUsuario = FindViewById<ImageView>(Resource.Id.imageUsuario);
            imageBot = FindViewById<ImageView>(Resource.Id.imageBot);

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

        private void exibirImagem(int escolha, ImageView image)
        {
            string imageName;
            if (escolha == PEDRA)
            {
                imageName = "preda";
            } else if (escolha == PAPEL)
            {
                imageName = "papel";
            } else
            {
                imageName = "tesoura";
            }
            
            int resourceId = (int)typeof(Resource.Drawable).GetField(imageName).GetValue(null);
            image.SetImageResource(resourceId);
        }

        public int comparar(int escolha)
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
            return sorteio;
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
            }
            else if (resultado == DERROTA)
            {
                pontosBot++;
            }
            textResultado.Text = resultado;
        }

        public void jogar(int escolha)
        {
            int sorteio = comparar(escolha);
            contabilizar(resultado);
            calcularPlacar();
            //exibirImagem(escolha, imageUsuario);
            //exibirImagem(sorteio, imageBot);

            if(pontosPlayer > 2 || pontosBot > 2)
            {
                if (pontosPlayer > pontosBot)
                {
                    resultadoFinal = VENCEDOR;
                }
                else
                {
                    resultadoFinal = PERDEDOR;
                }

                zerarPontos();
                StartActivity(typeof(ResultadoActivity));
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
            placar = "Jogador " + pontosPlayer + " x " + pontosBot + " Bot";
            textpontuacao.Text = placar;
        }
    }
}