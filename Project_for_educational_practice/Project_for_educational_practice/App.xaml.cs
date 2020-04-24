using System.Windows;
using System.Windows.Threading;

using LoggerDLL;

namespace Project_for_educational_practice
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppStartup(object s, StartupEventArgs e)
        {
            new Logger().WriteInLog(LogType.Info, "Запуск приложения");
        }

        public void AppException(object s, DispatcherUnhandledExceptionEventArgs e)
        {
            new Logger().WriteInLog(LogType.Error, $"Приложение поймало не обработанное исключение {e}");
        }

        public void AppExit(object s, ExitEventArgs e)
        {
            new Logger().WriteInLog(LogType.Info, "Приложение завершило свою работу");
        }
    }
}
