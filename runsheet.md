# Assumed knowledge

 * unit testing
 * asserts

At any time ask questions


# Traditional Snapshot

```mermaid
graph LR
run(Run test and<br/>create Received file)
hasSnapshot{Has existing<br/>Verified file?}
hasSnapshot-- No -->failTest
failTest(Fail Test)
run-->hasSnapshot
shouldAccept{Accept new<br/>Received file?}
failTest-->shouldAccept
accept(Move Received to Verified)
shouldAccept-- Yes -->accept
discard(Discard Received)
shouldAccept-- No -->discard

isSame{Compare Verified<br/>to Received}
hasSnapshot-- Yes -->isSame
passTest(Pass Test and<br/>discard Received)
isSame-- Same --> passTest
isSame-- Different --> failTest
```

 * install DiffEngineTray
   dotnet tool install --global DiffEngineTray --version 6.9.1
 * install a DiffTool
 * Demo WinFormsAppTests from scratch
 * Nested files
 * ignore received


# Snapshot is Serialization

Snapshot testing leverage serialization. Converting a UI to an image is a form of serialization. The same serialization approach can be applied to any data.

 * Demo: Convert PersonBuilderTests.cs to snapshot testing
 * Scrubbers:
 * Demo: Sql Schema, Anything can be serialized


# Global Scrubbers

 * Demo Blazor


# Converters

Above samples Winforms and Sql were implemented as converters, but only output one file.

Converters can output multiple files


# Parameterised Testing

 * file naming
 * Demo: ParamTests


# Recording

 * Demo Sql recording
 * Demo Http recording




# Comparers

 * Winforms
 * Xaml
 * Web 

## Demo: 