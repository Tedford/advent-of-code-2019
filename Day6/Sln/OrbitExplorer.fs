namespace Day6

open System.Collections.Generic


module OrbitExplorer =

    let rec private buildTree (starchart: Dictionary<string,string list>) name distance=
        match starchart.TryGetValue name with
        | false, _ -> Node ({Name=name; Distance=distance}, [||])
        | true, satellites -> Node ({Name=name; Distance = distance}, satellites |> List.toArray |> Array.map (fun s -> buildTree starchart s (distance + 1)))

    let map orbits =
        let starchart = Dictionary<string, string list>()
        orbits
        |> Seq.iter (fun o ->
            match starchart.TryGetValue o.Body with
            | true, satellites -> starchart.[o.Body] <- satellites @ [o.Satellite]
            | false, _ -> starchart.[o.Body] <- [o.Satellite]
            )
        
        buildTree starchart "COM" 0

    //let calculateOrbits starchart =
    //    let rec visit planet dist =
    //        match planet with
    //            | Node (_, [||]) -> dist
    //            | Node (_, satellites) -> dist + (satellites |> Seq.sumBy (fun s -> visit s (dist + 1)))
    //    visit starchart 0

    let calculateOrbits starchart =
        let rec visit planet =
            match planet with
                | Node (body, [||]) -> body.Distance
                | Node (body, satellites) -> body.Distance + (satellites |> Seq.sumBy (fun s -> visit s))
        visit starchart
            