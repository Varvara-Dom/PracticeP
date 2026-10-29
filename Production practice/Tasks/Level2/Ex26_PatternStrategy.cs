using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class Ex26_PatternStrategy : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "Реализовать калькулятор скидок через паттерн «Стратегия».";
        public string[] Condition => new[]
        {
            "Интерфейс IDiscountStrategy с методом Apply(decimal price)",
            "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount` (20%)",
            "Класс PriceCalculator, принимающий стратегию в конструкторе",
            "Продемонстрировать расчёт цены с каждой стратегией"
        };

        public void Launch()
        {
            Console.WriteLine("--- Демонстрация паттерна «Стратегия» ---\n");

            decimal BPrice = 1000m;
            Console.WriteLine($"Базовая цена товара: {BPrice:C}\n");

            var CalcNoDiscount = new PriceCalc(new NoDiscount());
            decimal PriceNoDiscount = CalcNoDiscount.Calc(BPrice);
            Console.WriteLine($"Без скидки:{PriceNoDiscount:C} (Скидка: 0%)");

            var CalcVip = new PriceCalc(new VipDiscount());
            decimal PriceVip = CalcVip.Calc(BPrice);
            Console.WriteLine($"VIP скидка:{PriceVip:C} (Скидка: 10%)");

            var CalcPromo = new PriceCalc(new PromoDiscount());
            decimal PricePromo = CalcPromo.Calc(BPrice);
            Console.WriteLine($"Промо-скидка:{PricePromo:C} (Скидка: 20%)");

            Console.WriteLine("\n--- Демонстрация смены стратегии на лету ---");

            var ChangingCalculator = new PriceCalc(new NoDiscount());
            Console.WriteLine($"Текущая цена: {ChangingCalculator.Calc(BPrice):C}");

            ChangingCalculator.SetStrategy(new PromoDiscount());
            Console.WriteLine($"Цена после смены стратегии на Промо: {ChangingCalculator.Calc(BPrice):C}");
        }
        public interface ISDescountStrategy
        {
            decimal Use(decimal price);
        }
        public class NoDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price;
        }
        public class VipDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price * 0.90m;
        }
        public class PromoDiscount : ISDescountStrategy
        {
            public decimal Use(decimal price) => price * 0.80m;
        }
        public class PriceCalc
        {
            private ISDescountStrategy _strategy;
            public PriceCalc(ISDescountStrategy strategy)
            {
                _strategy = strategy;
            }
            public void SetStrategy(ISDescountStrategy strategy)
            {
                _strategy = strategy;
            }
            public decimal Calc(decimal bPrice)
            {
                if (bPrice < 0)
                    throw new ArgumentException("Цена не может быть ниже нуля");
                return _strategy.Use(bPrice);
            }
        }
    }
}
