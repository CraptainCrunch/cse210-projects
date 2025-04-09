class Weapon : Item {
    private int damageBoost;
    
    public Weapon(string name, string description, int damageBoost) : base(name, description) {
        this.damageBoost = damageBoost;
    }

    public override void Use(Player player) {
        Console.WriteLine(player.GetName() + " equips the " + name + " and gains +" + damageBoost + " attack power!");
    }
}