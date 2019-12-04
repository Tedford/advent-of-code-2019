namespace Day3

open Xunit
open FsUnit.Xunit
open System.Collections.Generic
open Models

module RoutePlotterSpec = 

    [<Theory>]
    [<InlineData("R8,U5,L5,D3","U7,R6,D4,L4",6)>]
    [<InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72","U62,R66,U55,R34,D71,R55,D58,R83",159)>]
    [<InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51","U98,R91,D20,R16,D67,R40,U7,R15,U6,R7",135)>]
    let ``When finding the intersection``(path1, path2, expected)=
        let route1 = path1 |> RouteParser.parse |> RouteNavigator.map |> Seq.toArray
        let route2 = path2 |> RouteParser.parse |> RouteNavigator.map |> Seq.toArray

        RoutePlotter.findIntersection route1 route2 |> snd |> should equal expected

    [<Theory>]
    [<InlineData("R8,U5,L5,D3","U7,R6,D4,L4")>]
    let ``when building the map``(path1, path2) =
        let route1 = path1 |> RouteParser.parse |> RouteNavigator.map |> Seq.toArray
        let route2 = path2 |> RouteParser.parse |> RouteNavigator.map |> Seq.toArray

        let map = Dictionary<Point,int>()
        
        RoutePlotter.plot map route1
        RoutePlotter.plot map route2

        map.TryGetValue {X=3;Y=3} |> should equal (true,2)
        map.TryGetValue {X=6;Y=5} |> should equal (true,2)

        let values = map.Values |> Seq.groupBy id |> Seq.map (fun (density, occurances) -> (density, occurances |> Seq.length) )|> Seq.toArray
        values |> should equal [| (1,38); (2,2) |]
        
