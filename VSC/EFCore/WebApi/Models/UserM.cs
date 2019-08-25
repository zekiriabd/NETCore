public class UserM
    {
            public int User_Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Name {
                get { return FirstName + " " + LastName; }
            }
    }