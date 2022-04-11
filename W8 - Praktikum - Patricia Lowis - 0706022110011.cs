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

namespace W8___Praktikum___Cbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string sqlConnection = "server=localhost;uid=root;pwd=;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            DataTable dtTeamL = new DataTable();
            DataTable dtTeamR = new DataTable();
            sqlQuery = "SELECT t.team_name as `Team Name`, m.manager_name as `Manager`, t.team_id as 'ID Team', t.home_stadium as 'Home Stadium', t.capacity as 'Capacity', p.player_name FROM team t, manager m, player p where t.manager_id = m.manager_id and p.player_id = t.captain_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeamL);
            sqlAdapter.Fill(dtTeamR);
            cBoxLeft.DataSource = dtTeamL;
            cBoxRight.DataSource = dtTeamR;
            cBoxLeft.DisplayMember = "Team Name";
            cBoxRight.DisplayMember = "Team Name";

            //lbl_isiStadium.Text.= dtTeam.Rows;
            //lbl_isiKapasitas.Text = "Capacity";

        }

        private void lblManagerL_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            DataTable dt1= new DataTable();            
            sqlQuery = "SELECT t.team_name, t.team_id, t.home_stadium, t.capacity , m.manager_name, p.player_name FROM team t, manager m, player p where t.manager_id = m.manager_id and p.player_id = t.captain_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dt1);

            lblManagerL.Text = dt1.Rows[cBoxLeft.SelectedIndex][4].ToString();
            lblCaptainL.Text = dt1.Rows[cBoxLeft.SelectedIndex][5].ToString();
            lblStadium.Text = dt1.Rows[cBoxRight.SelectedIndex][2].ToString();
            lblCapacity.Text = dt1.Rows[cBoxRight.SelectedIndex][3].ToString();

        }

        private void cBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            sqlQuery = "SELECT t.team_name, t.team_id, t.home_stadium, t.capacity , m.manager_name, p.player_name FROM team t, manager m, player p where t.manager_id = m.manager_id and p.player_id = t.captain_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dt2);

            lblManagerR.Text = dt2.Rows[cBoxRight.SelectedIndex][4].ToString();
            lblCaptainR.Text = dt2.Rows[cBoxRight.SelectedIndex][5].ToString();
            
        }
    }
}
