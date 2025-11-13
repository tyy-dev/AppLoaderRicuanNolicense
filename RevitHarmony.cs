using Autodesk.Revit.UI;
using HarmonyLib;
using System.Diagnostics;
using System.Reflection;
using System.Security.AccessControl;

namespace RevitHarmony;

public class PatchAppLoaderLicense : IExternalApplication
{
    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    public Result OnStartup(UIControlledApplication application)
    {
        AppDomain.CurrentDomain.AssemblyLoad += (sender, args) =>
        {
            if (args.LoadedAssembly.GetName().Name.Equals("ricaun.AppLoader", StringComparison.OrdinalIgnoreCase))
                AppLoaderLicensePatch.ApplyPatch();
            
        };
        return Result.Succeeded;
    }
}