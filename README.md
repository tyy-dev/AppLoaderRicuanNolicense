
# README

## Install

Install [https://ricaun.com/apploader/](https://ricaun.com/apploader/).

---

## Build Solution

Build the solution with a reference to:

```
\ProgramData\Autodesk\ApplicationPlugins\ricaun.AppLoader.bundle\Contents\ricaun.AppLoader\2.12.1\2025\ricaun.AppLoader.dll
```

and other needed Revit dependencies.


It is crucial that the project is built using all project dependencies with **Copy Local = false**,
and with the following property inside the `.csproj` file:

```xml
<PropertyGroup>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```

See `RevitHarmony.slnx` / RevitHarmony.csproj for reference.
---

## Install license patch addin
Using the solution you just built, install the add-in to the same version as your reference and place `AppLoaderPatch.addin` in `C:\ProgramData\Autodesk\Revit\Addins\` with an updated `Assembly.path` — the assembly path of your build directory, which should contain all needed dependencies.

## Test
"Hooked license methods for AppLoader successfully" should show up when you start reit, otherwise you likely made a mistake in the build process, or did not install app loader.

---
