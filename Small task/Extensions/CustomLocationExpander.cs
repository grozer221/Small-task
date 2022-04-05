using Microsoft.AspNetCore.Mvc.Razor;
using System.Text.RegularExpressions;

namespace Small_task.Extensions
{

    public class CustomLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            /* Parameters:
             * {2} - Area Name
             * {1} - Controller Name
             * {0} - View Name
             */
            List<string> paths = new List<string> 
            {
                "/Views/{1}/{0}.cshtml",
                "/Views/Shared/{0}.cshtml",
            };

            string newControllerName = context.ControllerName.Replace("ControllerVitalik", "");
            newControllerName = new string(newControllerName.ToLower().ToCharArray().Reverse().ToArray()); // lowercase and reverse
            newControllerName = Regex.Replace(newControllerName, "^[a-z]", m => m.Value.ToUpper()).ToString(); // capitalize

            var combinedPaths = new List<string>(paths.Select(p => string.Format(p, context.ViewName, newControllerName, "")));
            combinedPaths.AddRange(paths);
            return combinedPaths;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}
