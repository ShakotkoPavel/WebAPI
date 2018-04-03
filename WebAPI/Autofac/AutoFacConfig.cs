using Autofac;
using Autofac.Integration.WebApi;
using WebAPI.Context.ProductRepository;
using WebAPI.Context.CategoryRepository;
using System.Reflection;
using System.Web.Http;

public class AutofacConfig
{
    public static void ConfigureContainer()
    {
        // получаем экземпляр контейнера
        var builder = new ContainerBuilder();

        var config = GlobalConfiguration.Configuration;

        // регистрируем контроллер в текущей сборке
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        // регистрируем споставление типов
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

        // создаем новый контейнер с теми зависимостями, которые определены выше
        var container = builder.Build();

        // установка сопоставителя зависимостей
        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
}