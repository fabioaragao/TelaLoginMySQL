using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TelaLoginMySQLRemoto
{
    public partial class frmCadastroUsuario : Form
    {
        MySqlConnection conexao = new MySqlConnection("server = localhost; UID = root; pwd = root; database = testeloginmysql; port = 3306; SslMode = none");
        MySqlCommand cmd = new MySqlCommand();

        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnVoltarTelaLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            conexao.Open();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "insert into login (usuario,senha) values (?,?)";
                cmd.Parameters.Add("@usuario", MySqlDbType.VarChar, 40).Value = txtCadUsuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 40).Value = txtCadSenha.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso!");
                txtCadUsuario.Clear();
                txtCadSenha.Clear();
                txtRepeteSenha.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex);
            }

            conexao.Close();
        }
    }
}
