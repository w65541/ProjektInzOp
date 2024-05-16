using ProjektInzOp.Service;

namespace ProjektInzOp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AuthorService>();
            serviceCollection.AddTransient<TitleService>();
            serviceCollection.AddTransient<BookService>();
            serviceCollection.AddTransient<BorrowService>();
            serviceCollection.AddTransient<ReaderService>();

            return serviceCollection;
        }
    }
}
