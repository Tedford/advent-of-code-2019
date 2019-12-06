// Learn more about F# at http://fsharp.org

open System
open System.IO
open Day5

[<EntryPoint>]
let main argv =
    File.ReadAllText("input.dat") |> Tokenizer.ToArray |> IntcodeProcessor.compute 1 |> snd |> printfn "Diagnostic Test 1: %A"
    File.ReadAllText("input2.dat") |> Tokenizer.ToArray |> IntcodeProcessor.compute 5 |> snd |> printfn "Diagnostic Test 5: %A"
    0 // return an integer exit code
