namespace Day7

open System.Collections.Generic

module ThrusterAmplifiers =
    
    let ``5 stage`` input settings =

        let buffer = Queue<int>()

        let a,b,c,d,e =  
            match settings with
            | [_a;_b;_c;_d;_e] -> _a,_b,_c,_d,_e
            | x -> failwithf "Malformed input %A detected" x
    
        let stage1 = IntcodeProcessor()
        let stage2 = IntcodeProcessor()
        let stage3 = IntcodeProcessor()
        let stage4 = IntcodeProcessor()
        let stage5 = IntcodeProcessor()

        // wire the units together
        stage1.Output.Add( fun (_,arg) -> stage2.Input arg)
        stage2.Output.Add(fun (_,arg)->stage3.Input arg)
        stage3.Output.Add(fun (_,arg)->stage4.Input arg)
        stage4.Output.Add(fun (_,arg)->stage5.Input arg)
        stage5.Output.Add(fun (_,arg)->buffer.Enqueue arg)
        
        // set the operating modes
        stage1.Input a
        stage2.Input b
        stage3.Input c
        stage4.Input d
        stage5.Input e

        let running = stage1.Running && stage2.Running && stage3.Running && stage4.Running && stage5.Running

        stage1.compute (Array.copy input)
        stage2.compute (Array.copy input)
        stage3.compute (Array.copy input)
        stage4.compute (Array.copy input)
        stage5.compute (Array.copy input)

        let rec run seed = 
            stage1.Input seed

            while buffer.Count < 0 do async { do! Async.Sleep(50)} |> Async.RunSynchronously

            match running with
            | false -> ()
            | true -> run (buffer.Dequeue())
        
        run 0

        buffer.Dequeue()