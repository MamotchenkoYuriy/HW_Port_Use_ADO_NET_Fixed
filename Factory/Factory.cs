using Factory.Implements;
using Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables;

namespace Factory
{
    public class Factory
    {
        string connectionString = string.Empty;
        string provider = string.Empty;
        static Factory factory = null;
        CityDAO cityDAO = null;
        PortDAO portDAO = null;
        TripDAO tripDAO = null;
        ShipDAO shipDAO = null;
        CargoTypeDAO cargoTypeDAO = null;
        CargoDAO cargoDAO = null;
        CaptainDAO captainDAO = null;


        private Factory()
        {
            var builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "YURIY-PC";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "PortDB";
            connectionString = builder.ConnectionString;
            provider = "System.Data.SqlClient";
        }

        public static Factory getInstanse()
        {
            if (factory != null)
            {
                return factory;
            }
            else
            {
                factory = new Factory();
                return factory;
            }
        }

        public IDAO getDAO<T>()
        {
            if (typeof(T) == typeof(City))
            {
                return getCityDAO();
            }
            else if (typeof(T) == typeof(Port))
            {
                return getPortDAO();
            }
            else if (typeof(T) == typeof(Trip))
            {
                return getTripDAO();
            }
            else if (typeof(T) == typeof(Ship))
            {
                return getShipDAO();
            }
            else if (typeof(T) == typeof(CargoType))
            {
                return getCargoTypeDAO();
            }
            else if (typeof(T) == typeof(Cargo))
            {
                return getCargoDAO();
            }
            else if (typeof(T) == typeof(Captain))
            {
                return getCaptainDAO();
            }
            return null;
        }










        public CityDAO getCityDAO()
        {
            if (cityDAO != null) { return cityDAO; }
            else
            {
                cityDAO = new CityDAO(connectionString, provider);
                return cityDAO;
            }
        }
        public PortDAO getPortDAO()
        {
            if (cityDAO != null) { return portDAO; }
            else
            {
                portDAO = new PortDAO(connectionString, provider);
                return portDAO;
            }
        }


        public TripDAO getTripDAO()
        {
            if (tripDAO != null) { return tripDAO; }
            else
            {
                tripDAO = new TripDAO(connectionString, provider);
                return tripDAO;
            }
        }

        public ShipDAO getShipDAO()
        {
            if (shipDAO != null) { return shipDAO; }
            else
            {
                shipDAO = new ShipDAO(connectionString, provider);
                return shipDAO;
            }
        }

        public CargoTypeDAO getCargoTypeDAO()
        {
            if (cargoTypeDAO != null) { return cargoTypeDAO; }
            else
            {
                cargoTypeDAO = new CargoTypeDAO(connectionString, provider);
                return cargoTypeDAO;
            }
        }


        public CargoDAO getCargoDAO()
        {
            if (cargoDAO != null) { return cargoDAO; }
            else
            {
                cargoDAO = new CargoDAO(connectionString, provider);
                return cargoDAO;
            }
        }


        public CaptainDAO getCaptainDAO()
        {
            if (captainDAO != null) { return captainDAO; }
            else
            {
                captainDAO = new CaptainDAO(connectionString, provider);
                return captainDAO;
            }
        }

    }
}
