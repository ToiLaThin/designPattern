public interface IMeal {
    string MainDish { get; set; }
    string SideDish { get; set;}
    string Drink { get; set; }
    string Dessert { get; set; }
    void Review();
}
public interface IRichKidMeal : IMeal {
    string SpecialDish { get; set; }
}

public interface IMealCooker {
    void CookMainDish(string mainDish);
    void CookSideDish(string sideDish);
    void CookDrink(string drink);
    void CookDessert(string dessert);
    IMeal GetMeal();
}

public interface IRichKidMealCooker : IMealCooker {
    void CookSpecialDish(string specialDish);
}

public class RichKidMeal : IRichKidMeal {
    public string MainDish { get; set; }
    public string SideDish { get; set; }
    public string Drink { get; set; }
    public string Dessert { get; set; }

    //new
    public string SpecialDish { get; set; }

    public void Review()
    {
        Console.WriteLine("Main Dish: {0}", MainDish);
        Console.WriteLine("Side Dish: {0}", SideDish);
        Console.WriteLine("Drink: {0}", Drink);
        Console.WriteLine("Dessert: {0}", Dessert);
        Console.WriteLine("Special Dish: {0}", SpecialDish);
    }
}

public class NormalMeal : IMeal {
    public string MainDish { get; set; }
    public string SideDish { get; set; }
    public string Drink { get; set; }
    public string Dessert { get; set; }

    public void Review()
    {
        Console.WriteLine("Main Dish: {0}", MainDish);
        Console.WriteLine("Side Dish: {0}", SideDish);
        Console.WriteLine("Drink: {0}", Drink);
        Console.WriteLine("Dessert: {0}", Dessert);
    }
}

public class RichKidMealCooker : IMealCooker, IRichKidMealCooker {
    private IMeal _meal = new RichKidMeal();

    public void CookMainDish(string mainDish) {
        _meal.MainDish = mainDish;
    }

    public void CookSideDish(string sideDisk) {
        _meal.SideDish = sideDisk;
    }

    public void CookDrink(string drink) {
        _meal.Drink = drink;
    }

    public void CookDessert(string dessert) {
        _meal.Dessert = dessert;
    }

    //new
    public void CookSpecialDish(string specialDish) {
        var rich_meal = _meal as RichKidMeal;
        rich_meal.SpecialDish = specialDish;
    }

    public IMeal GetMeal() {
        return _meal;
    }
}

namespace CommonDesignPattern.Builder {
    public class Program {
        public static void Main(string[] args) {
            IRichKidMealCooker cooker = new RichKidMealCooker();
            cooker.CookMainDish("Steak");
            cooker.CookSideDish("Fries");
            cooker.CookDrink("Coke");
            cooker.CookDessert("Ice Cream");
            cooker.CookSpecialDish("Caviar");

            var meal = cooker.GetMeal();
            meal.Review();
            System.Console.WriteLine("Next Meal");
        }
    }
}
