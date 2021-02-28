using CPM.BAL;
using CPM.BAL.Helper;
using CPM.BAL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace TestingAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerDetail, CustomerDetail>();

            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}