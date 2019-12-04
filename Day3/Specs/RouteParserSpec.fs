namespace Day3

open Xunit
open FsUnit.Xunit
open Models

module RouteParserSpec =
    
    [<Fact>]
    let ``When parsing a single right`` ()=
        RouteParser.parse "R999" |> should equal [|{Direction = Right; Magnitude =999} |]

    [<Fact>]
    let ``When parsing a single left`` ()=
        RouteParser.parse "L84" |> should equal [|{Direction = Left; Magnitude =84} |]

    [<Fact>]
    let ``When parsing a single down`` ()=
        RouteParser.parse "D467" |> should equal [|{Direction = Down; Magnitude =467} |]

    [<Fact>]
    let ``When parsing a single up`` ()=
        RouteParser.parse "U80" |> should equal [|{Direction = Up; Magnitude =80} |]

    [<Fact>]
    let ``When parsing well-formed input`` ()=
        RouteParser.parse "R999,D467,L84,U80" |> should equal [|{Direction = Right; Magnitude =999}; {Direction=Down; Magnitude = 467}; {Direction=Left;Magnitude =84};{Direction = Up; Magnitude =80} |]


