Only one of the C# source files included in this project
can be used at a time.

To control which source file is used, do the following:

- Right click on the desired source file within the solution explorer.
- Choose "Properties" from the context menu that will be displayed.
- Change the "Build Action" property to "C# compiler".
- Repeat the first 2 steps for each of the *other* source files, but
  change the "Build Action" to "None".

This technique allows you to see and easily navigate between each
of the variations of this program within the Visual Studio
Solution Explorer, while only including one of them whenever you build
(and run) the program.