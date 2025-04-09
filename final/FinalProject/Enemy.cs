class Enemy : Character {
    public Enemy(string name, int health, int attackPower) : base(name, health, attackPower) {}

    public override void Attack(Character target) {
        Console.WriteLine(name + " attacks " + target.GetName() + " for " + attackPower + " damage!");
        target.TakeDamage(attackPower);
    }
}