using Autofac;
using Core.Helper;

namespace UIWinForms;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        var mapping = new MappingProfiles();
        var map = mapping.MatcMap();
        ApplicationConfiguration.Initialize();
        Application.Run(new frmProduct(
            Configure().Resolve<IDalProduct>(),
            Configure().Resolve<IDalDtoProductCatName>(),
            Configure().Resolve<IDalCategory>(),
            Configure().Resolve<IDalSupplier>(),
            Configure().Resolve<IDalVwProdCatSup>(),
            //Configure().Resolve<frmCategories>(),
            //Configure().Resolve<frmProdCatSup>(),
            //Configure().Resolve<frmSuppliers>(),
            Configure().Resolve<Product>(),
            new MappingProfiles().MatcMap()));
    }
}