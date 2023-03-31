Fighter[] fighters = new Fighter[] { new Fighter("Max", 20, 100), new Fighter("Stas", 15, 100), new Fighter("Artem", 21, 100) };

Arena arena1 = new Arena(3);

arena1.Fight(fighters);

class Fighter
{
    public string Name;
    public int Damage;
    public int Health;

    public Fighter(string name, int damage, int health)
    {
        Name = name;
        Damage = damage;
        Health = health;
    }
}


class Arena
{
    public int Size;
    private Random _random;
    
    public Arena(int size)
    {
        Size = size;
        _random = new Random();
    }

    public void Fight(Fighter[] fighters)
    {
        if (Size < fighters.Length)
        {
            Console.WriteLine("Ошибка, введите количество бойцов не превышающее слотов арены.");
            return;
        }

        while (CheckFightersHealth(fighters))
        {
            for (int i = 0; i < Size; i++)
            {
                var fighter = _random.Next(fighters.Length);
                var victim = _random.Next(fighters.Length);
                while (victim == fighter)
                {
                    victim = _random.Next(fighters.Length);
                }
                fighters[victim].Health -= fighters[fighter].Damage;
            }

            var fightersStatStr = string.Empty;
            foreach (var fighter in fighters)
            {
                fightersStatStr += $"Здоровье {fighter.Name}: {fighter.Health}. ";
            }

            Console.WriteLine(fightersStatStr);
        }
    }

    private static bool CheckFightersHealth(Fighter[] fighters)
    {
        foreach (var fighter in fighters)
        {
            if (fighter.Health <= 0)
            {
                return false;
            }
        }
        return true;
    }
}