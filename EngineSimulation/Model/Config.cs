using Newtonsoft.Json;
using System.IO;

namespace EngineSimulation.Model
{
    public static class Config
    {
		/// <summary>
		/// Путь к конфигурационному файлу
		/// </summary>
		public static string PathToConfigJson { get; set; } = "../../../appsettings.json";

		/// <summary>
		/// Данные о двигателе из конфигурационного файла
		/// </summary>
		public static DataEngine DataEngine { get; private set; }

		/// <summary>
		/// Прочитать конфигурационный файл
		/// </summary>
		public static void ReadConfig()
		{
			DataEngine = JsonConvert.DeserializeObject<DataEngine>(File.ReadAllText(PathToConfigJson));
		}
	}
}
