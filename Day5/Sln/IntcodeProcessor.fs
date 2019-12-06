namespace Day5

open System.Collections.Generic

module IntcodeProcessor =

    let decoder = function
    | '0' -> Parameters.Positional
    | '1' -> Parameters.Immediate
    | x -> failwithf "Unknown parameter mode %A detected" x

    let toOpcode = function
        | 1 -> Opcodes.Add
        | 2 -> Opcodes.Multiply
        | 3 -> Opcodes.Input
        | 4 -> Opcodes.Output
        | 99 -> Opcodes.Halt
        | x -> failwithf "Unrecognized opcode %i detected" x

    let getParameter (input: int array) ip = function
        | Positional -> input.[input.[ip]]
        | Immediate -> input.[ip]
        

    let compute (memory: int array) input=
        let mutable ip = 0
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
                    memory.[target] <- input
                    ip + 2
                | Output ->
                    output.Add(getValue ip 1 modes)
                    ip + 2
                | Halt ->
                    length

        (memory, output.ToArray())