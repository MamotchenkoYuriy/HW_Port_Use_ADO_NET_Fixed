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
    public class ShipDAO:IDAO
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        DbProviderFactory dbProviderFactory = null;

        private ShipDAO() { }

        public ShipDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is Ship)) { return; }
            var ship = (Ship)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into Ship(Number, Capacity, CreateDate,MaxDistance, TeamCount, PortId, CaptainId ) " +
                    "values ('{0}', {1}, '{2}', {3}, {4}, {5}, {6});", ship.Number, ship.Capacity, ship.CreateDate, ship.MaxDistance, 
                    ship.TeamCount, ship.PortId, ship.CaptainId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is Ship)) { return; }
            var ship = (Ship)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update Ship set Number = '{0}', Capacity = {1}, CreateDate = '{2}', MaxDistance = {3}, TeamCount = {4}, PortId = {5}, CaptainId = {6} where Id = {7};", 
                    ship.Number, ship.Capacity, ship.CreateDate, ship.MaxDistance, ship.TeamCount, ship.PortId, ship.CaptainId, ship.Id );
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
                cmd.CommandText = String.Format("delete from Ship where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(BaseEntity entity)
        {
            if (!(entity is Ship)) { return; }
            var ship = (Ship)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Ship where Id = {0};", ship.Id);
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
                cmd.CommandText = "select Id, Number, Capacity, CreateDate, MaxDistance, TeamCount, PortId, CaptainId from Ship;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Ship((int)dr[0], dr[1].ToString(), (int)dr[2], (DateTime)dr[3], (int)(int)dr[4], (int)dr[5], (int)dr[6], (int)dr[7]));
                    }
                }
            }
            return retList;
        }
    }
}
