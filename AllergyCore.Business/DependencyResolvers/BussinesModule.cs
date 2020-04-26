using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Business.Services.Concrete;
using AllergyCore.Business.ValidationRules;
using AllergyCore.Core.Aspects.Validation;
using AllergyCore.Core.Interceptors;
using AllergyCore.Repository.Abstract;
using AllergyCore.Repository.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Business.DependencyResolvers
{
    public class BussinesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();
            builder.RegisterType<FoodRepository>().As<IFoodRepository>().SingleInstance();

            builder.RegisterType<AllergyManager>().As<IAllergyService>();
            builder.RegisterType<AllergyRepository>().As<IAllergyRepository>();


            builder.RegisterType<IngredientManager>().As<IIngredientService>()
                //Manuel aspect register için bu şekilde yazıyoruz.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()).InterceptedBy(typeof(ValidationAspect));
            builder.RegisterType<IngredientRepository>().As<IIngredientRepository>();

            builder.RegisterType<MaterialManager>().As<IMaterialService>();
            builder.RegisterType<MaterialRepository>().As<IMaterialRepository>();


            builder.Register(c => new ValidationAspect(typeof(IngredientValidator)));

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new InterceptorSelector()
            //    }).SingleInstance();


        }
    }
}
