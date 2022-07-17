using BangGiaChungKhoan.BangGia_TableDependencies;

namespace BangGiaChungKhoan.MiddlewareExtendsions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseBangGiaTableDependency(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<BangGia>();
            service.BangGia_TabbleDependency();
        }
    }
}
