using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level2
{
    internal class Ex29_PatternFactory : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Реализовать фабрику уведомлений.";
        public string[] Condition => new[]
        {
            "Интерфейс INotification с методом Send(string message)",
            "Реализации: EmailNotification, SmsNotification, PushNotification",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "Enum NotificationType { Email, Sms, Push }",
            "Продемонстрировать создание и отправку через фабрику"
        };

        public void Launch()
        {
            Console.WriteLine("--- Демонстрация паттерна «Фабрика» ---\n");

            string message = "Скидка 25% на все товары! Успейте купить.";

            foreach (NotificationType type in Enum.GetValues(typeof(NotificationType)))
            {
                Console.WriteLine($"--- Попытка отправить через {type} ---");

                try
                {
                    INotification Notification = NotificationFactory.Create(type);

                    Notification.Send(message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine();
            }
            Console.WriteLine("--- Попытка передать неверный тип ---");
            try
            {
                NotificationType invalidType = (NotificationType)99;
                INotification invalidNotification = NotificationFactory.Create(invalidType);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }
        public interface INotification
        {
            void Send(string message);
        }
        public class EmailNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[Email] Отправлено эл. письмо: \"{message}\"");
            }
        }
        public class SmsNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"[SMS] Отправлено сообщение: \"{message}\"");
            }
        }
        public class PushNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"  [Push] Отправлено уведомление: \"{message}\"");
            }
        }
        public enum NotificationType
        {
            Email,
            Sms,
            Push,
        }
        public static class NotificationFactory
        {
            public static INotification Create(NotificationType type)
            {
                switch (type)
                {
                    case NotificationType.Email:
                        return new EmailNotification();
                    case NotificationType.Sms:
                        return new SmsNotification();
                    case NotificationType.Push:
                        return new PushNotification();
                    default:
                        throw new ArgumentException($"Неизвестный тип уведомления: {type}");
                }
            }
        }
    }
}
