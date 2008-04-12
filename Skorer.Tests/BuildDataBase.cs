using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Skorer.Tests
{
    [TestFixture]
    public class BuildDataBase
    {
        [Test]
        public void BuildDataBaseTest()
        {
            Configuration cfg = new NHibernate.Cfg.Configuration();
            SchemaExport exporter = new SchemaExport(cfg.Configure());
            exporter.Create(true, true);
            exporter.Execute(false, true, false, true);
        }
    }
}
