using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class Ex23_TheNullableTypes : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Продемонстрировать работу с nullable";
        public string[] Condition => new[]
        {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет",
            "Использовать ?? для значения по умолчанию",
            "Использовать ?. для безопасного доступа к свойству объекта, который может быть null",
            "Использовать HasValue / Value с проверкой",
            "Продемонстрировать на примере с найденным и ненайденным ключом"
        };

        public void Launch()
        {
            Console.WriteLine("--- Работа с методом FindValue и оператором ?? ---");

            int? foundValue = FindValue("arena");
            int safeFoundValue = foundValue ?? -1;
            Console.WriteLine($"Ключ 'arena': Значение = {safeFoundValue}");

            int? notFoundValue = FindValue("online");
            int safeNotFoundValue = notFoundValue ?? -1;
            Console.WriteLine($"Ключ 'online': Значение = {safeNotFoundValue} (по умолчанию)");

            Console.WriteLine("\n--- Использование HasValue / Value ---");
            if (foundValue.HasValue)
            {
                Console.WriteLine($"Проверка HasValue: Значение для 'arena' = {foundValue.Value}");
            }

            if (!notFoundValue.HasValue)
            {
                Console.WriteLine("Проверка HasValue: Значение для 'online' отсутствует (null).");
            }

            Console.WriteLine("\n--- Использование ?. (Null-conditional operator) ---");

            User UserWithoutAProfile = new User { Name = "Александр", Profile = null };
 
            User UserWithAProfile = new User { Name = "Олег", Profile = new UserProfile { Email = "lubaiaposhta@gmail.com" } };

            string email1 = UserWithoutAProfile?.Profile?.Email;
            Console.WriteLine($"Email пользователя 1: {(email1 ?? "не указан")}");

            string email2 = UserWithoutAProfile?.Profile?.Email;
            Console.WriteLine($"Email пользователя 2: {(email2 ?? "не указан")}");

            string nullString = null;
            int? length = nullString?.Length;
            Console.WriteLine($"Длина null-строки: {(length.HasValue ? length.Value.ToString() : "null")}");
        }
        private readonly Dictionary<string, int> _data = new Dictionary<string, int>
        {
            {"Immediatle", 100},
            {"Eternity", 200},
            {"Operand", 300},
            {"Theodolite", 400},
            {"Kosher", 500}
        };
        private class User
        {
            public string Name { get; set; }
            public UserProfile Profile { get; set; }
        }
        private class UserProfile
        {
            public string Email { get; set; }
        }
        public int? FindValue(string key)
        {
            if (_data.TryGetValue(key, out int value))
            {
                return value;
            }
            return null;
        }
    }
}
