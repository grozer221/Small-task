using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Small_task.Extensions
{
    public class RouteVitalikPrefixConvention : IControllerModelConvention
    {
        public static readonly string _newPrefix = "ControllerVitalik";

        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.Replace(_newPrefix, string.Empty);
        }
    }
}
