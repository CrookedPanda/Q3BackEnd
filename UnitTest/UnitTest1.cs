using DAL.Handlers;
using Logic;
using Moq;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mock = new Mock<Imonitoring_dataHandler>();
            mock.Setup(repo => repo.Get());
            monitoring_dataLogic logic = new monitoring_dataLogic(mock.Object);
            logic.CalculateList();
        }
    }
}
