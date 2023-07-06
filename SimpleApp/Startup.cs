using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // AddMvc - додає послуги, необхідні для роботи MVC, включаючи Razor-сторінки
            // services.AddMvc();

            // AddControllersWithViews - додає послуги, необхідні для роботи MVC,
            // Не включаючи Razor-сторінки - тільки контролери та уявлення.
            // Для прикладів цього курсу цього достатньо.
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=List}/{id?}");
                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "Products/ListCategory/{id?}",
                    defaults: new { controller = "Products", action = "ListCategory" });
            });


            // {id?} - цей фрагмент шаблону описує не обов'язковий сегмент на адресу запиту.
            // При цьому в контролерах на ім'я id можна буде отримати інформацію, яка надійшла в запиті
            // Products/Details/10
            // {controller} = Products
            // {action} = Details
            // {id} = 10
        }
    }
}
