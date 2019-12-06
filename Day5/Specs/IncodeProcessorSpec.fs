namespace Day5

open Xunit
open FsUnit.Xunit

module IncodeProcessorSpec =

    [<Fact>]
    let ``When processing a command with output``() =
        let (memory, output)= IntcodeProcessor.compute [|3;0;4;0;99|] 10
        output |> should equal [| 10 |]
        memory |> should equal [|10;0;4;0;99|]


    [<Fact>]
    let ``When processing a command without output``() =
        let (memory, output)= IntcodeProcessor.compute [|1002;4;3;4;33|] 10
        output |> should equal [| |]
        memory |> should equal [|1002;4;3;4;99|]