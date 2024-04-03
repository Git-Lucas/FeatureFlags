namespace FeatureFlags;

public record User
{
    public Guid Id { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = SetDateTime();
    }

    private DateTime SetDateTime()
    {
        DateTime minimunDate = new(2020, 1, 1);
        DateTime maximunDate = new(2023, 12, 31);

        int rangeInDays = (maximunDate - minimunDate).Days;

        return minimunDate.AddDays(new Random().Next(rangeInDays));
    }
}
