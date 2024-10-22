using Challenge02.DAL;
using Challenge02.DAL.MODELS;
using Npgsql;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Challenge02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRPL_Click(object sender, EventArgs e)
        {
            string command = rtbSQLCode.Text;

            if (string.IsNullOrWhiteSpace(command))
                return;

            switch (command)
            {             
                case string s when s.StartsWith("\\t "):
                    List<DAL.MODELS.TableInfo> tableinfo = Repo.GetTableDetails(s.Substring(3));
                    PrintTableInfo(tableinfo);
                    break;

                case "\\tables" when command.Equals("\\tables", StringComparison.OrdinalIgnoreCase):
                    List<string> names = Repo.GetTableNames();
                    PrintTableNames(names);
                    break;

                default:
                    try
                    {
                        if (command.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            var select = Repo.ExecuteQuery(command);
                            PrintResult(select);
                        }
                        else
                        {
                            int rowsAffected = Repo.ExecuteNonSelectQuery(command);
                            lbResult.Items.Add(rowsAffected > 0 ? $"Command executed successfully: {rowsAffected} rows affected" : "No rows affected.");
                        }
                    } catch(Exception ex) {
                        MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                    break;
            }
        }

        private void PrintResult(List<TableTest> results)
        {
            lbResult.Items.Clear();
            lbConnect.Text = "connected";
            if (results == null || results.Count == 0)
            {
                lbResult.Items.Add("No results found.");
                return;
            }

            
            lbResult.Items.Add("ID\tText Value");

            
            foreach (var row in results)
            {
                
                string rowText = $"{row.id}\t{row.text_value}";
                lbResult.Items.Add(rowText);
            }
        }

        private void PrintTableInfo(List<DAL.MODELS.TableInfo> tableinfo)
        {
            lbConnect.Text = "connected";
            lbResult.Items.Clear();
            foreach (var column in tableinfo)
            {
                lbResult.Items.Add($"Name: {column.Name}, Type: {column.DataType}, Nullable: {column.IsNullable}, Default: {column.Default}");
            }
        }

        private void PrintTableNames(List<string> names)
        {
            lbConnect.Text = "connected";
            lbResult.Items.Clear();
            foreach (var name in names)
            {
                lbResult.Items.Add($"Name:  {name}");
            }
        }
    }
}
