namespace Day2

module IntcodeProcessor =

    let compute (input: int array)=
        let mutable ip = 0
        let length = Array.length input

        while ip < length do
            let opcode = input.[ip]
            ip <-
                match opcode with
                | 1 -> 
                    let x = input.[ip + 1]
                    let y= input.[ip + 2 ]
                    let target = input.[ip + 3]
                    input.[target] <- input.[x] + input.[y]
                    ip + 4
                | 2 -> 
                    let x = input.[ip + 1]
                    let y= input.[ip + 2 ]
                    let target = input.[ip + 3]
                    input.[target] <- input.[x] * input.[y]
                    ip + 4
                | 99 ->
                    length
                | _ -> failwithf "%d is an unhandled opcode" opcode

        input