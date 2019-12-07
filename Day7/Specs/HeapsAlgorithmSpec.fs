namespace Day7

open Xunit

module HeapsAlgorithmSpec =

    [<Fact>]
    let ``When generating permutations``()=
        let input = [1;2;3]

        let permutations = HeapsAlgorithm.permutations input
        Assert.Equal (permutations|> Seq.length, 6)