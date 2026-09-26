namespace sb.api.Library.Persistence.Seeds
{
    public interface IDataSeeder
    {
        int Order { get; }

        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
