installation:
- download the latest "spindll" file from releases: https://github.com/everythingEzra2/spindll/releases
- place "spindll" in your bin folder (or somewhere accessible by your Path)
- use like so:

example usage: 
`spindll -w -i "./PATH/TO/BUILD/OUTPUT.dll" -o "./PATH/TO/OUTPUT/DIRECTORY"`
- this will watch your build files for changes
- mark classes you want to copy with this annotation "[SpindllMark]"

_What is Spindll? (Spin.dll)_
- spindll can copy and convert backend classes into frontend classes.
- this is usefull so that you dont have to re-write and consciously update front-end objects to match backend objects.
- by automatically keeping front and back end objects in sync, model hydration should become super easy, thus reducing friction and fail-points in web-app development.
- example: you have a front-end SPA and a backend server that talk to each other. the backend project seriealizes a C# object and sends it to your front-end SPA. the front end project would deserialize the object to either an anonymous json object (which is error prone) OR to a .js/.ts object that is SUPPOSED to mimic the backend object (safe & preferable, but its a lot of work to keep backend+frontend models in sync). this is where spindll comes in.
- the result (ideally) is super easy hydration that is always up-to-date with the actual models that are delivered to and from the backend.

_how to use:_
- spindll will watch for changes in backend objects.
- when a backend object is changed, it will extract the properties and create the corresponding front-end model to match each backend model.
- this process is trggered by builds that change the target .dll.

run watcher with these arguments
- location of folder
- output
- filename to watch

example:
dotnet run "/home/myr/_repo/spindll/spindll/bin/Debug/netcoreapp3.0" "/home/myr/_repo/spindll/spindll/_testOutputs/" "spindll.dll"

* note: working on making this an executable console app AND making it easier to use. (local pathing etc.)
