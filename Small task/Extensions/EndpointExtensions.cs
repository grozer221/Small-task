namespace Small_task.Extensions
{
    public static class EndpointExtensions
    {
        public static ControllerActionEndpointConventionBuilder MapHelloControllerVitalikRoute(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapControllerRoute(
                name: "helloVitalik",
                pattern: "{hello?}/{action=Index}/{id?}",
                defaults: new { controller = "HelloControllerVitalik", action = "Index" });
        }
    }
}
