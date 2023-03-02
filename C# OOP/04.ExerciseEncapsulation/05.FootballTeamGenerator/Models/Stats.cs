﻿namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int Endurance 
        { 
            get => endurance; 
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(value)} should be between 0 and 100.");
                }
                endurance = value;
            } 
        }
        public int Sprint 
        {
            get => sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(value)} should be between 0 and 100.");
                }
                sprint = value;
            } 
        }
        public int Dribble 
        { 
            get => dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(value)} should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        public int Passing 
        { 
            get => passing; 
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(value)} should be between 0 and 100.");
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(value)} should be between 0 and 100.");
                }
                shooting = value;
            }
        }
    }
}