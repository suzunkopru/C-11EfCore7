public static class AutoFacImp
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new ();
        //builder.RegisterType<Sql>().As<ISql>();
        builder.RegisterType<MySql>().As<ISql>();
        return builder.Build();
    }
}