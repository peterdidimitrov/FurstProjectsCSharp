using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public int ChildrenCount => this.Registry.Count;

        public bool AddChild(Child child)
        {
            if (Capacity == Registry.Count)
            {
                return false;
            }
            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] array = childFullName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstNme = array[0];
            string lastNme = array[1];

            var targetChild = this.Registry
                .FirstOrDefault(x => x.FirstName == firstNme && x.LastName == lastNme);
            if (targetChild == null)
            {
                return false;
            }
            this.Registry.Remove(targetChild);
            return true;
        }
        public Child GetChild(string childFullName)
        {
            string[] array = childFullName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstNme = array[0];
            string lastNme = array[1];

            var targetChild = this.Registry
                .FirstOrDefault(x => x.FirstName == firstNme && x.LastName == lastNme);
            if (targetChild == null)
            {
                return null;
            }
            return targetChild;
        }
        public string RegistryReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in this.Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
