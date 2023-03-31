
using System.Drawing;
using System;

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

            var firstFighter = _random.Next(0, fighters.Length);
            var secondFighter = _random.Next(0, fighters.Length);
            var thirdFighter = _random.Next(0, fighters.Length);

            var firstVictim = _random.Next(0, fighters.Length);
            var secondVictim = _random.Next(0, fighters.Length);
            var thirdVictim = _random.Next(0, fighters.Length);

            while (firstVictim == firstFighter)
            {
                firstVictim = _random.Next(0, fighters.Length);
            }

            while (secondVictim == secondFighter)
            {
                secondVictim = _random.Next(0, fighters.Length);
            }

            while (thirdVictim == thirdFighter)
            {
                thirdVictim = _random.Next(0, fighters.Length);
            }

            fighters[firstVictim].Health -= fighters[firstFighter].Damage;
            fighters[secondVictim].Health -= fighters[secondFighter].Damage;
            fighters[thirdVictim].Health -= fighters[thirdFighter].Damage;
            Console.WriteLine($"Здоровье Макса: {fighters[0].Health}, здоровье Стаса: {fighters[1].Health}, здоровье Артема: {fighters[2].Health}");
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