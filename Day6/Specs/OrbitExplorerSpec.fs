namespace Day6

open System.IO
open Xunit
open FsUnit.Xunit

module OrbitExplorerSpec =
    
    [<Theory>]
    [<InlineData("test1.dat",1)>]
    [<InlineData("test3.dat",3)>]
    [<InlineData("test6.dat",6)>]
    [<InlineData("test28.dat",28)>]
    [<InlineData("test42.dat",42)>]
    let ``When measuring orbits``(file, expected) =
        File.ReadAllLines(file) 
        |> Seq.map Tokenizer.toOrbit 
        |> OrbitExplorer.map
        |> OrbitExplorer.calculateOrbits
        |> should equal expected

        
