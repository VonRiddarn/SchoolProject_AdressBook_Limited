/*
This code will throw an error if you download the entire project.
That's because this code is utiliszing .net6.0 automatic mainframe encapsulation.
Meaning the program doesn't know if it should wrap this file (Program_NoComments.cs) or Program.cs

Either comment this entire document out or delete it.
(You could also comment out or delete Program.cs instead)
*/

// Global scope inputs
ConsoleKey input = ConsoleKey.NoName;

// Global scope user ""database""
string[] userRegistry = new string[0];

// Application / Runtime loop
while (true)
{
	// Main loop
	while (true)
	{
		Console.Clear();
		Console.WriteLine("~~ Adress Book ~~");
		Console.WriteLine("[ 1 ] Add user");
		Console.WriteLine("[ 2 ] Show all users");
		Console.WriteLine("[ 3 ] Clear user list");
		Console.WriteLine("[ 4 ] Exit application");
		input = Console.ReadKey().Key;

		if (input == ConsoleKey.D1 || input == ConsoleKey.D2 || input == ConsoleKey.D3)
			break;
		else if (input == ConsoleKey.D4)
			Environment.Exit(0);
	}

	// Submenus
	// ----- ADD USER -----
	if (input == ConsoleKey.D1)
	{
		while (true)
		{
			bool validName = true;
			char previousCharacter = 'a';

			// Menu
			Console.Clear();
			Console.WriteLine("Name criteria");
			Console.WriteLine("* " + "Can't be empty");
			Console.WriteLine("* " + "Can't start or end with space");
			Console.WriteLine("* " + "Can only contain letters");
			Console.WriteLine();
			Console.WriteLine("Enter a name: ");
			string name = Console.ReadLine();


			// ----- NAME VALIDATION -----
			// Empty?
			if (name.Length <= 0)
				validName = false;

			// Start or end with space?
			if (name.StartsWith(' ') || name.EndsWith(' '))
				validName = false;

			// Numbers?
			foreach (char character in name)
			{
				if (previousCharacter == ' ' && character == ' ')
					validName = false;

				if (!char.IsLetter(character) && character != ' ')
					validName = false;

				previousCharacter = character;
			}
			// ----- END OF NAME VALIDATION -----

			if (validName)
			{
				string[] tempUserRegistry = new string[userRegistry.Length + 1];

				for (int i = 0; i < userRegistry.Length; i++)
					tempUserRegistry[i] = userRegistry[i];

				tempUserRegistry[tempUserRegistry.Length - 1] = name;
				userRegistry = tempUserRegistry;

				break;
			}
		}
	}
	// ----- END OF ADD USER -----


	// ----- SHOW ALL -----
	else if (input == ConsoleKey.D2)
	{
		Console.Clear();
		Console.WriteLine("~~ All registered users ~~");

		for (int i = 0; i < userRegistry.Length; i++)
			Console.WriteLine((i + 1) + " : " + userRegistry[i]);

		Console.WriteLine("Press any key to continue...");
		Console.ReadKey();
	}
	// ----- END OF SHOW ALL -----


	// ----- CLEAR LIST -----
	else if (input == ConsoleKey.D3)
	{
		bool confirm = false;

		while (true)
		{
			// Fancy menu!
			Console.Clear();
			Console.WriteLine("~~ ARE YOU SURE YOU WANT TO CLEAR THE LIST? ~~");
			Console.WriteLine("Y / N");

			ConsoleKey confirmKey = Console.ReadKey().Key;

			// If we press yes OR no
			if (confirmKey == ConsoleKey.Y || confirmKey == ConsoleKey.N)
			{
				if (confirmKey == ConsoleKey.Y)
					confirm = true;

				break;
			}
		}

		if (confirm)
			userRegistry = new string[0];
	}
}
