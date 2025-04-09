abstract class Item {
    protected string name;
    protected string description;
    
    public Item(string name, string description) {
        this.name = name;
        this.description = description;
    }
    
    public abstract void Use(Player player);
    public string GetName() { return name; }
}