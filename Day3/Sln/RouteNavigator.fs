namespace Day3

open Models
open ManhattenDistanceCalculator

module RouteNavigator =

    let move last step =
        match step.Direction with
        | Up ->  {last with Y = last.Y +  step.Magnitude}
        | Left -> {last with X = last.X - step.Magnitude}
        | Down -> {last with Y = last.Y - step.Magnitude}
        | Right ->{last with X = last.X + step.Magnitude}

    let map route =
        let mutable last = {X=0; Y=0}
        seq {
            for step in route do    
                last <- move last step
                yield last
        }


    let containsPoint values (point: Point) = (values |> Seq.filter (fun v -> v.Point = point) |> Seq.length) = 1

    let findIntersections r1 r2 = r1 |> Seq.filter (fun p -> containsPoint r2 p.Point )
    
    let findClosestIntersection r1 r2 =  findIntersections r1 r2 |> Seq.sortBy (fun p -> p.Distance) |> Seq.head