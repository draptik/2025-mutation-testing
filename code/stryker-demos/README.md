# Stryker Demos

## Rider w/ linux

- After running `dotnet stryker` from the cli, the file 
  `stryker-demos/src/StrykerDemos.MyLib/obj/Debug/net8.0/ref/StrykerDemos.MyLib.dll`
  is removed.
- Rider: run all tests...
- Rider: complains about the missing file: `CSC: Error CS0006 : Metadata file ...` referencing the above mentioned dll.
- In Rider: 
  - Clean & Rebuild the test project
  - rerun the tests