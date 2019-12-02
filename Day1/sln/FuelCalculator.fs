module FuelCalculator

open System

let subtract2 = fun x -> x - 2

let determineFuel mass = mass / 3.0 |> Math.Floor |> int |> subtract2

let determineAggregateFuel mass =
    let fuelForMass = determineFuel mass

    let mutable fuelForFuel = 0
    let mutable remainingMass = fuelForMass

    while remainingMass > 0 do
        let fuelForFuel' = determineFuel (remainingMass |> float)
        match fuelForFuel' > 0 with
        | true -> 
            fuelForFuel <- fuelForFuel + fuelForFuel'
            remainingMass <- fuelForFuel'
        | _ -> remainingMass <- 0
                  
    fuelForMass + fuelForFuel