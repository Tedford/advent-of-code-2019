namespace Day2

open Xunit
open FsUnit.Xunit
open System.IO

module IncodeSolverSpec =
    
    [<Fact>]
    let ``When solving program alert 1202 with the correct inputs``()   =
        let input = File.ReadAllText("input.dat")|> Tokenizer.ToArray
        let solution = IntcodeSolver.solveFor input [|12|] [|2|]
        let (n,v,r) = solution.[0]
        n |> should equal 12
        v |> should equal 2
        r |> should equal 4462686

        
    [<Fact>]
    let ``When solving program alert 1202 with the ranged inputs``()   =
        let input = File.ReadAllText("input.dat")|> Tokenizer.ToArray
        let nouns =[|0..99|]
        let verbs =[|0..99|]
        let solutions = IntcodeSolver.solveFor input nouns verbs
        let ``solution space`` = (Array.length nouns) * (Array.length verbs)
        solutions.Length |> should equal ``solution space``

        match solutions |> Array.filter (fun (n,v,_)-> n = 12 && v = 2) with
        | [|(n,v,r)|] -> 
            n |> should equal 12
            v |> should equal 2
            r |> should equal 4462686
        | _ -> failwith "the result was unexpected"