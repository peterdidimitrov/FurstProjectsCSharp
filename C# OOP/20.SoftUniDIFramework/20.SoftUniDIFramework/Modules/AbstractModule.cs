using SoftUniDIFramework.Attributes;
using SoftUniDIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }
        public abstract void Configure();
        protected void CreateMapping<TInter, TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
            {
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }
            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentInplementation = this.implementations[currentInterface];

            Type type = null;
            if (attribute is Inject)
            {
                if (currentInplementation.Count == 1)
                {
                    type = currentInplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInplementation}");
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;
                string dependencyName = named.Name;
                type = currentInplementation[dependencyName];
            }
            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }
    }
}
