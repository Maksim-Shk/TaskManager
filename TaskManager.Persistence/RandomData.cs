using System;
using System.Collections.Generic;

namespace TaskManager.Persistence
{
    public class RandomData
    {
        public string GetRandomName()
        {
            Random rand = new();
            string[] names = new string[]{
    "Александр",
    "Андрей",
    "Анна",
    "Артем",
    "Борис",
    "Валентина",
    "Василий",
    "Виктор",
    "Галина",
    "Дмитрий",
    "Евгений",
    "Елена",
    "Иван",
    "Ирина",
    "Константин",
    "Лариса",
    "Леонид",
    "Любовь",
    "Максим",
    "Марина",
    "Михаил",
    "Надежда",
    "Наталья",
    "Оксана",
    "Олег",
    "Ольга",
    "Павел",
    "Роман",
    "Светлана",
    "Сергей",
    "Татьяна",
    "Юлия",
    "Яна",
    "Алексей",
    "Алина",
    "Алиса",
    "Анатолий",
    "Анжелика",
    "Антон",
    "Арина",
    "Богдан",
    "Вадим",
    "Валерий",
    "Вероника",
    "Виктория",
    "Влад",
    "Владимир",
    "Георгий",
    "Григорий",
    "Даниил",
    "Дарья"
            };
            return names[rand.Next(0, names.Length)];
        }

        public string GetRandomSurname(string name)
        {
            Random rand = new();
            string[] surnames = new string[]{
    "Иванов",
    "Петров",
    "Сидоров",
    "Смирнов",
    "Кузнецов",
    "Васильев",
    "Зайцев",
    "Попов",
    "Михайлов",
    "Федоров",
    "Соколов",
    "Яковлев",
    "Новиков",
    "Морозов",
    "Волков",
    "Алексеев",
    "Лебедев",
    "Семенов",
    "Егоров",
    "Павлов",
    "Козлов",
    "Степанов",
    "Николаев",
    "Орлов",
    "Андреев",
    "Макаров",
    "Никитин",
    "Захаров",
    "Зверев",
    "Филиппов",
    "Колесников",
    "Медведев",
    "Борисов",
    "Дмитриев",
    "Ефимов",
    "Гришин",
    "Тихонов",
    "Белов",
    "Кудрявцев",
    "Быков",
    "Герасимов",
    "Аксенов",
    "Гусев",
    "Рябов",
    "Кондратьев",
    "Лазарев",
    "Воронцов",
    "Климов",
    "Федосеев",
    "Мартынов",
    "Куликов"
};
            string lastChar = name.Substring(name.Length - 1);
            string surname = surnames[rand.Next(0, surnames.Length)];
            if (lastChar == "а" || lastChar == "я")
            {
                surname += "а";
            }
            return surname;
        }
        public DateTime RandomDay()
        {
            DateTime start = DateTime.UtcNow.AddDays(-200);
            Random gen = new();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            DateTime randomData = start.AddDays(gen.Next(range));
            return randomData;
        }
    }
}