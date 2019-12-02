namespace Day2

open Xunit
open FsUnit.Xunit


module IntcodeProcessorSpec =

    [<Theory>]
    [<InlineData("1,0,0,0,99","2,0,0,0,99")>]
    [<InlineData("2,3,0,3,99","2,3,0,6,99")>]
    [<InlineData("2,4,4,5,99,0","2,4,4,5,99,9801")>]
    [<InlineData("1,1,1,4,99,5,6,0,99","30,1,1,4,2,5,6,0,99")>]
    let ``When processing data`` (input, expected) = 
        let input' = Tokenizer.ToArray input
        let expected' = Tokenizer.ToArray expected
        IntcodeProcessor.compute input' |> should equal expected'
