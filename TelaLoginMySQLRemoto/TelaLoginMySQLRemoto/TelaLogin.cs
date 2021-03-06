﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

  
namespace TelaLoginMySQLRemoto
{
    public partial class frmLogin : Form
    {
        MySqlConnection conexao = new MySqlConnection("server = localhost; UID = root; pwd = root; database = testeloginmysql; port = 3306; SslMode = none");
        MySqlCommand cmd = new MySqlCommand();


        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            conexao.Open();
            cmd.Connection = conexao;

            try
            {
                cmd.CommandText = "select * from login where usuario = '" + txtUsuario.Text + "' and senha = '" + txtSenha.Text + "'";
                
                MySqlDataReader ler = cmd.ExecuteReader();
                
                if(ler.Read())
                {
                    MessageBox.Show("Seja Bem Vindo!!!");
                }
                else
                {
                    MessageBox.Show("Ops, aconteceu algum problema\n\n " +
                        "Usuário ou senha inválido(s)\n ou\n Usuário não cadastrado", "Atenção!", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex);
            }

            conexao.Close();
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario cadastro = new frmCadastroUsuario();
            cadastro.Show();
            this.Hide();
        }
    }
}
