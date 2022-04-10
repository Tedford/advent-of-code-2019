// Learn more about F# at http://fsharp.org

open System
open System.IO
open Day7

[<EntryPoint>]
let main _ =
    
    let input = File.ReadAllText("input.dat") |> Tokenizer.ToArray

    let permutations = HeapsAlgorithm.permutations [0;1;2;3;4]

    //let (setting, signal) = 
    //    permutations
    //    |> Seq.map (fun settings -> 
    //        let signal = ThrusterAmplifiers.``5 stage`` input settings
    //        (settings, signal )
    //        )
    //    |> Seq.sortByDescending snd
    //    |> Seq.head


    //printfn "Highest output is setting %d at setting %A." signal setting

    







    0 // return an integer exit code
