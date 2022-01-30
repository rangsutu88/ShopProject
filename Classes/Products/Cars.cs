using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ShopProject.DatabaseConnections;

namespace ShopProject.Classes.Products
{
    class Cars
    {
        private int ProductID, SeatingCapacity, NumberOfCarsAvailable, UnitPrice;
        private string ProductName, Engine, Color, NumberOfCylinders;
        private float DistanceCovered, ChargingTime, TopSpeed, Acceleration, CapacityOfTheMotor, TotalPrice;

        public Cars()
        {
        }
        public Cars(int ID, int seatingcapacity, int numberofcarsavailable, int unitprice, string productname, string engine,
            string color, string numberofcylinders, float distancecovered, float chargingtime, float topspeed,
            float acceleration, float capacityofthemotor)
        {
            this.ProductID = ID;
            this.SeatingCapacity = seatingcapacity;
            this.NumberOfCarsAvailable = numberofcarsavailable;
            this.UnitPrice = unitprice;
            this.ProductName = productname;
            this.Engine = engine;
            this.Color = color;
            this.NumberOfCylinders = numberofcylinders;
            this.DistanceCovered = distancecovered;
            this.ChargingTime = chargingtime;
            this.TopSpeed = topspeed;
            this.Acceleration = acceleration;
            this.CapacityOfTheMotor = capacityofthemotor;
        }
        public static Cars Getproduct(int id)
        {
            SqlConnection connection = OpenDatabaseConnection.GetConnection();
            try
            {
                connection.Open();
                string selectquery = "SELECT Name, Engine, [Top speed], [Acceleration 0-60mph]," +
                        " Numberofcars, UnitPrice" + " FROM [dbo].[Products] " + "WHERE CarID=@a";
                SqlCommand selectCommand = new SqlCommand(selectquery, connection);
                selectCommand.Parameters.AddWithValue("@a", id);
                SqlDataReader ProductReader = selectCommand.ExecuteReader();
                Cars p = new Cars();
                while (ProductReader.Read())
                {
                    p.productName = ProductReader["Name"].ToString();
                    p.engine = ProductReader["Engine"].ToString();
                    p.topSpeed = Convert.ToInt32(ProductReader["Top speed"]);
                    p.acceleration = Convert.ToInt32(ProductReader["Acceleration 0-60mph"]);
                    p.numberOfCarsAvailable = (int)ProductReader["Numberofcars"];
                    p.unitPrice = (int)ProductReader["UnitPrice"];
                }
                ProductReader.Close();
                return p;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally { connection.Close(); }
        }
        public string productName
        {
            get { return ProductName; }
            set { if (productName != null) ProductName = value; }
        }

        public int productID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }

        public string engine
        {
            get { return Engine; }
            set { Engine = value; }
        }

        public string color
        {
            get { return Color; }
            set { Color = value; }
        }

        public string numberOfCylinders
        {
            get { return NumberOfCylinders; }
            set { NumberOfCylinders = value; }
        }

        public float distanceCovered
        {
            get { return DistanceCovered; }
            set { DistanceCovered = value; }
        }

        public float chargingTime
        {
            get { return ChargingTime; }
            set { ChargingTime = value; }
        }

        public float topSpeed
        {
            get { return TopSpeed; }
            set { TopSpeed = value; }
        }

        public float acceleration
        {
            get { return Acceleration; }
            set { Acceleration = value; }
        }

        public int seatingCapacity
        {
            get { return SeatingCapacity; }
            set { SeatingCapacity = value; }
        }

        public float capacityOfTheMotor
        {
            get { return CapacityOfTheMotor; }
            set { CapacityOfTheMotor = value; }
        }

        public int numberOfCarsAvailable
        {
            get { return NumberOfCarsAvailable; }
            set { NumberOfCarsAvailable = value; }
        }

        public int unitPrice
        {
            get { return UnitPrice; }
            set { UnitPrice = value; }
        }

        public float totalPrice
        {
            get { return TotalPrice; }
            set { TotalPrice = value; }
        }
    }
}