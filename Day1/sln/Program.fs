// Learn more about F# at http://fsharp.org

open System
open System.IO

open FuelCalculator



[<EntryPoint>]
let main _ =
    File.ReadAllLines("input.dat") |> Seq.sumBy (float >> determineFuel) |> printfn "Part 1 Total Fuel %d"
    File.ReadAllLines("input.dat") |> Seq.sumBy (float >> determineAggregateFuel) |> printfn "Part 2 Total Fuel %d"
    0