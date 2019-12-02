namespace Day2

open System
open System.IO

module Solution =

    [<EntryPoint>]
    let main _ =

        let input = File.ReadAllText("input.dat")|> Tokenizer.ToArray
        input.[1] <- 12
        input.[2] <- 2

        let result = IntcodeProcessor.compute input
        printfn "Value at position 0: %d" result.[0]

        0 // return an integer exit code
