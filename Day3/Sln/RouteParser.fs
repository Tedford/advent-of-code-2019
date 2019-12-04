namespace Day3

open Models

module RouteParser =
    let encoder = function 
        | 'U' -> Up
        | 'D' -> Down
        | 'R' -> Right
        | 'L' -> Left
        | x -> failwithf "unexpected direction %A specified" x

    let decode (token:string) =
        let direction = token.[0] |> encoder
        let magnitude = token.Substring(1) |> int
        {Direction = direction; Magnitude = magnitude}

    let parse (input:string) = input.Split(",") |> Array.map decode

