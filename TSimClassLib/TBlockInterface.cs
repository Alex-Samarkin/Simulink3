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

    }
}