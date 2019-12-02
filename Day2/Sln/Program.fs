namespace Day2

open System
open System.IO

module Solution =

    [<EntryPoint>]
    let main _ =

        let input = File.ReadAllText("input.dat")|> Tokenizer.ToArray

        let ``program Alert 1202`` = Array.copy input

        ``program Alert 1202``.[1] <- 12
        ``program Alert 1202``.[2] <- 2

        let result = IntcodeProcessor.compute ``program Alert 1202``
        printfn "Value at position 0: %d" result.[0]

        let solution = 
            IntcodeSolver.solveFor input [|0..99|] [|0..99|]
            |> Array.filter (fun (_,_,result)-> result = 19690720)

        let programAlert = 
            match solution with
            |  [| (n,v,_) |]-> n * 100 + v
            | _ -> failwithf "A solution set could not be found"

        printfn "Program Alert %d" programAlert

        0 // return an integer exit code
