# Stryker Demos

## xUnit v3 currently not supported

Currently (2025-05-21) xUnit v3 is NOT supported: <https://github.com/stryker-mutator/stryker-net/issues/3117>.

## Rider w/ linux

- After running `dotnet stryker` from the cli, the file 
  `stryker-demos/src/StrykerDemos.MyLib/obj/Debug/net8.0/ref/StrykerDemos.MyLib.dll`
  is removed.
- Rider: run all tests...
- Rider: complains about the missing file: `CSC: Error CS0006 : Metadata file ...` referencing the above mentioned dll.
- In Rider: 
  - Clean & Rebuild the test project
  - rerun the tests
