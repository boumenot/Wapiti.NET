# Wapiti.NET

C# Bindings for Wapiti.  Bindings are based on my Wapiti
[fork][wapiti].  Bindings are x64 only.

```csharp
using (var model = WapitiModel.Load(path))
{
    var wapiti = Wapiti.Create();
    var result = wapiti.Label(model, File.OpenRead("my.txt"));

    Console.WriteLine(result);
}
```

## Build

```bat
build.cmd
```

## Notes

This is an alpha release.  It appears to work for me, but your mileage
may vary.  I know there are bugs that I have not found yet.  

I know that memory usage is much larger than I expect.  For example,
loading a 90 MB model consumes approximately 1 GB of memory.

[wapiti]: https://github.com/boumenot/Wapiti