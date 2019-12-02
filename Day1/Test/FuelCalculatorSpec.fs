namespace Tests
open Xunit

module FuelCalculatorSpec =

    [<Theory>]
    [<InlineData(10,8)>]
    [<InlineData(1,-1)>]
    [<InlineData(0,-2)>]
    [<InlineData(-1,-3)>]
    let ``subtract2 reduces positive value by 2`` (input, expected) = FuelCalculator.subtract2 input = expected


    [<Theory>]
    [<InlineData(12,2)>]
    [<InlineData(14,2)>]
    [<InlineData(1969,654)>]
    [<InlineData(100756,33583)>]
    let ``calculate fuel for mass`` (mass, fuel) = FuelCalculator.determineFuel mass = fuel

    [<Theory>]
    [<InlineData(12,2)>]
    [<InlineData(14,2)>]
    [<InlineData(1969,966)>]
    [<InlineData(100756,50346)>]
    let ``calculate aggregate fuel cost`` (mass, fuel) = FuelCalculator.determineAggregateFuel mass = fuel