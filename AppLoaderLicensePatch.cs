using Autodesk.Revit.UI;
using HarmonyLib; 
using ricaun.AppLoader; // copy local = false
using System.Reflection;

namespace RevitHarmony;

public static class AppLoaderLicensePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Api), "IsInDevelop")]
    [HarmonyPatch(typeof(Api), "ApiCheck")]
    [HarmonyPatch(typeof(Api), "ApiFull")]
    private static bool Prefix(ref bool __result)
    {
        __result = true;  // override return value
        return false;
    }

    public static void ApplyPatch()
    {
        Assembly appLoaderAssembly = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name.Equals("ricaun.AppLoader", StringComparison.OrdinalIgnoreCase));

        if (appLoaderAssembly == null) // sanity, shouldn't happen.
            return;

        Harmony harmony = new("AppLoaderLicensePatch");
        harmony.PatchAll(typeof(AppLoaderLicensePatch));

        IEnumerable<MethodBase> patchedMethods = Harmony.GetAllPatchedMethods();
        if (patchedMethods.Any())
            TaskDialog.Show("license patch", "Hooked license methods for AppLoader successfully");
        else
            TaskDialog.Show("license patch", "Failed to hook license methods for AppLoader");

    }
}
