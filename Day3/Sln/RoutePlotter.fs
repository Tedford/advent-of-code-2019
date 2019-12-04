namespace Day3

open System.Collections.Generic
open Models

module RoutePlotter =
    
    let increment (map:Dictionary<Point,int>) point =
        match map.TryGetValue point with
        | true, value -> map.[point] <- value+1
        | _ -> map.[point] <- 1

    let plot (map: Dictionary<Point, int>) route =
        let mutable last = {X=0; Y=0}
        route
        |> Seq.iter (fun p -> 
            match last.X = p.X with
            | true ->  
                let (step, origin) = if last.Y > p.Y then (-1, last.Y-1) else (1,last.Y+1)
                for y in [origin.. step.. p.Y] do increment map {last with Y = y}
            | false -> 
                let (step, origin) = if last.X > p.X then (-1, last.X-1) else (1, last.X+1)
                for x in [origin .. step.. p.X] do increment map {last with X = x}
            last <- p
        )

    let findIntersection route1 route2 =
        let map = Dictionary<Point,int>()
        
        plot map route1

        // this has to be a bug somewhere but the wires seem to self cross
        for key in map.Keys |> Seq.toArray do map.[key] <- 1

        plot map route2

        map.Keys
        |> Seq.map (fun key -> (key,map.[key]) )
        |> Seq.filter (fun (_,count) -> count =2 )
        |> Seq.map (fun (p,_) -> (p, ManhattenDistanceCalculator.calculateFromOrgin p))
        |> Seq.sortBy (fun (_,dist)-> dist)
        |> Seq.head

