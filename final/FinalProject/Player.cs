class Player : Character {
    private List<Item> inventory = new List<Item>();
    private int experience;

    public Player(string name) : base(name, 50, 10) {
        experience = 0;
    }

    public override void Attack(Character target) {
        Console.WriteLine(name + " attacks " + target.GetName() + " for " + attackPower + " damage!");
        target.TakeDamage(attackPower);
        GainExperience(10);
    }

    public void PickUpItem(Item item) {
        inventory.Add(item);
        Console.WriteLine(name + " picked up " + item.GetName() + "!");
    }

    public void GainExperience(int amount) {
        experience += amount;
        Console.WriteLine(name + " gained " + amount + " experience points!");
    }

    public int GetExperience() { return experience; }

    public void ShowInventory() {
        Console.WriteLine("Inventory:");
        if (inventory.Count == 0) {
            Console.WriteLine("  (empty)");
        }
        else {
            foreach (var item in inventory) {
                Console.WriteLine("  " + item.GetName());
            }
        }
    }
}