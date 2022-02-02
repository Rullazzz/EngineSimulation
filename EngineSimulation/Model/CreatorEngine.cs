using EngineSimulation.Model;
using System;

namespace EngineSimulation
{
	public class CreatorEngine : ICreatorEngine
	{
		public CreatorEngine()
		{
		}

		public IEngine GetEngine(DataEngine dataEngine, EngineType type)
		{
			IEngine engine = type switch
			{
				EngineType.InternalCombucstion => new InternalCombucstionEngine(dataEngine),
				EngineType.Other => new InternalCombucstionEngine(dataEngine),
				_ => throw new ArgumentException("Такого типа двигателя нет"),
			};
			engine.Type = type;
            return engine;
		}
	}
}