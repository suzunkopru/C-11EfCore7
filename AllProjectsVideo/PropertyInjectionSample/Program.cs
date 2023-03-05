#region Unity
IUnityContainer container = new UnityContainer();
var drv = container.RegisterType<ISql, Postgre>().Resolve<LetsWork>();
WriteLine(drv.WhoAreYou());
#endregion Unity

#region Autofac1
var autoFac = Configure().Resolve<ISql>();
WriteLine(autoFac.WhoAreYou());
#endregion Autofac1

#region Autofac2
ContainerBuilder builder = new();
var Conf = builder.RegisterType<Sql>().As<ISql>();
var autoFac2 = builder.Build().Resolve<ISql>();
WriteLine(autoFac2.WhoAreYou());
#endregion Autofac2
ReadLine();