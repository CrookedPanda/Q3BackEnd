using DTO;
using Logic.Tests.DalMock.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests;

[TestClass]
public class MachineMonitoringPoortenLogicTests {
    [TestMethod]
    public void ReadAll_ReturnsAllPorts() {
        machine_monitoring_poortenLogic logic = CreatePoortenLogic();
        IEnumerable<machine_monitoring_poortenDTO> poorten = logic.ReadAll();
        Assert.AreEqual(4, poorten.Count());
    }

    [TestMethod]
    public void ReadByName_ReturnsMatchingByName() {
        machine_monitoring_poortenLogic logic = CreatePoortenLogic();
        IEnumerable<machine_monitoring_poortenDTO> poorten = logic.ReadByName("foo");
        Assert.AreEqual(2, poorten.Count());
    }

    [TestMethod]
    public void GetMachine_ReturnsMatchingByPortAndBoard() {
        machine_monitoring_poortenLogic logic = CreatePoortenLogic();
        IEnumerable<machine_monitoring_poortenDTO> poorten = logic.GetMachine(1, 1);
        Assert.AreEqual(2, poorten.Count());
    }

    private static machine_monitoring_poortenLogic CreatePoortenLogic() {
        PoortenHandlerMock poortenHandler = new PoortenHandlerMock();
        monitoring_dataLogic monitoringDataLogic = new monitoring_dataLogic(new MonitoringDataHandlerMock());
        production_dataLogic productionDataLogic = new production_dataLogic(new ProductionDataHandlerMock());
        return new machine_monitoring_poortenLogic(poortenHandler, monitoringDataLogic, productionDataLogic);
    }
}
