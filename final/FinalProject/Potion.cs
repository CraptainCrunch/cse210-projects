class Potion : Item {
    private int healAmount;
    
    public Potion(string name, string description, int healAmount) : base(name, description) {
        this.healAmount = healAmount;
    }
    
    public override void Use(Player player) {
        Console.WriteLine(player.GetName() + " uses " + name + " and heals " + healAmount + " HP!");
    }
}