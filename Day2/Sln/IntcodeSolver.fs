namespace Day2

module IntcodeSolver =
    
    let solveFor input nouns verbs =
        seq {
            for noun in nouns do
                for verb in verbs do
                    let run = Array.copy input
                    run.[1] <- noun
                    run.[2] <- verb 
                    let result = IntcodeProcessor.compute run
                    yield (noun, verb, result.[0])
        } |> Seq.toArray