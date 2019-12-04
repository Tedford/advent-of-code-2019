
// Learn more about F# at http://fsharp.org

open System
open System.IO
open Day3
open Day3.Models
open System.Collections.Generic

[<EntryPoint>]
let main _=
    let transform = RouteParser.parse >> RouteNavigator.map
    
    let routes = File.ReadAllLines("input.dat") |> Array.map transform

    let intersection = RoutePlotter.findIntersection routes.[0] routes.[1]

    //let intersection = RouteNavigator.findClosestIntersection routes.[0] routes.[1]
    printfn "Closest intersection is %A" intersection

    
    printfn "Hello World from F#!"
    0 // return an integer exit code
