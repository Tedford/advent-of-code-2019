namespace Day3

open System
open Models

module ManhattenDistanceCalculator = 
    
    let calculate p0 p1 = Math.Abs(p1.X - p0.X) + Math.Abs(p1.Y - p0.Y)

    let calculateFromOrgin p = calculate {X=0; Y=0} p