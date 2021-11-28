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
    [Activity(Label = "ResultadoActivity")]
    public class ResultadoActivity : Activity
    {
        TextView resultado;
        Button btnJogarNovamente;
        Button btnTelaInicial;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.resultado);
            resultado = FindViewById<TextView>(Resource.Id.resultado);
            btnJogarNovamente = FindViewById<Button>(Resource.Id.btnJogarNovamente);
            btnTelaInicial = FindViewById<Button>(Resource.Id.btnTelaInicial);
            resultado.Text = JogoActivity.resultadoFinal;

            btnJogarNovamente.Click += BtnJogarNovamente_Click;
            btnTelaInicial.Click += BtnTelaInicial_Click;
        }

        private void BtnTelaInicial_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void BtnJogarNovamente_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(JogoActivity));
        }


    }
}