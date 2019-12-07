namespace Day7

open System.Collections.Generic

module IntcodeProcessor =

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
        

    let compute (inputs: Queue<int>) (buffer: int array)=
        let mutable ip = 0
        let memory = Array.copy buffer
        let length = Array.length memory


        let output = List<int>()

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
                    memory.[target] <- inputs.Dequeue()
                    ip + 2
                | Output ->
                    output.Add(getValue ip 1 modes)
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

        (memory, output.ToArray())