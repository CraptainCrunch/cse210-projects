class GameEngine {
    private Player player;
    private Random random = new Random();

    public void StartGame()
    {
        Console.WriteLine("Enter your character's name:");
        string playerName = Console.ReadLine();
        player = new Player(playerName);

        Console.WriteLine("Welcome, " + player.GetName() + "! Your adventure begins.");

        bool playing = true;
        
        while (playing && player.GetHealth() > 0) {
            Enemy enemy = new Enemy("Goblin", 30, 10);
            Console.WriteLine("A wild " + enemy.GetName() + " appears!");

            while (player.GetHealth() > 0 && enemy.GetHealth() > 0) {
                Console.WriteLine("Choose an action: 1) Attack  2) Use Potion  3) Equip Weapon");
                string choice = Console.ReadLine();
                
                if (choice == "1") {
                    player.Attack(enemy);
                    if (enemy.GetHealth() > 0) {
                        enemy.Attack(player);
                    }
                }
                else if (choice == "2") {
                    Potion potion = new Potion("Health Potion", "Restores 20 HP", 20);
                    potion.Use(player);
                }
                else if (choice == "3") {
                    Weapon weapon = new Weapon("Sword", "A sharp blade that increases attack power.", 5);
                    weapon.Use(player);
                }
            }

            if (player.GetHealth() > 0) {
                Console.WriteLine("You defeated the enemy!");
                Item reward = GetRandomItem();
                Console.WriteLine("You found a " + reward.GetName() + "!");
                player.PickUpItem(reward);
            }
            else {
                Console.WriteLine("Game Over!");
                playing = false;
            }

            Console.WriteLine("Do you want to continue fighting? (yes/no)");
            string continueChoice = Console.ReadLine().ToLower();
            if (continueChoice != "yes") {
                playing = false;
            }
        }
    }

    private Item GetRandomItem() {
        int choice = random.Next(4);
        return choice switch {
            0 => new Potion("Health Potion", "Restores 20 HP", 20),
            1 => new Potion("Mega Potion", "Restores 50 HP", 50),
            2 => new Weapon("Sword", "A sharp blade that increases attack power.", 5),
            3 => new Weapon("Axe", "A heavy axe with devastating power.", 10),
            _ => new Potion("Health Potion", "Restores 20 HP", 20)
        };
    }
}