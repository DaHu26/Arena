// TODO: Добавить меню

var fighters = new List<Fighter>
{   
    new Fighter("Макс", 20, 100), 
    new Fighter("Стас", 15, 100), 
    new Fighter("Артем", 21, 100), 
};

var arena1 = new Arena(3);
arena1.Fight(fighters);
var car = 1;