namespace SimpleSubmit.Models
{
    public class InsertUserResult
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public DateTimeOffset ServerTimeStamp { get; set; }
    }
}
