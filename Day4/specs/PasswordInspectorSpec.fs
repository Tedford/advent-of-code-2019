namespace Day4

open Xunit
open FsUnit.Xunit

module PasswordInspectorSpec =
    
    [<Theory>]
    [<InlineData("abc112", false)>]
    [<InlineData("11111", false)>]
    [<InlineData("111111", true)>]
    [<InlineData("111122", true)>]
    [<InlineData("112345", true)>]
    [<InlineData("123444", true)>]
    [<InlineData("112233", true)>]
    [<InlineData("223450", false)>]
    [<InlineData("123789", false)>]
    [<InlineData("923780", false)>]
    let ``When inspecting known passwords with criteria 1``(input, expected)=
        PasswordInspector.isValid input |> should equal expected

    [<Theory>]
    [<InlineData("123444", false)>]
    [<InlineData("112233", true)>]
    [<InlineData("abc112", false)>]
    [<InlineData("11111", false)>]
    [<InlineData("111111", false)>]
    [<InlineData("111122", true)>]
    [<InlineData("112345", true)>]
    [<InlineData("223450", false)>]
    [<InlineData("123789", false)>]
    [<InlineData("923780", false)>]
    let ``When inspecting known passwords with criteria 2``(input, expected)=
        PasswordInspector.isValid2 input |> should equal expected

    [<Theory>]
    [<InlineData("111110", false)>]
    [<InlineData("111111", true)>]
    [<InlineData("112345", true)>]
    [<InlineData("223450", false)>]
    [<InlineData("123789", true)>]
    [<InlineData("923780", false)>]
    let ``When checking for decreasing``(input, expected) =
        PasswordInspector.isNotDecreating input |> should equal expected
    
    [<Theory>]
    [<InlineData("111111","111111", 1)>]
    [<InlineData("111110","111111", 1)>]
    let ``When inspecting a range with criteria 1``(start,finish, expected)=
        PasswordInspector.identifyCandidates start finish |> Seq.length |> should equal expected
        
    [<Theory>]
    [<InlineData("111111","111122", 1)>]
    [<InlineData("111111","111111", 0)>]
    [<InlineData("111110","111111", 0)>]
    let ``When inspecting a range with criteria 2``(start,finish, expected)=
        PasswordInspector.identifyCandidates2 start finish |> Seq.length |> should equal expected
