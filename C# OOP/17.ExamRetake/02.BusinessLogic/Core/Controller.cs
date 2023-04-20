using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            IUser user = new User(firstName, lastName, drivingLicenseNumber);

            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle;

            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if ((routes.GetAll().FirstOrDefault(s => s.StartPoint == startPoint) != null) &&
                 (routes.GetAll().FirstOrDefault(e => e.EndPoint == endPoint) != null) &&
                  (routes.GetAll().FirstOrDefault(l => l.Length == length) != null))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            if ((routes.GetAll().FirstOrDefault(s => s.StartPoint == startPoint) != null) &&
                 (routes.GetAll().FirstOrDefault(e => e.EndPoint == endPoint) != null) &&
                  (routes.GetAll().FirstOrDefault(l => l.Length < length) != null))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            if ((routes.GetAll().FirstOrDefault(s => s.StartPoint == startPoint) != null) &&
                 (routes.GetAll().FirstOrDefault(e => e.EndPoint == endPoint) != null) &&
                  (routes.GetAll().FirstOrDefault(l => l.Length > length) != null))
            {
                IRoute routeToLock = routes.GetAll()
                    .FirstOrDefault(s=> s.StartPoint == startPoint && s.EndPoint ==endPoint && s.Length > length && s.IsLocked == false);

                routeToLock.LockRoute();
            }

            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(route);
            

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if (user.IsBlocked == true)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if (vehicle.IsDamaged == true)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            if (route.IsLocked == true)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }


        public string RepairVehicles(int count)
        {
            var damagedVehicles = vehicles.GetAll()
                .Where(x => x.IsDamaged == true)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .Take(count)
                .ToList();


            foreach (var vehicle in damagedVehicles)
            {
            
                    vehicle.ChangeStatus();
                    vehicle.Recharge();
                             
            }

            return string.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
        }


        public string UsersReport()
        {
            StringBuilder sb = new();

            sb.AppendLine("*** E-Drive-Rent ***");

            var orderedUsers = users.GetAll()
                .OrderByDescending(x=> x.Rating)
                .ThenBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .ToList();

            foreach (var user in orderedUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
