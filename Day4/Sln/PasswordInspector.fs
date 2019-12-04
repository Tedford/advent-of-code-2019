namespace Day4

    open System.Text.RegularExpressions

    module PasswordInspector =

        let isSixDigits password = Regex.IsMatch(password,"\d{6}")

        let hasRepeat password = 
            password 
            |> Seq.map int 
            |> Seq.fold (fun (hasRepeat, last) digit -> (hasRepeat || (match last with None -> false | Some l  -> l = digit), Some digit)) (false, None) |> fst
            

        let hasRepeatOf2 password = password |> Seq.groupBy id |> Seq.filter (fun (_,o) -> Seq.length o = 2 ) |> Seq.length > 0

        let isNotDecreating password = password |> Seq.map int |> Seq.fold (fun (valid,last) digit ->  ( valid && digit >= last, digit)) (true,0) |> fst
        
        let isValid password = isSixDigits password && isNotDecreating password && hasRepeat password 
        let isValid2 password = isSixDigits password && isNotDecreating password && hasRepeatOf2 password 

        let identifyCandidates start finish = [|start .. finish|] |> Seq.map string |> Seq.filter isValid
        let identifyCandidates2 start finish = [|start .. finish|] |> Seq.map string |> Seq.filter isValid2