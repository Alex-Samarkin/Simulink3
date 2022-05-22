// Simulink3
// TSimClassLib
// TBlockInterface.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:57 09 04 2022

namespace TSimClassLib
{
    /// <summary>
    /// интерфейс блока
    /// </summary>
    public interface TBlockInterface
    {
        /// <summary>
        /// инициализация
        /// </summary>
        void Init();

        /// <summary>
        /// сброс настроек на умолчания / начальные настройки (можно сделать Init)
        /// </summary>
        void Reset();

        /// <summary>
        /// расчет 1-го шага
        /// </summary>
        void Run();

        /// <summary>
        /// установка параметров (после init)
        /// Init - устанавливает параметры в 0
        /// SetParams - ставит значения параметров для начала расчета
        /// Reset - восстанавливает начальные значения ПОСЛЕ SetParams
        /// Run - предполагается, что параметры установлены
        ///
        /// рекомендуется реализация reset в виде Init-SetParams
        /// </summary>
        void SetParams();
    }
}