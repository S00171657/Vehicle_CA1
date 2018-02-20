using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Desc { get; set; }
        public double Engine { get; set; }
    }
    class Car : Vehicle
    {
        #region Constructors
        public Car()
        {

        }
        public Car(string make, string model, double price, int year, int mileage, string desc, double engine)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Mileage = mileage;
            Desc = desc;
            Engine = engine;
        }
        #endregion
    }
    class Bike : Vehicle
    {
        #region Constructors
        public Bike()
        {

        }
        public Bike(string make, string model, double price, int year, int mileage, string desc, double engine)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Mileage = mileage;
            Desc = desc;
            Engine = engine;
        }
        #endregion
    }
    class Van : Vehicle
    {
        #region Constructors
        public Van()
        {

        }
        public Van(string make, string model, double price, int year, int mileage, string desc, double engine)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Mileage = mileage;
            Desc = desc;
            Engine = engine;
        }
        #endregion
    }
}
