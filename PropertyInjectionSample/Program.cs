using static System.Console;
using Unity;

IUnityContainer container = new UnityContainer();
var drv = container.RegisterType<ISql, Postgre>().Resolve<LetsWork>(); ;
WriteLine(drv.WhoAreYou());
ReadLine();
public interface ISql
{
    public string WhoAreYou();
}
public class Sql: ISql
{
    public string WhoAreYou() => "Merhaba SQL Server";
}

public class Postgre : ISql
{
    public string WhoAreYou() => "Merhaba Postgre SQL";
}
public class LetsWork : ISql
{
    [Dependency]
    public ISql db { get; set; }
    public string WhoAreYou() => db.WhoAreYou();
}