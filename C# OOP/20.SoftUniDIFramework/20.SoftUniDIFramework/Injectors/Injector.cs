﻿using SoftUniDIFramework.Attributes;
using SoftUniDIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDIFramework.Injectors
{
    public class Injector
    {
        private IModule module;
        public Injector(IModule module)
        {
            this.module = module;
        }
        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62).Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            if (desireClass == null)
            {
                return default(TClass);
            }
            var constructors = desireClass.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttribute(typeof(Named));
                    var inject = parameterType.GetCustomAttribute(typeof(Inject));
                    Type dependency = null;
                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterType.ParameterType, named);
                    }
                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                    return (TClass)Activator.CreateInstance(desireClass, constructorParams);
                }
            }
            return default(TClass);
        }
        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
            }

            var fields = desireClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    var named = field.GetCustomAttribute(typeof(Named), true);

                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }
                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }
        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }
            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }
    }
}
