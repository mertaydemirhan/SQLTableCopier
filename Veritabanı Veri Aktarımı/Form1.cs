using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veritabanı_Veri_Aktarımı
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        private SqlConnection con2;
        SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;
        public string veritabaniAdresi;
        public string databaseAdi;
        public string kullaniciAdi;
        public string sifre;
        public bool durum = false;
        public bool listeli = false;
        public Int32 instanceOnay = 0;
        public string newInstance;

        SqlCommand cmd2 = new SqlCommand();
        private SqlDataReader dr2;

        SqlCommand cmd3 = new SqlCommand();
        private SqlDataReader dr3;

        public Form1()
        {
        InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                listBox1.Items.Add("Bağlantı kuruluyor...");
#pragma warning disable CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                con = new SqlConnection("Server=" + KSunucuAdresiBox.Text + ";Database=" + comboBox2.Text + ";User Id=" + KKullaniciAdiBox.Text + ";Password=" + KParolaBox.Text + "; connection timeout=30;");
#pragma warning restore CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                //con.Open();
                //cmd.Connection = con;
                cmd2.Connection = con;
                //cmd.CommandText = @"select * from sys.tables";
                //dr = cmd.ExecuteReader();


                //TABLO LİSTESİNİ COMBOBOX'A ATAR
                comboBox1.Items.Clear();
                //while (dr.Read())
                // {
                //    comboBox1.Items.Add(dr[0]);

                // }
                // con.Close();
                //VERİTABANI LİSTESİNİ COMBOBOX'A ATAR
                con.Open();
                cmd2.CommandText = @"select * from sys.databases order by name asc";
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {

                    comboBox2.Items.Add(dr2[0]);
                    cmbYVeritabaniBox.Items.Add(dr2[0]);    
                }
                con.Close();

                veritabaniAdresi = KSunucuAdresiBox.Text;
#pragma warning disable CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                databaseAdi = comboBox2.Text;
#pragma warning restore CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                kullaniciAdi = KKullaniciAdiBox.Text;
                sifre = KParolaBox.Text;

               


                listBox1.Items.Add("Bağlantı işlemi başarılı...");
                //MessageBox.Show("Bağlantı başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglantiDurumu.Text = "AKTİF";
                baglantiDurumu.ForeColor = Color.Green;

                durum = true;
#pragma warning disable CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                //comboBox2.Enabled = false;
#pragma warning restore CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
                KSunucuAdresiBox.Enabled = false;
                KKullaniciAdiBox.Enabled = false;
                KParolaBox.Enabled = false;
                button1.Enabled = false;

            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Bağlantı işlemi başarısız.");
                MessageBox.Show("Bir hata meydana geldi : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantiDurumu.Text = "Başarısız";
                baglantiDurumu.ForeColor = Color.Red;

            }


        }
        public DataTable dt = new DataTable();
        public DataTable dtFiltered = new DataTable();
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dt.Clear();
            try
            {

                if (durum == true)
                {
                    if (!String.IsNullOrEmpty(comboBox1.Text))
                    {
                        listBox1.Items.Add("Veriler alınıyor...");
                        cmbYTabloAdiBox.Enabled = false;

                        dt.Columns.Clear();
                        dt.Rows.Clear();
                        // dataGridView1.DataSource = dt;

                        //dataGridView1.Refresh();
                        con = new SqlConnection("Server=" + veritabaniAdresi + ";Database=" + comboBox2.SelectedItem.ToString() + ";User Id=" + kullaniciAdi + ";Password=" + sifre + "; connection timeout=30;");
                        if (checkBox2.Checked)
                        {
                            string QueryInfo = "select * from " + comboBox1.Text;

                            if (!String.IsNullOrEmpty(cmbFilter1.Text))
                            {
                                if (!string.IsNullOrEmpty(txtFilter1.Text))
                                    QueryInfo += " WHERE " + cmbFilter1.Text +  cmbCriteria1.Text + "'" + txtFilter1.Text + "'";

                            }
                            if (!String.IsNullOrEmpty(cmbFilter2.Text))
                            {
                                if (!string.IsNullOrEmpty(txtFilter2.Text) && !String.IsNullOrEmpty(cmbFilter1.Text) && !String.IsNullOrEmpty(txtFilter1.Text))
                                    QueryInfo += " AND " + cmbFilter2.Text + cmbCriteria2.Text + "'" + txtFilter2.Text + "'";

                            }
                            if (!String.IsNullOrEmpty(cmbFilter3.Text))
                            {
                                if (!string.IsNullOrEmpty(txtFilter3.Text) && !String.IsNullOrEmpty(cmbFilter1.Text) && !String.IsNullOrEmpty(txtFilter1.Text))
                                    QueryInfo += " AND " + cmbFilter3.Text + cmbCriteria3.Text + "'" + txtFilter3.Text + "'";

                            }
                            if (!String.IsNullOrEmpty(cmbFilter4.Text))
                            {
                                if (!string.IsNullOrEmpty(txtFilter4.Text) && !String.IsNullOrEmpty(cmbFilter1.Text) && !String.IsNullOrEmpty(txtFilter1.Text))
                                    QueryInfo += " AND " + cmbFilter4.Text + cmbCriteria4.Text + "'" + txtFilter4.Text + "'";

                            }
                            if (!String.IsNullOrEmpty(cmbFilter5.Text))
                            {
                                if(!string.IsNullOrEmpty(cmbCriteria5.Text) && !String.IsNullOrEmpty(cmbFilter1.Text))
                                {
                                    QueryInfo += "AND DATEADD(DAY,DATEDIFF(DAY,0," + cmbFilter5.Text + "),0)" + cmbCriteria5.Text + "'" + dtpFilter1.Value + "'";
                                }
                                if (String.IsNullOrEmpty(cmbFilter1.Text))
                                {
                                    QueryInfo += " WHERE DATEADD(DAY,DATEDIFF(DAY,0," + cmbFilter5.Text + "),0)" + cmbCriteria5.Text + "'" + dtpFilter1.Value + "'";
                                }

                            }
                            if (!String.IsNullOrEmpty(cmbFilter6.Text))
                            {
                                if (!string.IsNullOrEmpty(cmbCriteria6.Text) && !String.IsNullOrEmpty(cmbFilter1.Text))
                                {
                                    QueryInfo += "AND DATEADD(DAY,DATEDIFF(DAY,0," + cmbFilter6.Text + "),0)" + cmbCriteria6.Text + "'" + dtpFilter2.Value + "'";
                                }
                                if (String.IsNullOrEmpty(cmbFilter1.Text))
                                {
                                    if (!String.IsNullOrEmpty(cmbFilter6.Text))
                                    QueryInfo += " AND DATEADD(DAY,DATEDIFF(DAY,0," + cmbFilter6.Text + "),0)" + cmbCriteria6.Text + "'" + dtpFilter2.Value + "'";
                                    else
                                    QueryInfo += " WHERE DATEADD(DAY,DATEDIFF(DAY,0," + cmbFilter6.Text + "),0)" + cmbCriteria6.Text + "'" + dtpFilter2.Value + "'";
                                }

                            }
                            listBox1.Items.Add(QueryInfo);
                            using (con)
                            {

                                SqlCommand komut = new SqlCommand(QueryInfo, con);

                                SqlDataAdapter da = new SqlDataAdapter(komut);


                                da.Fill(dt);

                                dataGridView1.DataSource = dt;
                                dataGridView1.Refresh();
                                this.Width = 1215;

                                con.Close();

                                listeli = true;
                                cmbYTabloAdiBox.Text = comboBox1.Text;
                                listBox1.Items.Add("Veriler sağ tabloda gösteriliyor...");
                                // MessageBox.Show("Veri çekme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        if (checkBox2.Checked != true)
                        {
                            using (con)
                            {
                                string kayit = "SELECT * from " + comboBox1.Text;

                                SqlCommand komut = new SqlCommand(kayit, con);

                                SqlDataAdapter da = new SqlDataAdapter(komut);


                                da.Fill(dt);

                                dataGridView1.DataSource = dt;
                                dataGridView1.Refresh();
                                //this.Width = 1215;

                                con.Close();

                                listeli = true;
                                cmbYTabloAdiBox.Text = comboBox1.Text;
                                listBox1.Items.Add("Veriler sağ tabloda gösteriliyor...");
                                // MessageBox.Show("Veri çekme işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }


                        //con.Open();

                    }
                    else
                    {
                        MessageBox.Show("Lütfen listelenecek bir tablo seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sunucu bağlantısı kurulmadan veriler çekilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                listBox1.Items.Add("Veri çekme işlemi başarısız.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
        public static void DataTableKopyala(DataTable dt, string tableName, SqlConnection conn, ComboBox cmbDatabase)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM sysobjects where name = '" + tableName + "'", conn);


            
            bool tabloVar = cmd.ExecuteScalar() != null;


            if (!tabloVar)
            {
                string cmdText = CreateTableSQL(tableName, dt);
                SqlCommand ct = new SqlCommand(cmdText, conn);
                ct.ExecuteNonQuery();
            }

            using (var bulkCopy = new SqlBulkCopy(conn.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                SqlCommand tmpveribas = new SqlCommand("select name from "+ cmbDatabase.Text+ ".sys.all_columns where object_id in (SELECT object_id FROM " + cmbDatabase.Text + ".sys.all_objects where name='"+tableName+"')", conn);
                SqlDataAdapter tmpda = new SqlDataAdapter(tmpveribas);
                DataTable temptable = new DataTable();
                tmpda.Fill(temptable);
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.ToString() == "TARIHI2")
                    {

                    }
                    else
                    {
                        
                        try
                        {
                            foreach (DataRow row in temptable.Rows)
                            {
                               
                                //MessageBox.Show("Temp Table : "+ row[0].ToString() + " Kopyalanan Row : " + col.ColumnName.ToString());
                                if(row[0].ToString() == col.ColumnName.ToString())
                                {
                                    if (col.ColumnName.ToString() == "SCR_TUR")
                                        MessageBox.Show("");
                                    bulkCopy.ColumnMappings.Add(col.ColumnName.ToString(), col.ColumnName.ToString());
                                }
                                
                            }
                            bulkCopy.BulkCopyTimeout = 600;
                            bulkCopy.DestinationTableName = tableName;
                            bulkCopy.WriteToServer(dt);

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("HATA İLE KARŞILAŞILDI" +  "Kolon ismi : "+col.ColumnName.ToString() + "Kopyalanan Kolon :"+ temptable.Rows[0].ToString());
                        }

                    }
                }


                /* System.InvalidOperationException: 'Verilen ColumnMapping, kaynak veya hedefteki hiçbir sütunla eşleşmiyor .'*/
            }
        }


        public static string CreateTableSQL(string tableName, DataTable table)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + tableName + " (";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
        public List<string> GETBLKODU()
        {
            List<string> ids = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                ids.Add((string)row["BLKODU"]);
                if(dt.Rows.IndexOf(row) != 0)
                ids.Add(",");
               
            }
            return ids;
                
        }
        public List<string> GETBLKODUSHR()
        {
            List<string> ids = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                
                ids.Add("FT_"+(string)row["BLKODU"]);
                if (dt.Rows.IndexOf(row) != 0)
                    ids.Add(",");

            }
            return ids;
        }
        public List<string> GETBLKODUCHR()
        {
            List<string> ids = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {

                ids.Add("FTO_" + (string)row["BLKODU"]);
                if (dt.Rows.IndexOf(row) != 0)
                    ids.Add(",");

            }
            return ids;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (instanceOnay == 0) //yeni instance girmek istemiyorsa çalışacak kod bloğu
            {
                if (listeli == true) //veri çekme işlemi yaptıysa
                {
                    listBox1.Items.Add(" veriler kopyalanıyor...");
                    con = new SqlConnection("Server=" + veritabaniAdresi + ";Database=" + cmbYVeritabaniBox.Text + ";User Id=" + KKullaniciAdiBox.Text + ";Password=" + KParolaBox.Text + "; connection timeout=30; persist security info=true;");
                    con.Open();

                    DataTableKopyala(dt, cmbYTabloAdiBox.Text, con, comboBox2);

                    if (rbFatura.Checked)
                    {
                        try
                        {
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURAHR WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daFHR = new SqlDataAdapter(komut);
                                daFHR.Fill(dt);
                                DataTableKopyala(dt, "FATURAHR", con, comboBox2);
                                listBox1.Items.Add("Fatura hareketleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_KDV WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daKDV = new SqlDataAdapter(komut);
                                daKDV.Fill(dt);
                                DataTableKopyala(dt, "FATURA_KDV", con, comboBox2);
                                listBox1.Items.Add("Fatura kdvleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_SERI WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daSERI = new SqlDataAdapter(komut);
                                daSERI.Fill(dt);
                                DataTableKopyala(dt, "FATURA_SERI", con, comboBox2);
                                listBox1.Items.Add("Fatura seri/lot hareketleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_DISMODUL WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daDISMODUL = new SqlDataAdapter(komut);
                                daDISMODUL.Fill(dt);
                                DataTableKopyala(dt, "FATURA_DISMODUL", con, comboBox2);
                                listBox1.Items.Add("Fatura bağlantıları insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_KUR WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daKUR = new SqlDataAdapter(komut);
                                daKUR.Fill(dt);
                                DataTableKopyala(dt, "FATURA_KUR", con, comboBox2);
                                listBox1.Items.Add("Fatura kur bilgileri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM STOKHR WHERE ENTEGRASYON IN(" + GETBLKODUSHR() + ")", con);
                                SqlDataAdapter daSHR = new SqlDataAdapter(komut);
                                daSHR.Fill(dt);
                                DataTableKopyala(dt, "STOKHR", con, comboBox2);
                                listBox1.Items.Add("Stok hareket bilgileri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM CARIHR WHERE ENTEGRASYON IN(" + GETBLKODUSHR() + ")", con);
                                SqlDataAdapter daCHR = new SqlDataAdapter(komut);
                                daCHR.Fill(dt);
                                DataTableKopyala(dt, "CARIHR", con, comboBox2);
                                listBox1.Items.Add(" Cari hareket bilgileri insert edildi...");
                            }
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Çok kritik hata." + Environment.NewLine + Ex.ToString());
                        }

                    }

                    con.Close();
                    listBox1.Items.Add("Tablo kopyalama başarılı.");
                    MessageBox.Show("Kopyalama işlemi başarılı bir şekilde tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } 
                else
                {
                    MessageBox.Show("Lütfen önce tablo verilerini çekiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //yeni instance girmek istiyosa çalışacak kod
            {
                if (listeli == true) //veriçekme işlemi yaptıysa 
                {
                    newInstance = textBox1.Text;
                    listBox1.Items.Add(" veriler kopyalanıyor...");
                    con = new SqlConnection("Server=" + newInstance + ";Database=" + cmbYVeritabaniBox.Text + ";User Id=" + textBox2.Text + ";Password=" + textBox3.Text + "; connection timeout=30; persist security info=true;");
                    con.Open();

                    DataTableKopyala(dt, cmbYTabloAdiBox.Text, con, comboBox2);

                    if (rbFatura.Checked)
                    {
                        try
                        {
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURAHR WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daFHR = new SqlDataAdapter(komut);
                                daFHR.Fill(dt);
                                DataTableKopyala(dt, "FATURAHR", con, comboBox2);
                                listBox1.Items.Add("Fatura hareketleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_KDV WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daKDV = new SqlDataAdapter(komut);
                                daKDV.Fill(dt);
                                DataTableKopyala(dt, "FATURA_KDV", con, comboBox2);
                                listBox1.Items.Add("Fatura kdvleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_SERI WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daSERI = new SqlDataAdapter(komut);
                                daSERI.Fill(dt);
                                DataTableKopyala(dt, "FATURA_SERI", con, comboBox2);
                                listBox1.Items.Add("Fatura seri/lot hareketleri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_DISMODUL WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daDISMODUL = new SqlDataAdapter(komut);
                                daDISMODUL.Fill(dt);
                                DataTableKopyala(dt, "FATURA_DISMODUL", con, comboBox2);
                                listBox1.Items.Add("Fatura bağlantıları insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM FATURA_KUR WHERE BLFTKODU IN(" + GETBLKODU() + ")", con);
                                SqlDataAdapter daKUR = new SqlDataAdapter(komut);
                                daKUR.Fill(dt);
                                DataTableKopyala(dt, "FATURA_KUR", con, comboBox2);
                                listBox1.Items.Add("Fatura kur bilgileri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM STOKHR WHERE ENTEGRASYON IN(" + GETBLKODUSHR() + ")", con);
                                SqlDataAdapter daSHR = new SqlDataAdapter(komut);
                                daSHR.Fill(dt);
                                DataTableKopyala(dt, "STOKHR", con, comboBox2);
                                listBox1.Items.Add("Stok hareket bilgileri insert edildi...");
                            }
                            using (con)
                            {
                                dt.Clear();
                                SqlCommand komut = new SqlCommand("SELECT * FROM CARIHR WHERE ENTEGRASYON IN(" + GETBLKODUSHR() + ")", con);
                                SqlDataAdapter daCHR = new SqlDataAdapter(komut);
                                daCHR.Fill(dt);
                                DataTableKopyala(dt, "CARIHR", con, comboBox2);
                                listBox1.Items.Add(" Cari hareket bilgileri insert edildi...");
                            }
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Çok kritik hata." + Environment.NewLine + Ex.ToString());
                        }

                    }

                    con.Close();
                    listBox1.Items.Add("Tablo kopyalama başarılı.");
                    MessageBox.Show("Kopyalama işlemi başarılı bir şekilde tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } 
            }
        }

        private void versionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arel Güncel version 0.1", "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu yazılım ARELBİLİŞİM veritabanı tablo kopyalama yazılımıdır.", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            KSunucuAdresiBox.Text = Properties.Settings.Default.KayitliSunucuAdresi;
            KKullaniciAdiBox.Text = Properties.Settings.Default.KayitliKullaniciAdi;
            KParolaBox.Text = Properties.Settings.Default.KayitliSifre;
#pragma warning disable CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
            comboBox2.Text = Properties.Settings.Default.VeritabaniAdiii;
#pragma warning restore CS0103 // The name 'KVeritabaniAdiBox' does not exist in the current context
            groupBox5.Enabled = false;
            grpTransfer.Enabled = false;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kaydetForm kaydetfrm = new kaydetForm();
            kaydetfrm.Show();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            
            //Filtreleme ayarları
            con = new SqlConnection("Server=" + KSunucuAdresiBox.Text + ";Database=" + comboBox2.SelectedItem.ToString() + ";User Id=" + KKullaniciAdiBox.Text + ";Password=" + KParolaBox.Text + "; connection timeout=30;");
            con.Open();
            cmd.Connection = con;
            //cmd2.Connection = con;
            cmd.CommandText = @"select name,system_type_id from sys.columns where object_id=(select object_id from sys.tables where name='" + comboBox1.SelectedItem.ToString()+"')";
            dr = cmd.ExecuteReader();


            //KOLON LİSTESİNİ COMBOBOX'A ATAR
            cmbFilter1.Items.Clear();
            cmbFilter2.Items.Clear();
            cmbFilter3.Items.Clear();
            cmbFilter4.Items.Clear();
            cmbFilter1.Items.Add("");
            cmbFilter2.Items.Add("");
            cmbFilter3.Items.Add("");
            cmbFilter4.Items.Add("");

            while (dr.Read())
            {
                cmbFilter1.Items.Add(dr[0]);
                cmbFilter2.Items.Add(dr[0]);
                cmbFilter3.Items.Add(dr[0]);
                cmbFilter4.Items.Add(dr[0]);
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                if (Convert.ToInt32(dr[1]) == 61)
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
                {
                    cmbFilter5.Items.Add(dr[0]);
                    cmbFilter6.Items.Add(dr[0]);
                }

            }
            con.Close();
            switch (comboBox1.Text)
            {
                case "FATURA":
                    rbFatura.Checked = true;
                    break;
                case "TEKLIF":
                    rbTeklif.Checked = true;
                    break;
                case "IRSALIYE":
                    rbIrsaliye.Checked = true;
                    break;
                case "SIPARIS":
                    rbSiparis.Checked = true;
                    break;
                default:
                    rbTek.Checked = true;
                    break;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection("Server=" + KSunucuAdresiBox.Text + ";Database=" + comboBox2.SelectedItem.ToString() + ";User Id=" + KKullaniciAdiBox.Text + ";Password=" + KParolaBox.Text + "; connection timeout=30;");
            con.Open();
            cmd.Connection = con;
            cmd2.Connection = con;
            cmd.CommandText = @"select * from sys.tables order by name asc";
            dr = cmd.ExecuteReader();


            //TABLO LİSTESİNİ COMBOBOX'A ATAR
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                cmbYTabloAdiBox.Items.Add(dr[0]);
                

            }
            con.Close();

            


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked) 
            {
                txtFilter1.Text = null;
                txtFilter2.Text = null;
                txtFilter3.Text = null;
                txtFilter4.Text = null;
                cmbCriteria1.SelectedIndex = 0;
                cmbCriteria2.SelectedIndex = 0;
                cmbCriteria3.SelectedIndex = 0;
                cmbCriteria4.SelectedIndex = 0;
                cmbCriteria5.SelectedIndex = 0;
                cmbCriteria6.SelectedIndex = 0;
                cmbFilter1.SelectedIndex = 0;
                cmbFilter2.SelectedIndex = 0;
                cmbFilter3.SelectedIndex = 0;
                cmbFilter4.SelectedIndex = 0;
                cmbFilter5.SelectedIndex = 0;
                cmbFilter6.SelectedIndex = 0;

                groupBox5.Enabled = false; 
            }
           if (checkBox2.Checked) groupBox5.Enabled = true; 
           if (groupBox5.Enabled)
            {
                cmbFilter1.Enabled = true;
                cmbFilter2.Enabled = false;
                cmbFilter3.Enabled = false;
                cmbFilter4.Enabled = false;
                txtFilter1.Enabled = true;
                txtFilter2.Enabled = false;
                txtFilter3.Enabled = false;
                txtFilter4.Enabled = false;
                cmbCriteria1.Enabled = true;
                cmbCriteria2.Enabled = false;
                cmbCriteria3.Enabled = false;
                cmbCriteria4.Enabled = false;


            } 
        }

        private void cmbFilter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFilter1.Text))
            {
                txtFilter1.Text = null;
                txtFilter2.Text = null;
                txtFilter3.Text = null;
                txtFilter4.Text = null;
                cmbCriteria1.SelectedIndex = 0;
                cmbCriteria2.SelectedIndex = 0;
                cmbCriteria3.SelectedIndex = 0;
                cmbCriteria4.SelectedIndex = 0;
                cmbFilter1.Enabled = true;
                cmbFilter2.Enabled = false;
                cmbFilter3.Enabled = false;
                cmbFilter4.Enabled = false;
                txtFilter1.Enabled = false;
                txtFilter2.Enabled = false;
                txtFilter3.Enabled = false;
                txtFilter4.Enabled = false;
                cmbCriteria1.Enabled = false;
                cmbCriteria2.Enabled = false;
                cmbCriteria3.Enabled = false;
                cmbCriteria4.Enabled = false;  
            }
        }

        private void txtFilter1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFilter1.Text)) 
            {
                cmbFilter2.Enabled = true; txtFilter2.Enabled = true;
                cmbFilter3.Enabled = true; txtFilter3.Enabled = true;
                cmbFilter4.Enabled = true; txtFilter4.Enabled = true;
                cmbCriteria2.Enabled=true;
                cmbCriteria3.Enabled=true;  
                cmbCriteria4.Enabled=true;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //this.Width = 1215;
        }

        private void cmbFilter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFilter2.Text))
            {
                txtFilter2.Text = null;
                txtFilter3.Text = null;
                txtFilter4.Text = null;
                cmbCriteria2.SelectedIndex = 0;
                cmbCriteria3.SelectedIndex = 0;
                cmbCriteria4.SelectedIndex = 0;
                cmbFilter3.Enabled = false;
                cmbFilter4.Enabled = false;
                txtFilter2.Enabled = false;
                txtFilter3.Enabled = false;
                txtFilter4.Enabled = false;
                cmbCriteria2.Enabled = false;
                cmbCriteria3.Enabled = false;
                cmbCriteria4.Enabled = false;
            }
        }

        private void cmbFilter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFilter3.Text))
            {
                txtFilter3.Text = null;
                txtFilter4.Text = null;
                cmbCriteria3.SelectedIndex = 0;
                cmbCriteria4.SelectedIndex = 0;
                cmbFilter4.Enabled = false;
                txtFilter3.Enabled = false;
                txtFilter4.Enabled = false;
                cmbCriteria3.Enabled = false;
                cmbCriteria4.Enabled = false;


            }
        }

        private void cmbFilter4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFilter4.Text))
            {
                txtFilter4.Text = null;
                cmbCriteria4.SelectedIndex = 0;
                txtFilter4.Enabled = false;
                cmbCriteria4.Enabled = false;

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
                Clipboard.SetDataObject(this.listBox1.SelectedItem.ToString());

        }

        private void cmbYVeritabaniBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                // instance girmez ise bu kısım çalışacak
            }
            else
            {//instance farklı istediğinde bu kısım devreye giriyor
                newInstance = textBox1.Text;
                listBox1.Items.Add(" veriler kopyalanıyor...");
                con2 = new SqlConnection("Server=" + textBox1.Text + ";Database=" + cmbYVeritabaniBox.Text + ";User Id=" + textBox2.Text + ";Password=" + textBox3.Text + "; connection timeout=30; persist security info=true;");
                con2.Open();
                cmd3.Connection = con2;
                //MessageBox.Show("Bağlantı başarılı!");
                cmd3.CommandText = @"select * from sys.tables order by name asc";
                dr3 = cmd3.ExecuteReader();
                cmbYTabloAdiBox.Items.Clear();
                while (dr3.Read())
                {

                    cmbYTabloAdiBox.Items.Add(dr3[0]);

                }
                con2.Close();
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                MessageBox.Show("Dikkat: Bilgiler ilk bağlantı yapılan Eski veritabanı bağlantısına göre alınacak.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = null;
                label21.Enabled = false;
                textBox1.Enabled = false;
                button2.Enabled = false;
                label22.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                instanceOnay = 0;
            }
            else
            {
                MessageBox.Show("Aşağıdan yeni veritabanı bilgilerini girip, bağlan demeniz gerekiyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label21.Enabled = true;
                textBox1.Enabled = true;
                button2.Enabled = true;
                label22.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                instanceOnay = 1;
                

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            newInstance = textBox1.Text;
            listBox1.Items.Add("Uzak veritabanına bağlanılıyor...");
            con2 = new SqlConnection("Server=" + textBox1.Text +  ";User Id=" + textBox2.Text + ";Password=" + textBox3.Text + "; connection timeout=30; persist security info=true;");
            con2.Open(); //bağlantıyı aç
            cmd3.Connection = con2;
            MessageBox.Show("Bağlantı başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd3.CommandText = @"select * from sys.databases order by name asc";
            dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {

               // cmbYTabloAdiBox.Items.Add(dr3[0]);
                 cmbYVeritabaniBox.Items.Add(dr3[0]);    
            }
            con2.Close(); //bağlantıyı kapat


        }
    }
}
