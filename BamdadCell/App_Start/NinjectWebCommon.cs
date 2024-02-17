[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BamdadCell.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BamdadCell.App_Start.NinjectWebCommon), "Stop")]

namespace BamdadCell.App_Start
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Runtime.Caching;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<Repository.IServives.IUserService>().To<Repository.UserServices.UserServices>().InRequestScope();
            kernel.Bind<Repository.IServives.ISimService>().To<Repository.Services.SimServices>().InRequestScope();
            kernel.Bind<Repository.IServives.ILoginService>().To<Repository.Services.LoginServices>().InRequestScope();
            kernel.Bind<Repository.IServives.IRegisterService>().To<Repository.Services.RegisterServices>().InRequestScope();
            kernel.Bind<Repository.IServives.ISmsService>().To<Repository.Services.SmsServices>().InRequestScope();
            kernel.Bind<Repository.IServives.IChargeService>().To<Repository.Services.ChargeServices>().InRequestScope();
            kernel.Bind<Repository.IServives.IReceiptService>().To<Repository.Services.ReceiptServices>().InRequestScope();
            kernel.Bind<Repository.IServives.ICallService>().To<Repository.Services.CallServices>().InRequestScope();
           

        }
    }
}