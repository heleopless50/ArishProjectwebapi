namespace ArishProject.Entities
{
    public record Student
    {
        public string Id { get; init; }
        public string NameEn { get; init; }
        public string NameAr { get; init; }
        public string Grade { get; init; }
        public string Department { get; set; }

    }
}
