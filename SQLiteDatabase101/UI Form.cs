using SQLite_List;
namespace SQLiteDatabase101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*Keep handy for now but this is ***TRASH***
            //string s1 = "delete from Sites where site = " + "'" + "Gilligan" + "'";
            //textBox1.Text = s1;*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}