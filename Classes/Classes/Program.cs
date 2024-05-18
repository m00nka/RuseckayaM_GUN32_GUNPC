using System;

namespace Classes
{
    class Unit
    {
        public string Name { get; } // Имя персонажа
        private float health; // Здоровье персонажа
        public float Health => health; // Свойство для доступа к здоровью

        // Экипированные предметы персонажа
        private Weapon EquippedWeapon { get; set; } // Экипированное оружие
        private Helm EquippedHelm { get; set; } // Экипированный шлем
        private Shell EquippedShell { get; set; } // Экипированная кираса
        private Boots EquippedBoots { get; set; } // Экипированные сапоги

        private const float BaseDamage = 5f; // Базовый урон персонажа

        // Конструкторы
        public Unit() : this("Unknown Unit") { } // Без аргумента
        public Unit(string name)
        {
            Name = name;
        }

        // Фактическое здоровье персонажа
        public float RealHealth => Health * (1f + Armor);

        // Получение урона
        public bool SetDamage(float value)
        {
            // Уменьшение здоровья с учетом брони
            health -= value * (1f - Armor);
            // Проверка на смерть персонажа
            return Health <= 0f;
        }

        // Снарядить оружия
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }

        // Экипировка шлема
        public void EquipHelm(Helm helm)
        {
            EquippedHelm = helm;
        }

        // Экипировка кирасы
        public void EquipShell(Shell shell)
        {
            EquippedShell = shell;
        }

        // Экипировка сапог
        public void EquipBoots(Boots boots)
        {
            EquippedBoots = boots;
        }

        // Общий урон персонажа
        public float Damage
        {
            get
            {
                // Расчет общего урона с учетом оружия и базового урона
                if (EquippedWeapon != null)
                    return EquippedWeapon.GetDamage() + BaseDamage; // Суммируем урон оружия и базовый урон
                else
                    return BaseDamage; //Возвращаем только базовый урон, если нет оружия
            }
        }

        // Общая броня персонажа
        public float Armor
        {
            get
            {
                float totalArmor = 0f;
                // Суммирование брони от всех экипированных предметов
                if (EquippedHelm != null)
                    totalArmor += EquippedHelm.ArmorValue;
                if (EquippedShell != null)
                    totalArmor *= EquippedShell.ArmorValue;
                if (EquippedBoots != null)
                    totalArmor += EquippedBoots.ArmorValue;
                return Math.Min(totalArmor, 1f);
            }
        }
        // Установка начального здоровья
        public void SetHealth(float initialHealth)
        {
            health = initialHealth;
        }
    }

    // Класс представления оружия
    class Weapon
    {
        public string Name { get; } // Имя оружия
        public float MinDamage { get; private set; } // Минимальный урон
        public float MaxDamage { get; private set; } // Максимальный урон

        // Конструкторы
        public Weapon(string name)
        { 
            Name = name;
        }

        public Weapon(string name, float minDamage, float maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage); //Параметр урона
        }

        // Установка параметров урона
        public void SetDamageParams(float minDamage, float maxDamage) 
        { 
            if (minDamage > maxDamage)
            {
                var temp = MinDamage;
                minDamage = maxDamage;
                maxDamage = temp;
                Console.WriteLine($"Некорректные входные данные для {Name}: minDamage больше maxDamage. Значения были поменяны местами.");
            }

            if (minDamage < 1f)
            {
                MinDamage = 1f;
                Console.WriteLine($"Минимальный урон для {Name} был форсирован до 1f.");
            }

            if (maxDamage <= 1f)
            {
                MaxDamage = 10f;
                Console.WriteLine($"Максимальный урон для {Name} был установлен до 10f.");
            }

            MinDamage = minDamage;
            MaxDamage = maxDamage;        
        }

        // Получение урона
        public float GetDamage()
        {
            return (MinDamage + MaxDamage) / 2f; // Возвращение среднего арифметического между минимальным и максимальным уроном
        }
    }

    // Класс представления шлема
    class Helm
    {
        public string Name { get; }
        private float armorValue; // Значение брони
        public float ArmorValue
        {
            get => armorValue;
            set
            {
                if (value < 0f)
                {
                    armorValue = 0f;
                    Console.WriteLine($"Показатель брони шлема был округлен до 0.");
                }
                else if (value > 1f)
                {
                    armorValue = 1f;
                    Console.WriteLine($"Показатель брони шлема был округлен до 1.");
                }
                else
                {
                    armorValue = value;
                }
            }
        }

        public Helm(string name)
        {
            Name = name;    
        }
    }

    // Класс представления кирасы
    class Shell
    {
        public string Name { get; }
        private float armorValue;
        public float ArmorValue
        {
            get => armorValue;
            set
            {
                if (value < 0f)
                {
                    armorValue = 0f;
                    Console.WriteLine($"Показатель брони кирасы был округлен до 0.");
                }
                else if (value > 1f)
                {
                    armorValue = 1f;
                    Console.WriteLine($"Показатель брони кирасы был округлен до 1.");
                }
                else
                {
                    armorValue = value;
                }
            }
        }

        public Shell(string name)
        {
            Name = name;  
        }
    }
        
    // Класс представления сапог
    class Boots
    {
        public string Name { get; }
        private float armorValue;
        public float ArmorValue
        {
            get => armorValue;
            set
            {
                if (value < 0f)
                {
                    armorValue = 0f;
                    Console.WriteLine($"Показатель брони сапог был округлен до 0.");
                }
                else if (value > 1f)
                {
                    armorValue = 1f;
                    Console.WriteLine($"Показатель брони сапог был округлен до 1.");
                }
                else
                {
                    armorValue = value;
                }
            }
        }
        // Конструктор класса сапог
        public Boots(string name)
        {
            Name = name; // Инициализация имени сапог
        }
    }
        
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою: ");
            Console.Write("Введите имя бойца: ");
            string name = Console.ReadLine();

            Console.Write("Введите начальное здоровье бойца (10-100): ");
            float health = float.Parse(Console.ReadLine());

            Console.Write("Введите значение брони шлема от 0 до 1: ");
            float helmArmor = float.Parse(Console.ReadLine());

            Console.Write("Введите значение брони кирасы от 0 до 1: ");
            float shellArmor = float.Parse(Console.ReadLine());

            Console.Write("Введите значение брони сапог от 0 до 1: ");
            float bootsArmor = float.Parse(Console.ReadLine());

            Console.Write("Укажите минимальный урон оружия (0-20): ");
            float minWeaponDamage = float.Parse(Console.ReadLine());

            Console.Write("Укажите максимальный урон оружия (20-40): ");
            float maxWeaponDamage = float.Parse(Console.ReadLine());

            Unit player = new Unit(name); // Создание экземпляра класса персонажа
            player.SetHealth(health); // Установка начального здоровья персонажа

            Helm playerHelm = new Helm("Player's Helm") { ArmorValue = helmArmor }; // Создание и экипировка шлема
            Shell playerShell = new Shell("Player's Shell") { ArmorValue = shellArmor }; // Создание и экипировка кирасы
            Boots playerBoots = new Boots("Player's Boots") { ArmorValue = bootsArmor }; // Создание и экипировка сапог

            Weapon playerWeapon = new Weapon("Player's Weapon", minWeaponDamage, maxWeaponDamage); // Создание и экипировка оружия

            // Экипировка персонажа предметами
            player.EquipHelm(playerHelm);
            player.EquipShell(playerShell);
            player.EquipBoots(playerBoots);
            player.EquipWeapon(playerWeapon);

            // Вывод информации о персонаже
            Console.WriteLine($"Общий показатель брони равен: {player.Armor}");
            Console.WriteLine($"Фактическое значение здоровья равно: {player.RealHealth}");
        }
    }
}




