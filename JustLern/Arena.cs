public class Arena
{
    public int Size;
    private Random _random;

    public Arena(int size)
    {
        Size = size;
        _random = new Random();
    }

    public void Fight(IEnumerable<Fighter> fightersArg)
    {
        var fighters = fightersArg.ToArray();
        CheckArgs(fighters);

        while (CheckFightersHealth(fighters))
        {
            for (int i = 0; i < Size; i++)
            {
                var fighterId = _random.Next(fighters.Length);
                int victimId;
                do
                {
                    victimId = _random.Next(fighters.Length);
                }
                while (victimId == fighterId);

                fighters[victimId].Health -= fighters[fighterId].Damage;
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

    private void CheckArgs(Fighter[] fighters)
    {
        if (Size < fighters.Length)
            throw new ArgumentException("Ошибка, введите количество бойцов не превышающее слотов арены");
    }
}