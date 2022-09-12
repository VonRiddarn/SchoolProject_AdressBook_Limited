/*NOTES
This code is written as part of a school project.
The challange given by the teacher was to add a set of functionalities WITHOUT utilizing:
	* Classes
	* Interfaces
	* Lists
	* Methods
With these limitations it's hard to write clean code, but I believe I did a good enough job.
If you want to have a look at the code without all the tutorial comments this repo includes a file called:
	Program_NoComments.cs
*/

// Global scope inputs
ConsoleKey input = ConsoleKey.NoName;

// Global scope user ""database""
string[] userRegistry = new string[0];


// Application runtime loop (Aka Main loop)
while (true)
{
	// Main menu loop
	// Will need to run everytime the application loop restarts.
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
		else if(input == ConsoleKey.D4)
			Environment.Exit(0);
	}
	
	// Using if -> Else if is the basically the exact same as using a switch.
	// The diffrence is that a switch is a nasty piece of syntax 
	// that can decrease readability if used wrong. - Totally not opinion based!
	
	// ----- ADD USER -----
	if(input == ConsoleKey.D1)
	{	
		// This loop will run until it breaks out of itself with internal logic.
		while(true)
		{
			// Create a local variable for checking if a name is valid.
			// We begin by assuming all input is valid.
			// If we are proven wrong we will change this in the conditional statements (aka if statements).
			bool validName = true;
			
			// We don't want lots of spaces between names, so we track them.
			// Setting this to a random letter as it doesn't matter yet.
			char previousCharacter = 'a';
			
			// Fancy menu!
			Console.Clear();
			Console.WriteLine("Name criteria");
			Console.WriteLine("* " + "Can't be empty");
			Console.WriteLine("* " + "Can't start or end with space");
			Console.WriteLine("* " + "Can only contain letters");
			Console.WriteLine();
			Console.WriteLine("Enter a name: ");
			string name = Console.ReadLine();
			
			// Check the name for any invalidations.
			// If found, set validName to false.
			// ----------------------------------
			// Is the name empty?
			if(name.Length <= 0)
				validName = false;
			// Does the name start with space?
			if(name.StartsWith(' '))
				validName = false;
				
			// Does the name end with space?
			if(name.EndsWith(' '))
				validName = false;
				
			// Are there any numbers in the name?
			foreach(char character in name)
			{
				// If the previous character in the loop was a space, and this character is also a space
				// We have 2 spaces in a row between the name, that's not valid.
				// This prevents the user from entering something like:
				// "Von                  Riddarn"
				if(previousCharacter == ' ' && character == ' ')
					validName = false;
				
				// Check if the character is not a letter AND not a space
				// Because spaces are okay, just not in the beginning and end of the name.
				if(!char.IsLetter(character) && character != ' ')
					validName = false;
					
				// End of this loop.
				// Set the previousCharacter to the character we just looked at.
				previousCharacter = character;
			}
			// -------------------------------------
			
			// Check id the name is still valid.
			// If the name is still valid, no conditions in the namecheck has been true.
			if(validName)
			{
				// We can't change the size of an array directly.
				// Therefore we create a new temporary array, and set its size to the database + 1.
				string[] tempUserRegistry = new string[userRegistry.Length + 1];
				
				// Loop through the original database and add all elements to the new temp array:
				for(int i = 0; i < userRegistry.Length; i++)
				{
					// At index i: Add the database element to the temp array.
					tempUserRegistry[i] = userRegistry[i];
				}
				
				// Now we have added all the old users from the database to the temp array.
				// However, since the temp array is 1 longer than the database we have 1 empty slot at the end.
				// Here we add our new user with the name that was valid:
				// We use tempUserRegistry - 1 because the array length is always 1 bigger than the index 
				// (because arrays start at index 0, not 1)
				tempUserRegistry[tempUserRegistry.Length - 1] = name; 
				
				// Finally we replace the original database with the temporary array:
				userRegistry = tempUserRegistry;
				
				// Since the name is valid and we have added it to the database
				// We also need to exit this while loop so we don't just add names for the rest of our lives.
				break;
			}
			
			// If the name is not valid, the while loop will reach its end here
			// That means that it will restart from the top, where we have "Fancy menu".
		}
	}
	// ----- END OF ADD USER -----
	
	
	// ----- SHOW ALL -----
	else if(input == ConsoleKey.D2)
	{
		// Some meny stuff. Fancy!
		Console.Clear();
		Console.WriteLine("~~ All registered users ~~");
				
		// List all the names in the user registry ("the database")
		for(int i = 0; i < userRegistry.Length; i++)
		{
			// Array index starts at 0, so i + 1 will show 1234 instead of 0123.
			Console.WriteLine((i + 1) + " : " + userRegistry[i]);
		}
		
		// Pause the application until the user presses any key.
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey(); 
		
		// When the user press a key, there is nothing more to do in this if statement.
		// We will go back to the application loop that eventually leads back to the menu.
	}
	// ----- END OF SHOW ALL -----
	
	
	// ----- CLEAR LIST -----
	else if(input == ConsoleKey.D3)
	{
		// Create a bool to confirm user choise
		bool confirm = false;
		
		while(true)
		{
			// Fancy menu!
			Console.Clear();
			Console.WriteLine("~~ ARE YOU SURE YOU WANT TO CLEAR THE LIST? ~~");
			Console.WriteLine("Y / N");
			
			// Here we could reuse the global input key as it is not important for the rest of the program.
			// For readability however, we will create a new one.
			ConsoleKey confirmKey = Console.ReadKey().Key;
			
			// If we press yes OR no
			if(confirmKey == ConsoleKey.Y || confirmKey == ConsoleKey.N)
			{
				
				// If the key we pressed was yes, we want to set confirm to true.
				if(confirmKey == ConsoleKey.Y)
					confirm = true;
				
				// Since we pressed either yes or no, we have made a choice
				// Therefore break out of the loop.
				break;
			}
			
		}
		
		// We can't change the size of arrays, so we need to set the database to a new empty array.
		// But ONLY if we wanted to do that, therefore we check if confirm has been set to true.
		if(confirm)
			userRegistry = new string[0];
			
		// There is nothing left to do, so we go back to the application loop.
		// As you can see below the application loop reaches its end, and therefore goes back to the top.
	}
	// ----- END OF CLEAR LIST -----
	
	// Here we reach the end of the application loop.
	// // Since there is nothing more to do it will go back up and rerun from line 9.
}
// Lägg till
// Visa alla
// Rensa
// Avsluta