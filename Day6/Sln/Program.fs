// Learn more about F# at http://fsharp.org

open System
open System.IO
open Day6

[<EntryPoint>]
let main argv =
    try 
        File.ReadAllLines("input.dat") 
        |> Seq.map Tokenizer.toOrbit
        |> OrbitExplorer.map 
        |> OrbitExplorer.calculateOrbits
        |> printfn "%d orbits mapped"
    with
        Failure msg -> printfn "ERROR: %s" msg
    
    0 // return an integer exit code
