﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopProject.DatabaseConnections
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Project1Database")]
	public partial class LINQToSQLClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAddress(Address instance);
    partial void UpdateAddress(Address instance);
    partial void DeleteAddress(Address instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertOrder_Detail(Order_Detail instance);
    partial void UpdateOrder_Detail(Order_Detail instance);
    partial void DeleteOrder_Detail(Order_Detail instance);
    partial void InsertOrder(Order instance);
    partial void UpdateOrder(Order instance);
    partial void DeleteOrder(Order instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public LINQToSQLClassDataContext() : 
				base(global::ShopProject.Properties.Settings.Default.Project1DatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Address> Addresses
		{
			get
			{
				return this.GetTable<Address>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Order_Detail> Order_Details
		{
			get
			{
				return this.GetTable<Order_Detail>();
			}
		}
		
		public System.Data.Linq.Table<Order> Orders
		{
			get
			{
				return this.GetTable<Order>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Address")]
	public partial class Address : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AddressID;
		
		private string _Country;
		
		private string _City;
		
		private EntitySet<User> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAddressIDChanging(int value);
    partial void OnAddressIDChanged();
    partial void OnCountryChanging(string value);
    partial void OnCountryChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    #endregion
		
		public Address()
		{
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int AddressID
		{
			get
			{
				return this._AddressID;
			}
			set
			{
				if ((this._AddressID != value))
				{
					this.OnAddressIDChanging(value);
					this.SendPropertyChanging();
					this._AddressID = value;
					this.SendPropertyChanged("AddressID");
					this.OnAddressIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				if ((this._Country != value))
				{
					this.OnCountryChanging(value);
					this.SendPropertyChanging();
					this._Country = value;
					this.SendPropertyChanged("Country");
					this.OnCountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Address_User", Storage="_Users", ThisKey="AddressID", OtherKey="AddressID")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Address = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Address = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private int _Age;
		
		private int _Passcode;
		
		private int _AddressID;
		
		private System.Nullable<decimal> _BalanceInDollars;
		
		private EntitySet<Order> _Orders;
		
		private EntityRef<Address> _Address;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnAgeChanging(int value);
    partial void OnAgeChanged();
    partial void OnPasscodeChanging(int value);
    partial void OnPasscodeChanged();
    partial void OnAddressIDChanging(int value);
    partial void OnAddressIDChanged();
    partial void OnBalanceInDollarsChanging(System.Nullable<decimal> value);
    partial void OnBalanceInDollarsChanged();
    #endregion
		
		public User()
		{
			this._Orders = new EntitySet<Order>(new Action<Order>(this.attach_Orders), new Action<Order>(this.detach_Orders));
			this._Address = default(EntityRef<Address>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Passcode", DbType="Int NOT NULL")]
		public int Passcode
		{
			get
			{
				return this._Passcode;
			}
			set
			{
				if ((this._Passcode != value))
				{
					this.OnPasscodeChanging(value);
					this.SendPropertyChanging();
					this._Passcode = value;
					this.SendPropertyChanged("Passcode");
					this.OnPasscodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressID", DbType="Int NOT NULL")]
		public int AddressID
		{
			get
			{
				return this._AddressID;
			}
			set
			{
				if ((this._AddressID != value))
				{
					if (this._Address.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAddressIDChanging(value);
					this.SendPropertyChanging();
					this._AddressID = value;
					this.SendPropertyChanged("AddressID");
					this.OnAddressIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BalanceInDollars", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> BalanceInDollars
		{
			get
			{
				return this._BalanceInDollars;
			}
			set
			{
				if ((this._BalanceInDollars != value))
				{
					this.OnBalanceInDollarsChanging(value);
					this.SendPropertyChanging();
					this._BalanceInDollars = value;
					this.SendPropertyChanged("BalanceInDollars");
					this.OnBalanceInDollarsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Order", Storage="_Orders", ThisKey="ID", OtherKey="CustomerID")]
		public EntitySet<Order> Orders
		{
			get
			{
				return this._Orders;
			}
			set
			{
				this._Orders.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Address_User", Storage="_Address", ThisKey="AddressID", OtherKey="AddressID", IsForeignKey=true)]
		public Address Address
		{
			get
			{
				return this._Address.Entity;
			}
			set
			{
				Address previousValue = this._Address.Entity;
				if (((previousValue != value) 
							|| (this._Address.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Address.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Address.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._AddressID = value.AddressID;
					}
					else
					{
						this._AddressID = default(int);
					}
					this.SendPropertyChanged("Address");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Order Details]")]
	public partial class Order_Detail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _OrderID;
		
		private int _ProductID;
		
		private int _Quantity;
		
		private double _Price;
		
		private EntityRef<Order> _Order;
		
		private EntityRef<Product> _Product;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnOrderIDChanging(int value);
    partial void OnOrderIDChanged();
    partial void OnProductIDChanging(int value);
    partial void OnProductIDChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnPriceChanging(double value);
    partial void OnPriceChanged();
    #endregion
		
		public Order_Detail()
		{
			this._Order = default(EntityRef<Order>);
			this._Product = default(EntityRef<Product>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", DbType="Int NOT NULL")]
		public int OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOrderIDChanging(value);
					this.SendPropertyChanging();
					this._OrderID = value;
					this.SendPropertyChanged("OrderID");
					this.OnOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					if (this._Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProductIDChanging(value);
					this.SendPropertyChanging();
					this._ProductID = value;
					this.SendPropertyChanged("ProductID");
					this.OnProductIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float NOT NULL")]
		public double Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Order_Detail", Storage="_Order", ThisKey="OrderID", OtherKey="OrderID", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.Order_Details.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.Order_Details.Add(this);
						this._OrderID = value.OrderID;
					}
					else
					{
						this._OrderID = default(int);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Order_Detail", Storage="_Product", ThisKey="ProductID", OtherKey="CarID", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.Order_Details.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.Order_Details.Add(this);
						this._ProductID = value.CarID;
					}
					else
					{
						this._ProductID = default(int);
					}
					this.SendPropertyChanged("Product");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Orders")]
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OrderID;
		
		private int _CustomerID;
		
		private System.DateTime _BoughtDate;
		
		private System.Nullable<int> _Total_number_of_products_bought;
		
		private System.Nullable<double> _Total_Price;
		
		private EntitySet<Order_Detail> _Order_Details;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIDChanging(int value);
    partial void OnOrderIDChanged();
    partial void OnCustomerIDChanging(int value);
    partial void OnCustomerIDChanged();
    partial void OnBoughtDateChanging(System.DateTime value);
    partial void OnBoughtDateChanged();
    partial void OnTotal_number_of_products_boughtChanging(System.Nullable<int> value);
    partial void OnTotal_number_of_products_boughtChanged();
    partial void OnTotal_PriceChanging(System.Nullable<double> value);
    partial void OnTotal_PriceChanged();
    #endregion
		
		public Order()
		{
			this._Order_Details = new EntitySet<Order_Detail>(new Action<Order_Detail>(this.attach_Order_Details), new Action<Order_Detail>(this.detach_Order_Details));
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					this.OnOrderIDChanging(value);
					this.SendPropertyChanging();
					this._OrderID = value;
					this.SendPropertyChanged("OrderID");
					this.OnOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL")]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoughtDate", DbType="SmallDateTime NOT NULL")]
		public System.DateTime BoughtDate
		{
			get
			{
				return this._BoughtDate;
			}
			set
			{
				if ((this._BoughtDate != value))
				{
					this.OnBoughtDateChanging(value);
					this.SendPropertyChanging();
					this._BoughtDate = value;
					this.SendPropertyChanged("BoughtDate");
					this.OnBoughtDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Total number of products bought]", Storage="_Total_number_of_products_bought", DbType="Int")]
		public System.Nullable<int> Total_number_of_products_bought
		{
			get
			{
				return this._Total_number_of_products_bought;
			}
			set
			{
				if ((this._Total_number_of_products_bought != value))
				{
					this.OnTotal_number_of_products_boughtChanging(value);
					this.SendPropertyChanging();
					this._Total_number_of_products_bought = value;
					this.SendPropertyChanged("Total_number_of_products_bought");
					this.OnTotal_number_of_products_boughtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Total Price]", Storage="_Total_Price", DbType="Float")]
		public System.Nullable<double> Total_Price
		{
			get
			{
				return this._Total_Price;
			}
			set
			{
				if ((this._Total_Price != value))
				{
					this.OnTotal_PriceChanging(value);
					this.SendPropertyChanging();
					this._Total_Price = value;
					this.SendPropertyChanged("Total_Price");
					this.OnTotal_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Order_Detail", Storage="_Order_Details", ThisKey="OrderID", OtherKey="OrderID")]
		public EntitySet<Order_Detail> Order_Details
		{
			get
			{
				return this._Order_Details;
			}
			set
			{
				this._Order_Details.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Order", Storage="_User", ThisKey="CustomerID", OtherKey="ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Orders.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Orders.Add(this);
						this._CustomerID = value.ID;
					}
					else
					{
						this._CustomerID = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Order_Details(Order_Detail entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_Order_Details(Order_Detail entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Products")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CarID;
		
		private string _Name;
		
		private string _Engine;
		
		private string _Color;
		
		private System.Nullable<int> _Number_of_cylinders;
		
		private System.Nullable<decimal> _Distance_covered;
		
		private System.Nullable<int> _Charging_time;
		
		private decimal _Top_speed;
		
		private decimal _Acceleration_0_60mph;
		
		private int _Seating_Capacity;
		
		private string _Capacity_of_the_motor;
		
		private System.Nullable<int> _Numberofcars;
		
		private int _UnitPrice;
		
		private EntitySet<Order_Detail> _Order_Details;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCarIDChanging(int value);
    partial void OnCarIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEngineChanging(string value);
    partial void OnEngineChanged();
    partial void OnColorChanging(string value);
    partial void OnColorChanged();
    partial void OnNumber_of_cylindersChanging(System.Nullable<int> value);
    partial void OnNumber_of_cylindersChanged();
    partial void OnDistance_coveredChanging(System.Nullable<decimal> value);
    partial void OnDistance_coveredChanged();
    partial void OnCharging_timeChanging(System.Nullable<int> value);
    partial void OnCharging_timeChanged();
    partial void OnTop_speedChanging(decimal value);
    partial void OnTop_speedChanged();
    partial void OnAcceleration_0_60mphChanging(decimal value);
    partial void OnAcceleration_0_60mphChanged();
    partial void OnSeating_CapacityChanging(int value);
    partial void OnSeating_CapacityChanged();
    partial void OnCapacity_of_the_motorChanging(string value);
    partial void OnCapacity_of_the_motorChanged();
    partial void OnNumberofcarsChanging(System.Nullable<int> value);
    partial void OnNumberofcarsChanged();
    partial void OnUnitPriceChanging(int value);
    partial void OnUnitPriceChanged();
    #endregion
		
		public Product()
		{
			this._Order_Details = new EntitySet<Order_Detail>(new Action<Order_Detail>(this.attach_Order_Details), new Action<Order_Detail>(this.detach_Order_Details));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CarID
		{
			get
			{
				return this._CarID;
			}
			set
			{
				if ((this._CarID != value))
				{
					this.OnCarIDChanging(value);
					this.SendPropertyChanging();
					this._CarID = value;
					this.SendPropertyChanged("CarID");
					this.OnCarIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Engine", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Engine
		{
			get
			{
				return this._Engine;
			}
			set
			{
				if ((this._Engine != value))
				{
					this.OnEngineChanging(value);
					this.SendPropertyChanging();
					this._Engine = value;
					this.SendPropertyChanged("Engine");
					this.OnEngineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._Color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Number of cylinders]", Storage="_Number_of_cylinders", DbType="Int")]
		public System.Nullable<int> Number_of_cylinders
		{
			get
			{
				return this._Number_of_cylinders;
			}
			set
			{
				if ((this._Number_of_cylinders != value))
				{
					this.OnNumber_of_cylindersChanging(value);
					this.SendPropertyChanging();
					this._Number_of_cylinders = value;
					this.SendPropertyChanged("Number_of_cylinders");
					this.OnNumber_of_cylindersChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Distance covered]", Storage="_Distance_covered", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Distance_covered
		{
			get
			{
				return this._Distance_covered;
			}
			set
			{
				if ((this._Distance_covered != value))
				{
					this.OnDistance_coveredChanging(value);
					this.SendPropertyChanging();
					this._Distance_covered = value;
					this.SendPropertyChanged("Distance_covered");
					this.OnDistance_coveredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Charging time]", Storage="_Charging_time", DbType="Int")]
		public System.Nullable<int> Charging_time
		{
			get
			{
				return this._Charging_time;
			}
			set
			{
				if ((this._Charging_time != value))
				{
					this.OnCharging_timeChanging(value);
					this.SendPropertyChanging();
					this._Charging_time = value;
					this.SendPropertyChanged("Charging_time");
					this.OnCharging_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Top speed]", Storage="_Top_speed", DbType="Decimal(18,4) NOT NULL")]
		public decimal Top_speed
		{
			get
			{
				return this._Top_speed;
			}
			set
			{
				if ((this._Top_speed != value))
				{
					this.OnTop_speedChanging(value);
					this.SendPropertyChanging();
					this._Top_speed = value;
					this.SendPropertyChanged("Top_speed");
					this.OnTop_speedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Acceleration 0-60mph]", Storage="_Acceleration_0_60mph", DbType="Decimal(18,4) NOT NULL")]
		public decimal Acceleration_0_60mph
		{
			get
			{
				return this._Acceleration_0_60mph;
			}
			set
			{
				if ((this._Acceleration_0_60mph != value))
				{
					this.OnAcceleration_0_60mphChanging(value);
					this.SendPropertyChanging();
					this._Acceleration_0_60mph = value;
					this.SendPropertyChanged("Acceleration_0_60mph");
					this.OnAcceleration_0_60mphChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Seating Capacity]", Storage="_Seating_Capacity", DbType="Int NOT NULL")]
		public int Seating_Capacity
		{
			get
			{
				return this._Seating_Capacity;
			}
			set
			{
				if ((this._Seating_Capacity != value))
				{
					this.OnSeating_CapacityChanging(value);
					this.SendPropertyChanging();
					this._Seating_Capacity = value;
					this.SendPropertyChanged("Seating_Capacity");
					this.OnSeating_CapacityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Capacity of the motor]", Storage="_Capacity_of_the_motor", DbType="NChar(10)")]
		public string Capacity_of_the_motor
		{
			get
			{
				return this._Capacity_of_the_motor;
			}
			set
			{
				if ((this._Capacity_of_the_motor != value))
				{
					this.OnCapacity_of_the_motorChanging(value);
					this.SendPropertyChanging();
					this._Capacity_of_the_motor = value;
					this.SendPropertyChanged("Capacity_of_the_motor");
					this.OnCapacity_of_the_motorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Numberofcars", DbType="Int")]
		public System.Nullable<int> Numberofcars
		{
			get
			{
				return this._Numberofcars;
			}
			set
			{
				if ((this._Numberofcars != value))
				{
					this.OnNumberofcarsChanging(value);
					this.SendPropertyChanging();
					this._Numberofcars = value;
					this.SendPropertyChanged("Numberofcars");
					this.OnNumberofcarsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitPrice", DbType="Int NOT NULL")]
		public int UnitPrice
		{
			get
			{
				return this._UnitPrice;
			}
			set
			{
				if ((this._UnitPrice != value))
				{
					this.OnUnitPriceChanging(value);
					this.SendPropertyChanging();
					this._UnitPrice = value;
					this.SendPropertyChanged("UnitPrice");
					this.OnUnitPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Order_Detail", Storage="_Order_Details", ThisKey="CarID", OtherKey="ProductID")]
		public EntitySet<Order_Detail> Order_Details
		{
			get
			{
				return this._Order_Details;
			}
			set
			{
				this._Order_Details.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Order_Details(Order_Detail entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_Order_Details(Order_Detail entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
}
#pragma warning restore 1591
