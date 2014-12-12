using Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables;

namespace Factory.Implements
{
    /// <summary>
    /// Finished
    /// </summary>
    public class CaptainDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private CaptainDAO() { }

        public CaptainDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is Captain)) { return; }
            var captain = (Captain)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into Captain(FirstName, LastName) values('{0}', '{1}');", captain.FirstName, captain.LastName);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is Captain)) { return; }
            var captain = (Captain)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update Captain set FirstName = '{0}', LastName='{1}' where Id={2};", captain.FirstName, captain.LastName, captain.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(int Id)
        {
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Captain where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(BaseEntity entity)
        {
            if (!(entity is Captain)) { return; }
            var captain = (Captain)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Captain where Id = {0};", captain.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<BaseEntity> GetList()
        {
            List<BaseEntity> retList = new List<BaseEntity>();
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = "select cap.Id, cap.FirstName, cap.LastName from Captain cap;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Captain((int)dr[0], dr[1].ToString(), dr[1].ToString()));
                    }
                }
            }
            return retList;
        }
    }
}
