// Learn more about F# at http://fsharp.org

open System
open Day4

[<EntryPoint>]
let main argv =

    PasswordInspector.identifyCandidates 271973 785961 |> Seq.length |> printfn "%d criteria 1 possible candidates"
    PasswordInspector.identifyCandidates2 271973 785961 |> Seq.length |> printfn "%d criteria 2 possible candidates"

    0 // return an integer exit code
