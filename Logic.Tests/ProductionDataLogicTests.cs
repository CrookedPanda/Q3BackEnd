using DTO;
using Logic.Tests.DalMock.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests;

[TestClass]
public class ProductionDataLogicTests {
    [TestMethod]
    public void ReadAll_ReturnsAllData() {
        production_dataLogic productionDataLogic = new production_dataLogic(new ProductionDataHandlerMock());
        IEnumerable<production_dataDTO> productionData = productionDataLogic.ReadAll();
        Assert.AreEqual(8, productionData.Count());
    }

    [TestMethod]
    public void GetByMachine_ReturnsMatchingByPortAndBoard() {
        production_dataLogic productionDataLogic = new production_dataLogic(new ProductionDataHandlerMock());
        IEnumerable<production_dataDTO> productionData = productionDataLogic.GetByMachine(1, 2);
        Assert.AreEqual(1, productionData.Count());
    }
}
