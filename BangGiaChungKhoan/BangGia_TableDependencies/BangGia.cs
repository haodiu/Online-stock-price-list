using BangGiaChungKhoan.Hubs;
using BangGiaChungKhoan.Models;
using TableDependency.SqlClient;

namespace BangGiaChungKhoan.BangGia_TableDependencies
{
    public class BangGia
    {
        SqlTableDependency<BANGGIATRUCTUYEN> tableDependency;

        BangGiaHub bangGiaHub;
        public BangGia(BangGiaHub bangGiaHub)
        {
            this.bangGiaHub = bangGiaHub;
        }
        public void BangGia_TabbleDependency()
        {
            string connectionString = "Data Source=DESKTOP-3DSC91T;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=123456";
            tableDependency = new SqlTableDependency<BANGGIATRUCTUYEN>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<BANGGIATRUCTUYEN> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                bangGiaHub.SendPrices();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(BANGGIATRUCTUYEN)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
