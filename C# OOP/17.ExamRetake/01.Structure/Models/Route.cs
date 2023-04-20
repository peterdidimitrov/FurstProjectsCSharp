﻿using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint; 
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;

            IsLocked = false;
        }
        private string startPoint;
        public string StartPoint
        {
            get { return startPoint; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                startPoint = value;
            }
        }
        private string endPoint;
        public string EndPoint
        {
            get { return endPoint; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                endPoint = value;
            }
        }
        private double length;
        public double Length
        {
            get { return length; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                length = value;
            }
        }

        private int routeId;
        public int RouteId { get => routeId; private set
            {
                routeId = value;
            }
        }

        public bool IsLocked { get; private set; }

        public void LockRoute()
        {
            IsLocked = true;
        }
    }
}
