// Learn more about F# at http://fsharp.org

open System
open System.IO
open Day5

[<EntryPoint>]
let main argv =

    let memory = File.ReadAllText("input.dat").Split(",") |> Seq.map int |> Seq.toArray
    
    IntcodeProcessor.compute memory 1 |> snd |> printfn "AC Diagnostic Test: %A"
    
    0 // return an integer exit code
