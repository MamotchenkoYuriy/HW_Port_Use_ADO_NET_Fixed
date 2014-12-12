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
    public class TripDAO:IDAO
    {
        readonly string connectionString = string.Empty;
        string provider = string.Empty;
        readonly DbProviderFactory dbProviderFactory = null;

        private TripDAO() { }

        public TripDAO(string connectionString, string provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
            dbProviderFactory = DbProviderFactories.GetFactory(provider);
        }


        public void Add(BaseEntity entity)
        {
            if (!(entity is Trip)) { return; }
            var trip = (Trip)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("insert into Trip(ShipId, StartDate, EndDate, PortFromId, PortToId)"
                    + " values ({0}, '{1}', '{2}', {3}, {4});", trip.ShipId, trip.StartDate, trip.EndDate, trip.PortFromId, trip.PortToId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BaseEntity entity)
        {
            if (!(entity is Trip)) { return; }
            var trip = (Trip)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("update Trip set ShipId = {0}, StartDate = '{1}', EndDate = '{2}', PortFromId = {3}, PortToId = {4} where Id = {5};", trip.ShipId, trip.StartDate, trip.EndDate, trip.PortFromId, trip.PortToId, trip.Id);
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
                cmd.CommandText = String.Format("delete from Trip where Id = {0};", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(BaseEntity entity)
        {
            if (!(entity is Trip)) { return; }
            var trip = (Trip)entity;
            using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                DbCommand cmd = dbProviderFactory.CreateCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = String.Format("delete from Trip where Id = {0};", trip.Id);
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
                cmd.CommandText = "Select Id, ShipId, StartDate, EndDate, PortFromId, PortToId from Trip;";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retList.Add(new Trip((int)dr[0], (int)dr[1], (DateTime)dr[2], (DateTime)dr[3], (int)dr[4], (int)dr[5]));
                    }
                }
            }
            return retList;
        }
    }
}
