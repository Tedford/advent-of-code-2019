namespace Day7

module HeapsAlgorithm =
    

    let rec private insertions x = function
       | []             -> [[x]]
       | (y :: ys) as l -> (x::l)::(List.map (fun x -> y::x) (insertions x ys))

    let rec permutations = function
       | []      -> seq [ [] ]
       | x :: xs -> Seq.concat (Seq.map (insertions x) (permutations xs))