using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternEx2
{
    public interface IDataAccess
    {

        List<Product> LoadData();
        void SaveData();
    }
    public class DataAccess : IDataAccess
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product() { Name = "Jordans", Price = 500},
            new Product() { Name = "Lamp", Price = 200},
            new Product() { Name ="Ceiling fan", Price = 100},
        };
        
        public new List<Product> LoadData()
        {
            Console.WriteLine("I am reading data from DataAccess");
            return Products;
        }
        public new void SaveData()
        {
            Console.WriteLine("I am saving data to the DataBase");
        }
    }
    public class SQLDataAccess : IDataAccess
    {
        public static List<Product> SqlProd  = new List<Product>()
        {
            new Product() { Name = "Microphone", Price = 342},
            new Product() { Name = "greasepan", Price = 1},
            new Product() { Name ="Tesla Car", Price = 40},
        };
        public new List<Product> LoadData()
        {
            Console.WriteLine("I am reading data from SQL");
            return SqlProd;
        }
        public new void SaveData()
        {
            Console.WriteLine("I am saving data to the SQL database");

        }
    }
    public class MongoDataAccess : IDataAccess
    {
        public static List<Product> MgoProd = new List<Product>()
        {
            new Product() { Name = "Cat toy", Price = 65},
            new Product() { Name = "wrench", Price = 12},
            new Product() { Name ="piano key", Price = 22},
        };
        public List<Product> LoadData()
        {
            Console.WriteLine("I am reading data from Mongo");
            return MgoProd;
        }
        public void SaveData()
        {
            Console.WriteLine("I am saving data to the Mongo Database");
        }

    }
    public static class DataFactory 
    {
        public static IDataAccess GetDataAccessType(string DataBaseType)
        {
            switch (DataBaseType.ToLower())
            {
                case "sql":
                    return new SQLDataAccess();
                case "list":
                    return new DataAccess();
                case "mongo":
                    return new MongoDataAccess();
                default:
                    return new DataAccess();
            }
        }
    }
}
