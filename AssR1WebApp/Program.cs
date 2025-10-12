namespace AssR1WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //ay 7&8
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  //midleware
            #region Custom Pipline
            //inline Midddlware
            //app.Use(async(httpContext,next) => {
            //    //httpContext.Request.metho
            //    await httpContext.Response.WriteAsync("1) Middleware 1 \n");
            //    //invoke next middleware
            //    await next.Invoke();//<--
            //    //Execute
            //    await httpContext.Response.WriteAsync("1-1) Middleware 1-1 \n");


            //});
            //app.Use(async (httpContext, next) => {
            //    //httpContext.Request.metho
            //    await httpContext.Response.WriteAsync("2) Middleware 2 \n");
            //    //invoke next middleware
            //    await next.Invoke();//<--
            //    //Execute
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2-2 \n");

            //});

            //app.Run(async(httpcontxt) => {
            //    await httpcontxt.Response.WriteAsync("3) Terminate \n");
            //});

            #endregion



            #region Built in PipleLine
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
