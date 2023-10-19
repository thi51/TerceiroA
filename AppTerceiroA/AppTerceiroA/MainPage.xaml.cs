using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTerceiroA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Conexao.strConexao);
            MySqlCommand insereNome = new MySqlCommand(ComandoSQL.insereNome, conn);

            insereNome.Parameters.AddWithValue("@nome", txtNome.Text);

            conn.Open();
            insereNome.ExecuteNonQuery();
            conn.Close();
            txtNome.Text = "";
            await DisplayAlert("Atenção", "Nome inserido com sucesso!", "Ok");
        }
    }
}
