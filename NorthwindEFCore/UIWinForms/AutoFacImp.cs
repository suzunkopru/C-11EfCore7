using Autofac;
using AutoMapper;

namespace UIWinForms;
public static class AutoFacImp
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new();
        builder.RegisterType<DalDtoProductCatName>()
                        .As<IDalDtoProductCatName>();
        builder.RegisterType<DalCategory>().As<IDalCategory>();
        builder.RegisterType<DalProduct>().As<IDalProduct>();
        builder.RegisterType<DalSupplier>().As<IDalSupplier>();
        builder.RegisterType<DalCustomer>().As<IDalCustomer>();
        builder.RegisterType<DalEmployee>().As<IDalEmployee>();
        builder.RegisterType<DalOrder>().As<IDalOrder>();
        builder.RegisterType<DalRegion>().As<IDalRegion>();
        builder.RegisterType<DalShipper>().As<IDalShipper>();
        builder.RegisterType<DalTerritory>().As<IDalTerritory>();
        builder.RegisterType<DalVwProdCatSup>().As<IDalVwProdCatSup>();
        builder.RegisterType<Mapper>().As<IMapper>();    
        builder.RegisterType<NorthwindContext>();
        builder.RegisterType<frmCategories>();
        builder.RegisterType<frmProdCatSup>();
        builder.RegisterType<frmProduct>();
        builder.RegisterType<frmSuppliers>();
        builder.RegisterType<Product>();
        builder.RegisterType<Mapper>().As<IMapper>();
        //EF Core  ile çalışmak istendiğinde;
        //builder.RegisterType<EFEntityRepo>().As<IEntityRepo>();
        //NHibernate ile çalışmak istendiğinde;
        //builder.RegisterType<NhEntityRepo>().As<IEntityRepo>();
        return builder.Build();
    }
}
