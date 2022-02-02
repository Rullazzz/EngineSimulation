namespace EngineSimulation.Model
{
	public interface IEngine
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
        #endregion

        #region Методы
        /// <summary>
        /// Добавить стенд
        /// </summary>
        /// <param name="stand">Стенд</param>
        public void AddStand(IStand stand);

        /// <summary>
        /// Начать симуляцию
        /// </summary>
        /// <param name="tAir">Температура воздуха</param>
		public void StartSimulation(double temperatureAir);
        #endregion
    }
}
