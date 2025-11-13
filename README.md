# AppLoaderRicuanNolicense
addin to patch https://ricaun.com/apploader/ to remove it's licensing


It is crucial the project is build using all project depenencies copy local to false
and with
```
<PropertyGroup>
	<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
</PropertyGroup>
```
inside of csproj. See RevitHarmony.slnx
