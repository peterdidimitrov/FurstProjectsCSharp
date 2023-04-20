using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace VehicleGarage.Tests
{
    public class Tests
    {

        private List<Vehicle> vehicles;

        [SetUp]
        public void Setup()
        {
    
            vehicles = new List<Vehicle>();

        }

        [Test]
        public void GarageConstructorShouldWork()
        {
            Garage garage = new Garage(5);

            Assert.That(garage.Capacity, Is.EqualTo(5));
            
        }

        [Test]
        public void VehicleConstructorShouldWorks()
        {
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);

            Assert.That(vehicle.Brand, Is.EqualTo("Tesla"));
            Assert.That(vehicle.Model, Is.EqualTo("Y"));
            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo("PB9999XX"));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle.IsDamaged, Is.EqualTo(false));

        }

        [Test]
        public void AddVehicleMethodShouldWork()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);

            Assert.That(garage.AddVehicle(vehicle), Is.EqualTo(true));

            garage.AddVehicle(vehicle);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
         
        }

        [Test]
        public void AddVehicleMethodShouldReturnFalse()
        {
            Garage garage = new Garage(0);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);

            Assert.That(garage.AddVehicle(vehicle), Is.EqualTo(false));

            garage.AddVehicle(vehicle);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));

        }

        [Test]
        public void AddVehicleMethodShouldReturnFalseWhenAlreadyAddedCar()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);

            Assert.That(garage.AddVehicle(vehicle), Is.EqualTo(true));

            garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));

            Assert.That(garage.AddVehicle(vehicle), Is.EqualTo(false));

        }


        [Test]
        public void DriveVehicleMethodShoudWork()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);
            garage.AddVehicle(vehicle);

            Assert.That(vehicle.IsDamaged, Is.EqualTo(false));

            garage.DriveVehicle("PB9999XX", 30, true);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(70));
            Assert.That(vehicle.IsDamaged, Is.EqualTo(true));

            Assert.Throws<NullReferenceException>(
                ()=>garage.DriveVehicle("PB8888XX", 30, true), "Object reference not set to an instance of an object.");
        }

        [Test]
        public void DriveVehicleMethodTestInvalidInputs()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 300);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("PB9999XX",110, true);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));

            garage.DriveVehicle("PB9999XX", 60, true);
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(40));
           
            garage.DriveVehicle("PB9999XX", 60, true);
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(40));

        }

        [Test]
        public void ChargeVehiclesMethodShouldWork()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 100.0);
            garage.AddVehicle(vehicle);

            Vehicle vehicle2 = new Vehicle("Golf", "5", "EA8888EA", 100.0);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("PB9999XX", 70, false);
            garage.DriveVehicle("EA8888EA", 70, false);

            int expectedValue = garage.ChargeVehicles(30);
            
            Assert.That(expectedValue, Is.EqualTo(2));

            garage.DriveVehicle("PB9999XX", 50, false);
            garage.DriveVehicle("EA8888EA", 70, false);
            expectedValue = garage.ChargeVehicles(30);

            Assert.That(expectedValue, Is.EqualTo(1));
            expectedValue = garage.ChargeVehicles(30);
            Assert.That(expectedValue, Is.EqualTo(0));

        }


        [Test]
        public void RepairVehiclesMethodShouldWork()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle = new Vehicle("Tesla", "Y", "PB9999XX", 100.0);
            garage.AddVehicle(vehicle);

            Vehicle vehicle2 = new Vehicle("Golf", "5", "EA8888EA", 100.0);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("PB9999XX", 70, true);
            garage.DriveVehicle("EA8888EA", 70, true);
                     
            Assert.That(garage.RepairVehicles(), Is.EqualTo("Vehicles repaired: 2"));

            garage.DriveVehicle("PB9999XX", 30, true);
            Assert.That(garage.RepairVehicles(), Is.EqualTo("Vehicles repaired: 1"));

            Assert.That(garage.RepairVehicles(), Is.EqualTo("Vehicles repaired: 0"));
        }

    }

}