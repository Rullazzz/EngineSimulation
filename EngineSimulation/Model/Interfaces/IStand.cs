namespace EngineSimulation.Model
{
	public interface IStand
	{
		/// <summary>
		/// Запуск симуляции двигателя
		/// </summary>
		/// <param name="Engine">Двинатель</param>
		/// <param name="tAir">Температура окружающей среды</param>
		public void Run(IEngine Engine, double tAir);
		/// <summary>
		/// Проводит двигатель по всем тестам
		/// </summary>
		/// <param name="Engine"></param>
		public void Test(IEngine Engine);
	}
}