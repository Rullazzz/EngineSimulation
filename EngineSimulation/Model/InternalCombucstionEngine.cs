using System;

namespace EngineSimulation.Model
{
	public class InternalCombucstionEngine : IEngine
	{
		private int _index = 0;
		private IStand _stand = null;

		#region Свойства
		public bool IsRun { get; set; }
		public EngineType Type { get; set; }
		public int Time { get; set; }

		/// <summary>
		/// Момент инерции двигателя
		/// </summary>
		public double I { get; set; }

		/// <summary>
		/// Кусочно-линейная зависимость крутящего момента, вырабатываемого двигателем
		/// </summary>
		public int[] M { get; set; }

		/// <summary>
		/// Cкорость вращения коленвала
		/// </summary>
		public int[] V { get; set; }

		/// <summary>
		/// Температура перегрева
		/// </summary>
		public double T { get; set; }

		/// <summary>
		/// Коэффициент зависимости скорости нагрева от крутящего момент
		/// </summary>
		public double Hm { get; set; }

		/// <summary>
		/// Коэффициент зависимости скорости нагрева от скорости вращения коленвала
		/// </summary>
		public double Hv { get; set; }

		/// <summary>
		/// Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
		/// </summary>
		public double C { get; set; }

		/// <summary>
		/// Температура двигателя
		/// </summary>
		public double Temperature { get; set; }

		/// <summary>
		/// Температура воздуха
		/// </summary>
		public double TemperatureAir { get; set; }
		#endregion

		public InternalCombucstionEngine() { }

		/// <summary>
		/// Устанавливает данные двигателя
		/// </summary>
		public InternalCombucstionEngine(DataEngine dataEngine)
		{
			SetSettings(dataEngine);
		}

		/// <summary>
		/// Устанавливает данные двигателя
		/// </summary>
		/// <param name="i">Момент инерции двигателя</param>
		/// <param name="m">Кусочно-линейная зависимость крутящего момента, вырабатываемого двигателем</param>
		/// <param name="v">Cкорость вращения коленвала</param>
		/// <param name="t">Температура перегрева</param>
		/// <param name="hm">Коэффициент зависимости скорости нагрева от крутящего момент</param>
		/// <param name="hv">Коэффициент зависимости скорости нагрева от скорости вращения коленвала</param>
		/// <param name="c">Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды</param>
		public InternalCombucstionEngine(double i, int[] m, int[] v, double t, double hm, double hv, double c)
		{
			I = i;
			M = m ?? throw new ArgumentNullException(nameof(m));
			V = v ?? throw new ArgumentNullException(nameof(v));
			T = t;
			Hm = hm;
			Hv = hv;
			C = c;
		}

		private void SetSettings(DataEngine dataEngine)
		{
			I = dataEngine.I;
			M = dataEngine.M;
			V = dataEngine.V;
			T = dataEngine.T;
			Hm = dataEngine.Hm;
			Hv = dataEngine.Hv;
			C = dataEngine.C;
		}

		private double GetVc() => C * (TemperatureAir - Temperature);
		private double GetVh() => M[_index] * Hm + Math.Pow(V[_index], 2) * Hv;

		public void StartSimulation(double tAir)
		{
			IsRun = true;

			TemperatureAir = tAir;
			Temperature = TemperatureAir;

			double v = V[0];
			double m = M[0];
			double a = m / I;

			Time = 0;
			while (IsRun)
			{
				Time++;
				v += a;

				if (_index < M.Length - 2)
				{
					_index += v < M[_index + 1] ? 0 : 1;
				}

				double up = v - V[_index];
				double down = V[_index + 1] - V[_index];
				double factor = M[_index + 1] - M[_index];
				m = up / down * factor + M[_index];
				Temperature += GetVc() + GetVh();
				a = m / I;
				_stand.Test(this);
			}
		}

		public void AddStand(IStand stand)
		{
			_stand = stand;
		}
	}
}
