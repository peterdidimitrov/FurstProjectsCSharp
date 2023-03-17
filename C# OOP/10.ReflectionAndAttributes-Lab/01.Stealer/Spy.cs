
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fieldsNames)
        {
            Type classType = Type.GetType(nameOfClass);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder srtingBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new Object[] { });

            srtingBuilder.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var field in fields.Where(f => fieldsNames.Contains(f.Name)))
            {
                srtingBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return srtingBuilder.ToString().Trim();
        }
    }
}