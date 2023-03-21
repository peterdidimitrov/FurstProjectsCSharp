using CommandPattern.Common;
using CommandPattern.Core.Contracts;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.Split();
            string cmdName = cmdSplit[0];
            string[] cmdArg = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new InvalidOperationException(String.Format(ErrorMessages.InvalidCommandType, $"{cmdName}"));
            }

            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First(m => m.Name == "Execute");

            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArg });

            return result;
        }
    }
}
