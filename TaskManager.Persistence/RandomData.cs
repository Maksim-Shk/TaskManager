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
    "���������",
    "������",
    "����",
    "�����",
    "�����",
    "���������",
    "�������",
    "������",
    "������",
    "�������",
    "�������",
    "�����",
    "����",
    "�����",
    "����������",
    "������",
    "������",
    "������",
    "������",
    "������",
    "������",
    "�������",
    "�������",
    "������",
    "����",
    "�����",
    "�����",
    "�����",
    "��������",
    "������",
    "�������",
    "����",
    "���",
    "�������",
    "�����",
    "�����",
    "��������",
    "��������",
    "�����",
    "�����",
    "������",
    "�����",
    "�������",
    "��������",
    "��������",
    "����",
    "��������",
    "�������",
    "��������",
    "������",
    "�����"
            };
            return names[rand.Next(0, names.Length)];
        }

        public string GetRandomSurname(string name)
        {
            Random rand = new();
            string[] surnames = new string[]{
    "������",
    "������",
    "�������",
    "�������",
    "��������",
    "��������",
    "������",
    "�����",
    "��������",
    "�������",
    "�������",
    "�������",
    "�������",
    "�������",
    "������",
    "��������",
    "�������",
    "�������",
    "������",
    "������",
    "������",
    "��������",
    "��������",
    "�����",
    "�������",
    "�������",
    "�������",
    "�������",
    "������",
    "��������",
    "����������",
    "��������",
    "�������",
    "��������",
    "������",
    "������",
    "�������",
    "�����",
    "���������",
    "�����",
    "���������",
    "�������",
    "�����",
    "�����",
    "����������",
    "�������",
    "��������",
    "������",
    "��������",
    "��������",
    "�������"
};
            string lastChar = name.Substring(name.Length - 1);
            string surname = surnames[rand.Next(0, surnames.Length)];
            if (lastChar == "�" || lastChar == "�")
            {
                surname += "�";
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