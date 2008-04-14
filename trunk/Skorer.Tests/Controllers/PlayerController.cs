using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Skorer.Web.Controllers;
using Skorer.DataAccess;
using Moq;
using Skorer.Core;
using Castle.MonoRail.Framework.Test;
using Castle.MonoRail.Framework;

namespace Skorer.Tests.Controllers
{
    [TestFixture]
    public class PlayerControllerTests
    {
        PlayerController _Controller;
        Mock<IRepository<Player, int>> _RepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _RepositoryMock = new Mock<IRepository<Player,int>>();
            _Controller = new PlayerController(_RepositoryMock.Object);
            _Controller.Contextualize(new MockEngineContext(), new ControllerContext());
        }

        [Test]
        public void Can_Add_Player()
        {            
            Player player = new Player { Name = "Optimus" };
            _RepositoryMock.Expect(r => r.Save(player)).Returns(player);
            _Controller.Create(player);
        }
    }
}
