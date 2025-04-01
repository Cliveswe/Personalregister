namespace PersonalRegisterMain
{
    internal class PersonalRegister
    {

        /// <summary>
        /// A structure that hold the Christian name and Surname of a person.
        /// </summary>
        struct Person
        {
            public Person()
            {
                ChristianName = Surname = string.Empty;
            }//constructor
            public Person(string firstName, string lastName, int pay)
            {
                ChristianName = firstName.Trim();
                Surname = lastName.Trim();
                Pay = pay;
            }//constructor

            public string ChristianName { get; }
            public string Surname { get; }

            public int Pay { get; }

            public override string ToString() => $"{ChristianName} {Surname} {Pay}";

        }//struct

        //A collection of restaurant staff.
        private List<Person> employeesList;


        /// <summary>
        /// Class constructor that initiates a collection of restaurant staff.
        /// </summary>
        public PersonalRegister()
        {

            employeesList = new List<Person>();
        }

        /// <summary>
        /// Entry point of the application.
        /// </summary>
        internal void Start()
        {
            bool exitProgram = false;
            string getUserInput;
            int menuChoice = 3;

            //Run the application until the user chooses a menu option to exit.
            while (!exitProgram)
            {
                //Prompt the use for a menu option.
                DisplayMenu();
                DisplayInputCommand();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                getUserInput = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                //execute a menu choice
                if (int.TryParse(getUserInput, out menuChoice))
                {

                    menuChoice = int.Parse(getUserInput);
                }
                else
                {
                    Console.WriteLine("You did not enter a valid choice!\n");
                    continue;
                }

                exitProgram = RunMenuChoice(exitProgram, menuChoice);

            }//while

        }//Start

        /// <summary>
        /// Execute the entered menu choice. 
        /// </summary>
        /// <param name="exitProgram">boolean true to exit the application otherwise false</param>
        /// <param name="menuChoice">User input to select a menu option.</param>
        /// <returns></returns>
        private bool RunMenuChoice(bool exitProgram, int menuChoice)
        {
            switch (menuChoice)
            {
                case 1://add a new staff member

                Person newPerson;
                Console.WriteLine("\nEnter the name of the new staff member.");
                if (GetNewStaffMember(out newPerson))
                {
                    employeesList.Add(newPerson);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You must enter both Christan and Surname!");
                }
                break;
                case 2://display all staff members

                Console.WriteLine("\nList of all staff members.");
                DisplayAllStaffMembers();
                Console.WriteLine();
                break;
                case 3://exit program

                Console.WriteLine("\nBye!");
                exitProgram = true;
                break;
                default:

                Console.WriteLine("\nNot a valid menu choice!\n");
                break;
            }//switch

            return exitProgram;
        }//RunMenuChoice

        /// <summary>
        /// Display the collection of staff members.
        /// </summary>
        private void DisplayAllStaffMembers()
        {
            if (employeesList.Count > 0)
            {
                foreach (Person person in employeesList)
                {

                    Console.WriteLine(person.ToString());
                }
            }
            else
            {

                Console.WriteLine("There are no members of staff.");
            }
            Console.WriteLine();

        }//DisplayAllStaffMembers

        /// <summary>
        /// Get the Christian name and Surname from the user.
        /// </summary>
        /// <param name="person">A person structure the holds the person Christian name and Surname.</param>
        /// <returns>true if the user inputed the names correctly otherwise false.</returns>
        private bool GetNewStaffMember(out Person person)
        {
            bool isNewPerson = false;
            person = new Person();
            int pay = 0;

            Console.Write("Enter Christian name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string firstName = Console.ReadLine();

            Console.Write("Enter Surname: ");
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Console.Write("Enter pay: ");
            pay = int.Parse(Console.ReadLine());


            if (firstName != null || lastName != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                person = new Person(firstName, lastName, pay);
#pragma warning restore CS8604 // Possible null reference argument.
                isNewPerson = true;
            }

            return isNewPerson;

        }//GetNewStaffMember

        /// <summary>
        /// Display instructions to the user.
        /// </summary>
        private void DisplayInputCommand() => Console.Write("\nEnter menu choice: ");
        private void DisplayMenu()
        {
            Console.WriteLine("********* Restaurant staff ****************");
            Console.WriteLine("\t1: Add staff member.");
            Console.WriteLine("\t2: Display all staff.");
            Console.WriteLine("\t3: Exit program.");
            Console.WriteLine("*******************************************\n");
        }//DisplayMenu

    }//class
}//namespace