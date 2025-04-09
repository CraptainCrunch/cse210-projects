abstract class Character {
    protected string name;
    protected int health;
    protected int attackPower;

    public Character(string name, int health, int attackPower) {
        this.name = name;
        this.health = health;
        this.attackPower = attackPower;
    }

    public abstract void Attack(Character target);
    
    public void TakeDamage(int damage) {
        health -= damage;
        if (health < 0) health = 0;
    }

    public string GetName() { return name; }
    public int GetHealth() { return health; }
}