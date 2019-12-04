namespace PageObjectExample
{
    internal class ExampleNote
    {
        public ExampleNote()
        {
            Title = Faker.Lorem.Sentence();
            Content = Faker.Lorem.Paragraph();
        }

        public string Title { get; }
        public string Content { get; }
    }
}