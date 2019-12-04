namespace Day3

open Xunit
open FsUnit.Xunit
open Models;

module RouteNavigatorSpec =

    [<Theory>]
    [<InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72","U62,R66,U55,R34,D71,R55,D58,R83",159)>]
    [<InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51","U98,R91,D20,R16,D67,R40,U7,R15,U6,R7",135)>]
    let ``Find closest intersection``(path1, path2, expected)=
        let route1 = path1 |> RouteParser.parse |> RouteNavigator.map
        let route2 = path2 |> RouteParser.parse |> RouteNavigator.map

        0
        //let intersection = RouteNavigator.findClosestIntersection route1 route2
        //intersection.Distance |> should equal expected


    [<Fact>]
    let ``when mapping a example route 1``() =
        let route = [|{Direction = Right; Magnitude=8}; {Direction=Up; Magnitude = 5}; {Direction=Left; Magnitude= 5}; {Direction=Down; Magnitude=3}|]
        RouteNavigator.map route |> Seq.toArray |> should equal [| {X=8;Y=0}; {X=8;Y=5}; {X=3;Y=5}; {X=3;Y=2}|]

    [<Fact>]
    let ``when mapping a example route 2``() =
        let route = [|{Direction = Up; Magnitude=7}; {Direction=Right; Magnitude = 6}; {Direction=Down; Magnitude= 4}; {Direction=Left; Magnitude=4}|]
        RouteNavigator.map route |> Seq.toArray |> should equal [| {X=0;Y=7}; {X=6;Y=7}; {X=6;Y=3}; {X=2;Y=3}|]
