namespace Globomantics.Domain
{
    public record  User(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        //public string Name { get; init; }
    }
}
