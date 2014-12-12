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
    public class CityDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private CityDAO() { }

        public CityDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is City)) { return; }
            var city = (City)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into City(Name) values('{0}');", city.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is City)) { return; }
            var city = (City)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("Update City set Name = '{0}' where Id = {1};",
                    city.Name, city.Id);
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
                cmd.CommandText = String.Format("delete from City where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(Tables.BaseEntity entity)
        {
            if (!(entity is City)) { return; }
            var city = (City)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from City where Id = {0};", city.Id);
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
                cmd.CommandText = "select Id, Name from City;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new City((int)dr[0], dr[1].ToString()));
                    }
                }
            }
            return retList;
        }
    }
}
