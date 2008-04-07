using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;

namespace Skorer.IOC
{
    public static class Container
    {
        public static T Resolve<T>()
        {
            return _Container.Resolve<T>();
        }

        public static T Resolve<T>(string key)
        {
            return _Container.Resolve<T>(key);
        }

        public static T Resolve<T>(IDictionary arguments)
        {
            return _Container.Resolve<T>(arguments);
        }

        public static T Resolve<T>(string key, IDictionary arguments)
        {
            return _Container.Resolve<T>(key, arguments);
        }

        private static WindsorContainer _Container;

        static Container()
        { _Initialize(); }

        private static void _Initialize()
        {
            _Container = _Load(
                String.Format(
                    "assembly://{0}/Windsor.config",
                    typeof(Container).Assembly.GetName().Name));
        }

        private static WindsorContainer _Load(string configFile)
        {
            return new WindsorContainer(
                new XmlInterpreter(
                    new AssemblyResourceFactory().Create(
                        new CustomUri(configFile))));
        }
    }
}
