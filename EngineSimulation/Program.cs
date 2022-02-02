using EngineSimulation.Model;
using System;
using System.Collections.Generic;

namespace EngineSimulation
{
	class Program
	{
		static void Main(string[] args)
		{
			Config.ReadConfig();
			var creator = new CreatorEngine();
			IEngine engine;

			double temp;
			while (true)
			{
				Console.Write("Введите температуру окружающей среда: ");
				if (double.TryParse(Console.ReadLine(), out temp))
					break;
				Console.Clear();
				Console.WriteLine("Неверный формат данных");
			}

			try
			{
				engine = creator.GetEngine(Config.DataEngine, EngineType.InternalCombucstion);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			var stand = new Stand(new List<TestType>() { TestType.Overheating });
			engine.AddStand(stand);
			stand.Run(engine, temp);
		}
	}
}
