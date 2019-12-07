namespace Day7

module Tokenizer = 
    let ToArray (input:string) = input.Split(',') |> Array.map int

    let toList (input:string) = input|> ToArray |> Array.toList