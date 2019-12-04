namespace Day3

open Xunit
open FsUnit.Xunit
open Models

module ManhattenCalculcatorSpec = 

    [<Theory>]
    [<InlineData(0,0,1,0,1)>]
    [<InlineData(0,0,0,1,1)>]
    [<InlineData(1,0,0,0,1)>]
    [<InlineData(0,1,0,0,1)>]
    [<InlineData(0,0,1,1,2)>]
    [<InlineData(1,1,2,2,2)>]
    [<InlineData(1,1,-1,-1,4)>]
    [<InlineData(-1,-1,1,1,4)>]
    let ``calculate between 2 points``(x0,y0,x1,y1, expected) =
        let p1 = {X = x0; Y=y0}
        let p2 = {X=x1; Y=y1 }
        ManhattenDistanceCalculator.calculate p1 p2 |> should equal expected


    [<Theory>]
    [<InlineData(1,0,1)>]
    [<InlineData(0,1,1)>]
    [<InlineData(-1,0,1)>]
    [<InlineData(0,-1,1)>]
    [<InlineData(1,1,2)>]
    [<InlineData(-1,-1,2)>]
    let ``calculating from origin``(x,y,expected) =
        ManhattenDistanceCalculator.calculateFromOrgin {X=x; Y=y} |> should equal expected
