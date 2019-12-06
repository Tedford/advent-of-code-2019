namespace Day5

module Tokenizer =
    let ToArray (input:string) = input.Split(',') |> Array.map int