namespace Day6

open System.Collections.Generic


module OrbitExplorer =

    let rec private buildTree (starchart: Dictionary<string,string list>) name =
        match starchart.TryGetValue name with
        | false, _ -> Node (name, [||])
        | true, satellites -> Node (name, satellites |> List.toArray |> Array.map (fun s -> buildTree starchart s))

    let map orbits =
        let starchart = Dictionary<string, string list>()
        orbits
        |> Seq.iter (fun o ->
            match starchart.TryGetValue o.Body with
            | true, satellites -> starchart.[o.Body] <- satellites @ [o.Satellite]
            | false, _ -> starchart.[o.Body] <- [o.Satellite]
            )
        
        buildTree starchart "COM"

    let calculateOrbits starchart =
        let rec visit planet dist =
            match planet with
                | Node (_, [||]) -> dist
                | Node (_, satellites) -> dist + (satellites |> Seq.map (fun s -> visit s (dist + 1)) |> Seq.sum)
        visit starchart 0