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
    public class PortDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private PortDAO() { }

        public PortDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is Port)) { return; }
            var port = (Port)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into Port(Name, CityId) values ('{0}', {1});", port.Name, port.CityId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is Port)) { return; }
            var port = (Port)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update Port set Name = '{0}', CityId = {1} where Id ={2};", port.Name, port.CityId, port.Id);
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
                cmd.CommandText = String.Format("delete from Port where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(BaseEntity entity)
        {
            if (!(entity is Port)) { return; }
            var port = (Port)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Port where Id = {0};", port.Id);
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
                cmd.CommandText = "Select p.Id, p.Name, p.CityId from Port p;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Port((int)dr[0], dr[1].ToString(), (int)dr[2]));
                    }
                }
            }
            return retList;
        }
    }
}
