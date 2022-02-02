using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineSimulation.Model.Tests
{
	[TestClass()]
	public class ConfigTests
	{
		[TestMethod()]
		public void ReadConfigTest()
		{
			// Arrange
			Config.PathToConfigJson = "../../../json/appsettings.json";

			// Act
			Config.ReadConfig();

			// Assert
			Assert.IsNotNull(Config.DataEngine);
		}
	}
}