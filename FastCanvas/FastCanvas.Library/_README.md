FastCanvas provides an interface between C# and an HTML Canvas. It processes everything in one go, with passthroughs 
for all the common methods that I use, includes some custom methods to make calls easier, and though the 
spec isn't complete, I am done (I'm not worrying about implementing all the different image options; use 
another library if you need those). This is intended to be a shorter setup with JS syntax for canvas calls, and 
that is it. 

The wiki can be found at [this link](https://wiki.codyhowell.dev/fastcanvas), and will walk through all the steps 
to get started. You need this package, a script link, and an IJSRuntime object in your Razor component, and then 
this class will help you do the rest. 