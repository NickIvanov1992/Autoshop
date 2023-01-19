using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
// незадействован
namespace Store.EF
{
    public class CofigString
    {
        private IConfigurationRoot configurationRoot;
        public CofigString(IHostingEnvironment hostingEnvironment)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
    }
}
