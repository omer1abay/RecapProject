using Autofac;
using Autofac.Extras.DynamicProxy;
using Businness.Abstract;
using Businness.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.DependencyResolvers.Autofac
{
    public class AutofacBusinnesModule:Module //Bir autofac modulü.
    {

        //Bağımlılık konfigürasyonlarımızı yapacağız..

        //Uygulama ayağa kalktığında çalışacak metot
        protected override void Load(ContainerBuilder builder)
        {
            //Birisi ITeamsService isterse TeamsManager ver..
            builder.RegisterType<TeamsManager>().As<ITeamsService>().SingleInstance(); //singleton'ın yaptığı işi yapar
            builder.RegisterType<EFTeamsDal>().As<ITeamsDal>().SingleInstance();

            builder.RegisterType<CarImagesManager>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EFCarImagesDal>().As<ICarImagesDal>().SingleInstance();
            builder.RegisterType<FileHelpers>().As<IFileHelper>().SingleInstance();


            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();

            //attribute çalıştırıyoruz.., Eğer Aspect varsa onu çalıştır ve kontrol et..
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
