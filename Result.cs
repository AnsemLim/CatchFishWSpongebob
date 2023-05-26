using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace CatchFishGame
{

    public partial class Result : Form
    {
        OleDbConnection con = new OleDbConnection(Properties.Resources.ConnectionString);
        PrivateFontCollection newFont = new PrivateFontCollection();
        public Result()
        {
            InitializeComponent();
            LoadAsset();
        }
        public void LoadAsset()
        {
            newFont.AddFontFile("assets/font/Pixel_Font.TTF");
            lblTitle.Font = new Font(newFont.Families[0], 36, FontStyle.Bold);
            btnHome.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
        }
        private void playerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gamedbDataSet);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT PlayerName,Score,ExtraTime FROM Player";
            dataGridView1.DataSource = insertTable(sql);

            chart1.DataSource = insertTable(sql);
            chart1.ChartAreas[0].AxisX.Title = "Player Name";
            chart1.ChartAreas[0].AxisY.Title = "Score and Time";
            chart1.Series["Score"].XValueMember = "PlayerName";
            chart1.Series["Extra Time"].XValueMember = "PlayerName";
            chart1.Series["Extra Time"].YValueMembers = "ExtraTime";
            chart1.Series["Score"].YValueMembers = "Score";
            con.Close();
        }

        private DataTable insertTable(string sql)
        {
            DataTable table = new DataTable();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con))
            {
                adapter.Fill(table);
            }
            return table;
        }

    }
}
