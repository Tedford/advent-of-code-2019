namespace Day6

module Tokenizer =

    let toOrbit (s:string) =
        match s.Split(')') with
        | [| body; satellite|] ->{Body = body; Satellite = satellite}
        | _ -> failwithf "Malformed input expected AAA)BBB received %s" s
        

