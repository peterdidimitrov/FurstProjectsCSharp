﻿using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private const int SuccessExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(SuccessExitCode);
            return null;
        }
    }
}
