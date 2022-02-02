namespace EngineSimulation.Model
{
	public class DataEngine
	{
        #region Свойства
        /// <summary>
        /// Тип двигателя
        /// </summary>
        public EngineType Type { get; set; }

        /// <summary>
        /// Возвращает true, если двигатель работает,
        /// иначе false
        /// </summary>
        public bool IsRun { get; set; }

        /// <summary>
        /// Время работы двигателя
        /// </summary>
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
    }
}
