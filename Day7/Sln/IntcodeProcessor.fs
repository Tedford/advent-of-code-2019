namespace Day7

open System.Collections.Generic

type IntcodeProcessor ()=

    let mutable running = true

    let inputs = Queue<int>()
    let onOutput = new Event<_>()

    let decoder = function
    | '0' -> Parameters.Positional
    | '1' -> Parameters.Immediate
    | x -> failwithf "Unknown parameter mode %A detected" x

    let toOpcode = function
        | 1 -> Add
        | 2 -> Multiply
        | 3 -> Input
        | 4 -> Output
        | 5 -> ``Jump if True``
        | 6 -> ``Jump if False``
        | 7 -> ``Less Than``
        | 8 -> Equals
        | 99 -> Halt
        | x -> failwithf "Unrecognized opcode %i detected" x

    let getParameter (input: int array) ip = function
        | Positional -> input.[input.[ip]]
        | Immediate -> input.[ip]

    [<CLIEvent>]
    member this.Output = onOutput.Publish

    member this.Input value = inputs.Enqueue value

    // shut down the processor
    member this.Running = running

    member this.compute (buffer: int array) =
        async {
            let mutable ip = 0
            let memory = Array.copy buffer
            let length = Array.length memory
        
            //let output = List<int>()

            let getValue ip i (modes: Parameters array) = getParameter memory (ip + i) modes.[i-1]

            while ip < length do
                let command= memory.[ip] |> sprintf "%05i"
                let opcode = command.Substring(command.Length-2, 2) |> int |> toOpcode
                let modes = command.[0..2] |> Seq.rev |> Seq.map decoder |> Seq.toArray

                ip <-
                    match opcode with
                    | Add -> 
                        let x =  getValue ip 1 modes 
                        let y =  getValue ip 2 modes 
                        let target = memory.[ip+3] 
                        memory.[target] <- x + y
                        ip + 4
                    | Multiply -> 
                        let x =  getValue ip 1 modes 
                        let y =  getValue ip 2 modes 
                        let target = memory.[ip+3] 
                        memory.[target] <- x * y
                        ip + 4
                    | Input -> 
                        let target = memory.[ip+1]
                        while inputs.Count < 0 && running do async { do! Async.Sleep(50) } |> Async.RunSynchronously
                        match running with
                        | true -> 
                            memory.[target] <- inputs.Dequeue()
                            ip + 2
                        | _ -> length
                    | Output ->
                        onOutput.Trigger(this, (getValue ip 1 modes))
                        //outbox.Post (getValue ip 1 modes)
                        //output.Add(getValue ip 1 modes)
                        ip + 2
                    | ``Jump if False`` ->
                        match (getValue ip 1 modes) with
                        | 0 -> getValue ip 2 modes
                        | _ -> ip + 3
                    | ``Jump if True`` ->
                        match (getValue ip 1 modes) with
                        | 0 -> ip + 3
                        | _ -> getValue ip 2 modes
                    | ``Less Than`` ->
                        let x =  getValue ip 1 modes 
                        let y =  getValue ip 2 modes 
                        let target = memory.[ip+3]
                        memory.[target] <- if x < y then 1 else 0
                        ip + 4
                    | Equals ->
                        let x =  getValue ip 1 modes 
                        let y =  getValue ip 2 modes 
                        let target = memory.[ip+3]
                        memory.[target] <- if x = y then 1 else 0
                        ip + 4
                    | Halt ->
                        length

            running <- false
        }
        //(memory, output.ToArray())