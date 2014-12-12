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
    public class CargoDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private CargoDAO() { }

        public CargoDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is Cargo)) { return; }
            var cargo = (Cargo)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into Cargo(Number, CargoTypeId, Weight, TripId, Price, InsurancePrice) "
                    + " values({0}, {1}, {2}, {3}, {4}, {5});", cargo.Number, cargo.CargoTypeId, cargo.Weight, cargo.TripId, cargo.Price, cargo.InsurancePrice);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is Cargo)) { return; }
            var cargo = (Cargo)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update Cargo set Number = {0}, CargoTypeId = {1}, Weight = {2}, TripId = {3}, Price = {4}, InsurancePrice = {5} where Id = {6};",
                    cargo.Number, cargo.CargoTypeId, cargo.Weight, cargo.TripId, cargo.Price, cargo.InsurancePrice, cargo.Id);
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
                cmd.CommandText = String.Format("delete from Cargo where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(BaseEntity entity)
        {
            if (!(entity is Cargo)) { return; }
            var cargo = (Cargo)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Cargo where Id = {0};", cargo.Id);
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
                cmd.CommandText = "Select Id, Number, CargoTypeId, Weight, TripId, Price, InsurancePrice from Cargo;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Cargo((int)dr[0], (int)dr[1], (int)dr[2], (int)dr[3], (int)dr[4], Convert.ToDouble(dr[5]), Convert.ToDouble(dr[6])));
                    }
                }
            }
            return retList;
        }
    }
}
