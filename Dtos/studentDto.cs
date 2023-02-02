namespace ArishProject.Dtos
{
  
        public record StudentDto
        {
            public string Id { get; init; }
            public string NameEn { get; init; }
            public string NameAr { get; init; }
            public string Grade { get; init; }
            public string Department { get; set; }

        }
    
}
