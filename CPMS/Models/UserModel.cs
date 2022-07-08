namespace CPMS.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string FieldOfStudy { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HighestDegree { get; set; }
        public int YearsInField { get; set; }
        public int PublishedPapers { get; set; }
        public int ReviewedPapers { get; set; }
        public string Gender { get; set; }

    }
}
