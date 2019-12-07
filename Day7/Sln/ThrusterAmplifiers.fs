namespace Day7

open System.Collections.Generic


module ThrusterAmplifiers =
    
    let ``5 stage`` input settings =

        settings |> Seq.fold (
            fun signal mode -> 
                let queue = Queue<int>()
                queue.Enqueue mode
                queue.Enqueue signal
                let (_,output) = IntcodeProcessor.compute queue input
                output.[0]
            ) 0