using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

public static class MonkeyHelper
{
    private static readonly List<Monkey> s_monkeys = new()
    {
        new Monkey
        {
            Name = "Chimpanzee",
            Habitat = "Tropical forests of Central and West Africa",
            Population = 300000,
            Size = "1.2-1.7m tall, 40-70kg",
            Diet = "Omnivore - fruits, leaves, insects, meat",
            Description = "Highly intelligent primates known for tool use and complex social behaviors.",
            AsciiArt = @"
    🐵
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Orangutan",
            Habitat = "Rainforests of Borneo and Sumatra",
            Population = 104000,
            Size = "1.2-1.5m tall, 30-90kg",
            Diet = "Primarily frugivore - fruits, leaves, bark",
            Description = "Red-haired great apes known for their intelligence and arboreal lifestyle.",
            AsciiArt = @"
    🦧
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Gorilla",
            Habitat = "Mountains and forests of Central Africa",
            Population = 200000,
            Size = "1.4-1.8m tall, 70-200kg",
            Diet = "Herbivore - leaves, stems, bark, fruits",
            Description = "Largest living primates with gentle nature despite their imposing size.",
            AsciiArt = @"
    🦍
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Baboon",
            Habitat = "Savannas and grasslands of Africa",
            Population = 500000,
            Size = "0.5-1.1m tall, 14-40kg",
            Diet = "Omnivore - fruits, seeds, leaves, roots, insects",
            Description = "Highly social primates living in large troops with complex hierarchies.",
            AsciiArt = @"
    🐒
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Macaque",
            Habitat = "Forests and mountains of Asia",
            Population = 2000000,
            Size = "0.4-0.7m tall, 5-15kg",
            Diet = "Omnivore - fruits, seeds, leaves, insects, small animals",
            Description = "Adaptable primates found across Asia, known for their intelligence.",
            AsciiArt = @"
    🐵
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Lemur",
            Habitat = "Forests of Madagascar",
            Population = 100000,
            Size = "0.3-0.7m tall, 2-9kg",
            Diet = "Primarily herbivore - fruits, leaves, nectar",
            Description = "Unique primates found only in Madagascar with distinctive calls.",
            AsciiArt = @"
    🐒
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Habitat = "Rainforests of Central and South America",
            Population = 150000,
            Size = "0.6-0.9m tall, 4-10kg",
            Diet = "Primarily herbivore - leaves, fruits, flowers",
            Description = "Known for their incredibly loud calls that can be heard up to 5km away.",
            AsciiArt = @"
    🙊
   /|\
    |
   / \"
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Habitat = "Tropical rainforests of Central and South America",
            Population = 50000,
            Size = "0.4-0.6m tall, 6-9kg",
            Diet = "Primarily frugivore - fruits, leaves, flowers",
            Description = "Agile primates with long limbs and prehensile tails for swinging through trees.",
            AsciiArt = @"
    🐒
   /|\
    |
   / \"
        }
    };

    public static List<Monkey> GetAllMonkeys()
    {
        return new List<Monkey>(s_monkeys);
    }

    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        return s_monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static Monkey GetRandomMonkey()
    {
        Random random = new();
        int index = random.Next(s_monkeys.Count);
        return s_monkeys[index];
    }
}