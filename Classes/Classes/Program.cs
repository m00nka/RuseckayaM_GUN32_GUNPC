using System; // Подключение пространства имен System для использования стандартных классов и методов
using System.Collections.Generic; // Подключение пространства имен для работы с коллекциями

// Определяем структуру Interval для работы с интервалами значений с плавающей точкой
public struct Interval
{
    public float Min { get; } // Свойство для хранения минимального значения интервала
    public float Max { get; } // Свойство для хранения максимального значения интервала

    // Конструктор с двумя целочисленными аргументами
    public Interval(int minValue, int maxValue) : this((float)minValue, (float)maxValue) { }

    public Interval(float minValue, float maxValue)  // Конструктор с двумя аргументами типа float
    {
        if (minValue > maxValue)
        {
            Console.WriteLine("Некорректные входные данные: minValue больше maxValue. Значения будут поменяны местами.");
            Min = maxValue;
            Max = minValue;
        }
        else
        {
            Min = minValue;
            Max = maxValue;
        }
    }

    // Конструктор с одним аргументом типа float
    public Interval(float value) : this(value, value) { }

    // Метод для получения случайного значения из интервала
    public float GetRandom()
    {
        Random random = new Random(); // Создаем экземпляр класса Random
        return (float)(Min + random.NextDouble() * (Max - Min)); // Возвращаем случайное значение
    }

    // Свойство для получения среднего значения интервала
    public float Average => (Min + Max) / 2f;
}

// Определяем структуру Rate для хранения информации об одном кадре поединка
public struct Rate
{
    public Unit Unit { get; } // Свойство для хранения юнита
    public int Damage { get; } // Свойство для хранения нанесенного урона
    public float Health { get; } // Свойство для хранения оставшегося здоровья

    // Конструктор, принимающий юнита, урон и здоровье
    public Rate(Unit unit, int damage, float health)
    {
        Unit = unit;
        Damage = damage;
        Health = (float)Math.Round(health, 2); // Округляем до двух знаков после запятой
    }
}

// Определяем класс Combat для инкапсуляции логики боя
public class Combat
{ 
    private List<Rate> rates = new List<Rate>(); // Список для хранения информации о каждом кадре боя

    // Метод для начала боя между двумя бойцами
    public void StartCombat(Unit fighter1, Unit fighter2)
    {
        Console.WriteLine("Начало боя!"); // Сообщение о начале боя

        Random random = new Random(); // Создаем экземпляр класса Random

        // Цикл, пока здоровье обоих бойцов больше 0
        while (fighter1.Health > 0 && fighter2.Health > 0)
        {
            if (random.Next(1, 11) % 2 == 0) // Если случайное число четное, атакует первый боец
            {
                float damage = fighter1.Damage; // Урон первого бойца
                float remainingHealth = fighter2.Health - damage; // Оставшееся здоровье второго бойца
                fighter2.SetHealth(remainingHealth); // Устанавливаем новое здоровье второго бойца
                rates.Add(new Rate(fighter1, (int)damage, remainingHealth)); // Добавляем запись о кадре боя
            }
            // Если случайное число нечетное, атакует второй боец
            else
            {
                float damage = fighter2.Damage; // Урон второго бойца
                float remainingHealth = fighter1.Health - damage; // Оставшееся здоровье первого бойца
                fighter1.SetHealth(remainingHealth); // Устанавливаем новое здоровье первого бойца
                rates.Add(new Rate(fighter2, (int)damage, remainingHealth));  // Добавляем запись о кадре боя
            } 
        }

        Console.WriteLine("Бой завершен!"); // Сообщение о завершении боя

        ShowResults(); // Вызов метода для отображения результатов
    }

    private void ShowResults()
    {
        foreach (var rate in rates)
        {
            Console.WriteLine($"Боец {rate.Unit.Name} нанес урон {rate.Damage} и оставил {rate.Health:F2} здоровья.");
        }
    }
}

// Определяем класс Unit для представления юнита (бойца)
public class Unit
{
    public string Name { get; } // Свойство для хранения имени юнита
    private float health; // Поле для хранения здоровья юнита

    public float Health => health; // Свойство для получения здоровья юнита
    public float RealHealth => Health * (1f + Armor); // Свойство для получения реального здоровья юнита с учетом брони
    public float Damage => EquippedWeapon != null ? EquippedWeapon.GetDamage() + BaseDamage : BaseDamage; // Свойство для получения урона юнита

    private const float BaseDamage = 5f; // Константа для базового урона

    public Weapon EquippedWeapon { get; set; } // Свойство для хранения экипированного оружия
    public Helm EquippedHelm { get; set; } // Свойство для хранения экипированного шлема
    public Shell EquippedShell { get; set; } // Свойство для хранения экипированной брони
    public Boots EquippedBoots { get; set; } // Свойство для хранения экипированных ботинок

    // Конструктор, принимающий имя юнита
    public Unit(string name)
    {
        Name = name;
    }

    // Метод для установки здоровья юнита
    public void SetHealth(float initialHealth)
    {
        health = Math.Max(0, Math.Min(initialHealth, 100)); // Устанавливаем здоровье в диапазоне от 0 до 100
    }

    // Метод для установки урона юнита
    public bool SetDamage(float value)
    {
        health -= value * (1f - Armor); // Уменьшаем здоровье с учетом брони
        return Health <= 0f; // Возвращаем true, если здоровье юнита 0 или меньше
    }

    public void EquipWeapon(Weapon weapon) // Метод для экипировки оружия
    {
        EquippedWeapon = weapon;
    }

    public void EquipHelm(Helm helm) // Метод для экипировки шлема
    {
        EquippedHelm = helm;
    }

    public void EquipShell(Shell shell) // Метод для экипировки брони
    {
        EquippedShell = shell;
    }

    public void EquipBoots(Boots boots) // Метод для экипировки ботинок
    {
        EquippedBoots = boots;
    }

    public float Armor // Свойство для получения значения брони
    {
        get
        {
            float totalArmor = 0f; // Переменная для хранения общего значения брони
            if (EquippedHelm != null)
                totalArmor += EquippedHelm.ArmorValue; // Добавляем значение брони шлема
            if (EquippedShell != null)
                totalArmor += EquippedShell.ArmorValue; // Добавляем значение брони
            if (EquippedBoots != null)
                totalArmor += EquippedBoots.ArmorValue; // Добавляем значение брони ботинок
            return Math.Min(totalArmor, 1f); // Возвращаем значение брони, не превышающее 1
        }
    }
}

// Определяем класс Weapon для представления оружия
public class Weapon
{
    public string Name { get; } // Свойство для хранения имени оружия
    private Interval DamageInterval; // Поле для хранения интервала урона

    // Конструктор, принимающий имя оружия, минимальный и максимальный урон
    public Weapon(string name, float minDamage, float maxDamage)
    {
        Name = name;
        DamageInterval = new Interval(minDamage, maxDamage);
    }

    // Метод для получения случайного урона из интервала
    public float GetDamage()
    {
        return DamageInterval.GetRandom();
    }
}

// Определяем класс Helm для представления шлема
public class Helm
{
    public string Name { get; } // Свойство для хранения имени шлема
    public float ArmorValue { get; } // Свойство для хранения значения брони шлема

    public Helm(string name, float armorValue) // Конструктор, принимающий имя шлема и значение брони
    {
        Name = name;
        ArmorValue = Math.Max(0, Math.Min(1, armorValue)); // Устанавливаем значение брони в диапазоне от 0 до 1
    }
}

// Определяем класс Shell для представления брони
public class Shell
{
    public string Name { get; } // Свойство для хранения имени брони
    public float ArmorValue { get; } // Свойство для хранения значения брони

    // Конструктор, принимающий имя брони и значение брони
    public Shell(string name, float armorValue)
    {
        Name = name;
        ArmorValue = Math.Max(0, Math.Min(1, armorValue)); // Устанавливаем значение брони в диапазоне от 0 до 1
    }
}

// Определяем класс Boots для представления ботинок
public class Boots
{
    public string Name { get; } // Свойство для хранения имени ботинок
    public float ArmorValue { get; } // Свойство для хранения значения брони ботинок

    // Конструктор, принимающий имя ботинок и значение брони
    public Boots(string name, float armorValue)
    {
        Name = name;
        ArmorValue = Math.Max(0, Math.Min(1, armorValue)); // Устанавливаем значение брони в диапазоне от 0 до 1
    }
}

// Основной класс программы
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Подготовка к бою:"); // Выводим сообщение о начале подготовки к бою

        // Создание бойцов
        Unit fighter1 = new Unit("Fighter 1"); // Создаем первого бойца
        fighter1.SetHealth(80f); // Устанавливаем здоровье первого бойца
        fighter1.EquipHelm(new Helm("Fighter 1's Helm", 0.8f)); // Экипируем первого бойца шлемом
        fighter1.EquipShell(new Shell("Fighter 1's Shell", 0.6f)); // Экипируем первого бойца броней
        fighter1.EquipBoots(new Boots("Fighter 1's Boots", 0.7f)); // Экипируем первого бойца ботинками
        fighter1.EquipWeapon(new Weapon("Fighter 1's Weapon", 15f, 25f)); // Экипируем первого бойца оружием

        Unit fighter2 = new Unit("Fighter 2");  // Создаем второго бойца
        fighter2.SetHealth(90f); // Устанавливаем здоровье второго бойца
        fighter2.EquipHelm(new Helm("Fighter 2's Helm", 0.9f)); // Экипируем второго бойца шлемом
        fighter2.EquipShell(new Shell("Fighter 2's Shell", 0.5f)); // Экипируем второго бойца броней
        fighter2.EquipBoots(new Boots("Fighter 2's Boots", 0.6f)); // Экипируем второго бойца ботинками
        fighter2.EquipWeapon(new Weapon("Fighter 2's Weapon", 10f, 20f)); // Экипируем второго бойца оружием

        // Вывод данных бойцов
        Console.WriteLine($"Боец 1: {fighter1.Name}, Здоровье: {fighter1.Health}, Урон: {fighter1.Damage}");
        Console.WriteLine($"Боец 2: {fighter2.Name}, Здоровье: {fighter2.Health}, Урон: {fighter2.Damage}");

        // Создание экземпляра класса Combat и начало боя
        Combat combat = new Combat();
        combat.StartCombat(fighter1, fighter2);
    }
}
