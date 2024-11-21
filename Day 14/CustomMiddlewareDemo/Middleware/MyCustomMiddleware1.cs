namespace CustomMiddlewareDemo.Middleware
{
    public class MyCustomMiddleware1
    {
        public readonly RequestDelegate _next;
        public MyCustomMiddleware1(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await Console.Out.WriteLineAsync("Custom  Middleware : Before Request");
            await _next(context);
            await Console.Out.WriteLineAsync("Custom Middleware : After Request");
        }
    }
}
