using EngineSimulation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineSimulation.Tests
{
	[TestClass()]
	public class CreatorEngineTests
	{
		[TestMethod()]
		public void GetEngineTest()
		{
			// Arrange
			Config.PathToConfigJson = "../../../json/appsettings.json";
			Config.ReadConfig();
			var dataEngine = Config.DataEngine;
			var creator = new CreatorEngine();
			IEngine engine;

			// Act
			engine = creator.GetEngine(dataEngine, EngineType.InternalCombucstion);

			//Assert
			Assert.IsNotNull(engine);
		}
	}
}