using System;
using System.Collections.Generic;

namespace EngineSimulation.Model
{
    public class Stand : IStand
    {
        public readonly List<TestType> Tests = new() { TestType.Overheating };
        public int MaxTime { get; set; } = 1000;

        public Stand(List<TestType> tests)
        {
            Tests = tests;
        }

        public void Run(IEngine engine, double tAir)
        {
            engine.StartSimulation(tAir);
        }
        
        private void Overheating(IEngine engine)
        {
            switch (engine.Type)
            {
                case EngineType.InternalCombucstion:
                    Overheating(engine as InternalCombucstionEngine);
                    break;
                default:
                    throw new ArgumentException("Этот тип двигателя не поддерживается");
            }
        }

        private void Overheating(InternalCombucstionEngine engine)
        {
            engine.IsRun = ((engine.T - engine.Temperature) > 0) && engine.Time < MaxTime;
            if (!engine.IsRun)
            {
				Console.Write("Тест на Перегревание: ");
				if (engine.Time >= MaxTime)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Двигатель не перегрелся");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Двигатель перегрелся, время {engine.Time} сек.");

				}
				Console.ResetColor();
            }
        }

        public void Test(IEngine engine)
        {
            foreach (var test in Tests)
            {
                switch (test)
                {
                    case TestType.Overheating:
                        Overheating(engine);
                        break;
                    default:
                        throw new Exception("Нет тестов");
                }
            }
        }
    }
}
