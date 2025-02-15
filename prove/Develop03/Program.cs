using System;

class Program{
    static void Main(){
        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        while (!scripture.IsFullyHidden()){
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
                break;
            
            scripture.HideRandomWords();
        }
    }
}

class Scripture{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text){
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display(){
        Console.Write(reference.ToString() + " - ");
        Console.WriteLine(string.Join(" ", words));
    }

    public void HideRandomWords(){
        Random rand = new Random();
        int count = Math.Min(3, words.Count(w => !w.IsHidden));
        
        for (int i = 0; i < count; i++){
            List<Word> visibleWords = words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count == 0) break;
            visibleWords[rand.Next(visibleWords.Count)].Hide();
        }
    }

    public bool IsFullyHidden(){
        return words.All(w => w.IsHidden);
    }
}

class Reference{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }
    public Reference(string book, int chapter, int verse){
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse){
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString(){
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}

class Word{
    private string text;
    public bool IsHidden { get; private set; }

    public Word(string text){
        this.text = text;
        IsHidden = false;
    }

    public void Hide(){
        IsHidden = true;
    }

    public override string ToString(){
        return IsHidden ? "_____" : text;
    }
}
