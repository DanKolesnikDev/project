
//Starting values
using System.Diagnostics;
using System.Linq;

string? characterName;
string[] characterAtributes = {"Strenght", "Dexterty", "Constitution", "Intilligence", "Wisdom", "Charisma"};
int [] characterAtributesValue = {0, 0, 0, 0, 0, 0};
int weaponFind = 0;

//Dice roll
Random dice = new Random();

//Welcome script
Console.WriteLine("Welcome to Vilejka surrvival game!");
Console.ReadLine();

/*
Character creation:
Roles name must be betven 3 and 16 characters,
*/

Console.WriteLine("Let create your character");

Console.WriteLine("Write Your character Name:");

bool valid = false;

do{
   

    characterName = Console.ReadLine();

    if (characterName.Any(char.IsDigit))
    {
        Console.WriteLine("Your name must not contain numbers.\nType again");
    }
    else if (characterName.Length < 3)
    {
        Console.WriteLine($"You entered {characterName.Length} letters, your name must contain at least 3 leters.\nType again");
    }
    else if (characterName.Length > 16)
    {
        Console.WriteLine($"You entered {characterName.Length}letters, your name must contain no more than 16 letters\nType again");
    }
    else
    {
        Console.WriteLine($"The mighty {characterName} was born to this world");
        valid = true;
    }
} while (!valid);

/*
Character generates random atribute values from rool 4 six-sided dice,
discarding the lowest result, and then summing the remaining tree dice.
*/

Console.WriteLine("Lets roll Your starting attributes");
Console.ReadLine();
int i = 0;
int j = 0;
foreach (string attributeName in characterAtributes )
{
    int attributeSumm = 0;
    int[] diceRoll = [0, 0, 0, 0];
    
    for (i=0; i<4; i++)
    {
        diceRoll[i] = dice.Next(1, 7);
        attributeSumm += diceRoll[i];
    }

    int minimumRoll = diceRoll.Min();
    characterAtributesValue[j] = attributeSumm- minimumRoll;
    j++;
   
    Console.WriteLine($"Your {attributeName} will be {attributeSumm} points.");
    Console.ReadLine();

}

//Maximum value from atributs determinate witch class you will be.

int characterAttributeMaxValue = characterAtributesValue.Max();
int characterAttributeMaxPosition = Array.IndexOf(characterAtributesValue, characterAttributeMaxValue);

switch (characterAttributeMaxPosition)
{
    case 0:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[0]} {characterAttributeMaxValue} points.\nYou class are Aspirant Warrior {characterName}!");
        break;

    case 1:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[1]} {characterAttributeMaxValue} points.\nYou class are Stealthy Thief {characterName}!");
        break;

    case 2:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[2]} {characterAttributeMaxValue} points.\nYou class are Big HP Tank {characterName}!");
        break;

    case 3:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[3]} {characterAttributeMaxValue} points.\nYou class are Apprentice Wizzard {characterName}!");
        break;

    case 4:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[4]} {characterAttributeMaxValue} points.\nYou class are Acolyte Cleric {characterName}!");
        break;

    default:
        Console.WriteLine($"Your Maximum atribute is {characterAtributes[5]} {characterAttributeMaxValue} points.\nYou class are Drunk Bard {characterName}!");
        break;
}

//Calculating main stats for character
int characterLevel = 1;
int characterHealth = characterAtributesValue[2] * 10;
int characterMana = characterAtributesValue [4] * 10;
int characterStamina = characterAtributesValue [1] * 10;
int characterArmor = characterAtributesValue[2] + (characterAtributesValue [1] / 2);
int characterMinimumPhisicalDamage = (characterAtributesValue [0]+ (characterAtributesValue[1] / 2)) / 4 * 3;
int characterMaximumPhisicalDamage = (characterAtributesValue [0]+ (characterAtributesValue[1] / 2)) / 4 * 5;
int characterMinimumMagicDamage = (characterAtributesValue [3]+ (characterAtributesValue[4] / 2)) / 3;
int characterMaximumMagicalDamage = (characterAtributesValue [3]+ (characterAtributesValue[4] / 2)) / 3 * 4;

//Monster Drunk Vadim stats
int monsterDrunkVadimHealth = 420;
string monsterNameDrunkVadim = "Monster Drunk Vadim";



Console.WriteLine($"\n\nYour character Level is: {characterLevel}\n\nYour main stas will be:\n\nHitpoints:\t\t{characterHealth}\nMana:\t\t\t{characterMana}\nStamina:\t\t{characterStamina}\nArmor:\t\t\t{characterArmor}\nPhysical Damage:\t{characterMinimumPhisicalDamage} - {characterMaximumPhisicalDamage}\nMagical Damage:\t\t{characterMinimumMagicDamage} - {characterMaximumMagicalDamage}\n");



Console.WriteLine("Ready for adventure!");
Console.ReadLine();

Console.WriteLine("You open your eyes, it's dark outside and raining.\nYou feel pain in your head.");
Console.ReadLine();

string[] shopName = ["Maxima", "Norfa", "Iki", "Lidl"];
Console.WriteLine($"You look on the right side there is a suspicious {shopName[dice.Next(0, 3)]} shoping bag on the ground.");
Console.ReadLine();

string[] itemsInsideBag = ["Broken Utenos Bottle", "Stick with nail", "Cherep", "Broken brick", "Piaggio carburetor on rope"];

weaponFind = dice.Next(0, 5);
Console.WriteLine($"You reached this bag and find inside {itemsInsideBag[weaponFind]}\nYou will use it as weapon from now.");
Console.ReadLine();

Console.WriteLine($"You hear LOUD sound, and see {monsterNameDrunkVadim} is going toward you.");
Console.ReadLine();

Console.WriteLine($"{monsterNameDrunkVadim} shouts: Pakurit ne najdetsa.\nThis is his Battle shout.\nYou attacked him first!\n{monsterNameDrunkVadim} has {monsterDrunkVadimHealth} Hitpoints.\nGET READY!");
Console.ReadLine();


int characterDamage = 0;
int monsterDamage = 0;
do
{
   characterDamage = dice.Next(characterMinimumPhisicalDamage, characterMaximumPhisicalDamage);
   monsterDamage = dice.Next(1, 5);
   characterHealth -= monsterDamage;
   monsterDrunkVadimHealth -= characterDamage;

   Console.WriteLine($"You damaged {monsterNameDrunkVadim} {characterDamage} and he left with {monsterDrunkVadimHealth} Hitpoints");

    if(monsterDrunkVadimHealth > 0)
    {
   Console.WriteLine($"{monsterNameDrunkVadim} damaged you {monsterDamage} and You left with {characterHealth} Hitpoints");
   Console.ReadLine();
    }   


    
} while (characterHealth >0 && monsterDrunkVadimHealth >0 );

if(characterHealth > monsterDrunkVadimHealth) 
{
    Console.WriteLine("You win the fight");
}  
else 
    Console.WriteLine("You loose the fight");

    Console.ReadLine();
    


