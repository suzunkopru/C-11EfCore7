public class LetsWork : ISql
{
    [Dependency]
    public ISql db { get; set; }
    public string WhoAreYou() => db.WhoAreYou();
}
