
namespace CodeFirst_UI
{
    public static class Constans
    {
        public static string StarterMenu = "Виберіть будь ласка сутність(введіть номер) для проведення операцій:\n" +
            "1. Студенти\n2. Групи\n3. Гуртожитки\n";

        public const string StudentMenu = "Для студентів доступні наступні операції:\n" +
            "1. Показати усіх студентів\n" +
            "2. Показати усіх студентів без гуртожитків\n" +
            "3. Показати усіх студентів з гуртожитками\n" +
            "4. Додати нового студента\n" +
            "0. Повернутись до перереднього меню\n";

        public const string GroupMenu = "Для груп доступні наступні операції:\n" +
            "1. Додати нову групу\n" +
            "2. Показати список усіх груп\n" +
            "0. Повернутись до перереднього меню\n";

        public const string DormitoryMenu = "Для гуртожитків доступні наступні операції\n" +
            "1. Додати новий гуртожиток\n" +
            "2. Показати список усіх гутожитків\n" +
            "0. Повернутись до перереднього меню\n";

        public const string InvalidValue = "Не правильний формат введення даних, спробуйте знову";
        public static int CountStarterOperations = 3;
        public const int CountGroupOperations = 2;
        public const int CountDormitoriesOperations = 2;
    }
}
