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
using MySql.Data;

/*videos: https://www.youtube.com/watch?v=Dis38of86HY
https://www.youtube.com/watch?v=ldY7B9CRFuc&t=1036s

    */
namespace TelaLoginMySQLRemoto
{
    public partial class frmLogin : Form
    {
        MySqlConnection conexao = new MySqlConnection();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
