using Autofac;
namespace UIWinForms;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmProduct(
            Configure().Resolve<IDalProduct>(),
            Configure().Resolve<IDalDtoProductCatName>(),
            Configure().Resolve<IDalCategory>(),
            Configure().Resolve<IDalSupplier>(),
            Configure().Resolve<IDalVwProdCatSup>(),
            Configure().Resolve<frmCategories>(),
            Configure().Resolve<frmProdCatSup>(),
            Configure().Resolve<frmSuppliers>(),
            Configure().Resolve<Product>()));
    }
}