namespace EngineSimulation.Model
{
	public interface ICreatorEngine
	{
		/// <summary>
		/// Инициализирует новый двигатель и возвращает его в виде интерфейса IEngine
		/// </summary>
		/// <param name="dataEngine">Данные о двигателя</param>
		/// <param name="type">Тип двигателя</param>
		/// <returns>Двигатель</returns>
		public IEngine GetEngine(DataEngine dataEngine, EngineType type);
	}
}
