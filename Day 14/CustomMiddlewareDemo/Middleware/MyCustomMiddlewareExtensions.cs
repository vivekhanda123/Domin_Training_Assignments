namespace CustomMiddlewareDemo.Middleware
{
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware1>();
        }
    }
}
