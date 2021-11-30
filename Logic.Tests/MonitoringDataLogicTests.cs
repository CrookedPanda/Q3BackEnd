using DTO;
using Logic.Tests.DalMock.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests;

[TestClass]
public class MonitoringDataLogicTests {
    [TestMethod]
    public void ReadAll_ReturnsAllData() {
        monitoring_dataLogic monitoringDataLogic = new monitoring_dataLogic(new MonitoringDataHandlerMock());
        IEnumerable<monitoring_dataDTO> monitoringData = monitoringDataLogic.ReadAll();
        Assert.AreEqual(9, monitoringData.Count());
    }

    [TestMethod]
    public void GetByPort_ReturnsMatchingByPort() {
        monitoring_dataLogic monitoringDataLogic = new monitoring_dataLogic(new MonitoringDataHandlerMock());
        IEnumerable<monitoring_dataDTO> monitoringData = monitoringDataLogic.GetByPort(1);
        Assert.AreEqual(3, monitoringData.Count());
    }

    [TestMethod]
    public void GetByMachine_ReturnsMatchingByPortAndBoard() {
        monitoring_dataLogic monitoringDataLogic = new monitoring_dataLogic(new MonitoringDataHandlerMock());
        IEnumerable<monitoring_dataDTO> monitoringData = monitoringDataLogic.GetByMachine(1, 2);
        Assert.AreEqual(1, monitoringData.Count());
    }
}
