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
    IMealCooker CookMainDish(string mainDish);
    IMealCooker CookSideDish(string sideDish);
    IMealCooker CookDrink(string drink);
    IMealCooker CookDessert(string dessert);
    IMeal GetMeal();
}

public interface IRichKidMealCooker : IMealCooker {
    IRichKidMealCooker CookSpecialDish(string specialDish);
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

    public IMealCooker CookMainDish(string mainDish) {
        _meal.MainDish = mainDish;
        return this;
    }

    public IMealCooker CookSideDish(string sideDisk) {
        _meal.SideDish = sideDisk;
        return this;
    }

    public IMealCooker CookDrink(string drink) {
        _meal.Drink = drink;
        return this;
    }

    public IMealCooker CookDessert(string dessert) {
        _meal.Dessert = dessert;
        return this;
    }

    //new
    public IRichKidMealCooker CookSpecialDish(string specialDish) {
        var rich_meal = _meal as RichKidMeal;
        rich_meal.SpecialDish = specialDish;
        return this;
    }

    public IMeal GetMeal() {
        return _meal;
    }
}

namespace CommonDesignPattern.Builder {
    public class Program {
        public static void Main(string[] args) {
            IRichKidMealCooker cooker = new RichKidMealCooker();
            (cooker.CookMainDish("Steak").CookSideDish("Fries").CookDrink("Coke").CookDessert("Ice Cream") as IRichKidMealCooker).CookSpecialDish("Caviar");
            var meal = cooker.GetMeal();
            meal.Review();
            System.Console.WriteLine("Next Meal");
        }
    }
}
