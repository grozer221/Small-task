using Microsoft.AspNetCore.Mvc.Razor;
using System.Text.RegularExpressions;

namespace Small_task.Extensions
{
    public class ReverseViewFolderLocationExpander : IViewLocationExpander
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

            string newControllerName = new string(context.ControllerName.ToLower().ToCharArray().Reverse().ToArray()); // lowercase and reverse
            newControllerName = Regex.Replace(newControllerName, "^[a-z]", m => m.Value.ToUpper()).ToString(); // capitalize

            return new List<string>(paths.Select(p => string.Format(p, context.ViewName, newControllerName))); ;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}
