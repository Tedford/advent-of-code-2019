namespace Day2

open Xunit
open FsUnit.Xunit

module TokenizerSpec =

    [<Fact>]
    let ``When tokenzing a comma delimted array``()  =
        Tokenizer.ToArray "1,0,0,0,99" |> should equal [|1;0;0;0;99|]


