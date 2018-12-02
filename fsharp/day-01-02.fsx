open System.IO
open System
open FSharp.Core.LanguagePrimitives

let readFrequencyChanges = 
    Array.map ParseInt32 (File.ReadAllLines("day-01-01-data.txt"))

let test1 = [| +3; +3; +4; -2; -4 |]
let test2 = [| -6; +3; +8; +5; -6 |]
let test3 = [| +7; +7; -2; -7; -4 |]

let infinite aSeq =
    seq { while true do yield! aSeq }

let infiniteChanges =
    seq { while true do yield! readFrequencyChanges }

let finite = Seq.take 1000 infiniteChanges

let rec findDuplicate changeSeq (known: Set<int>) initial =
    let newValue = initial + Seq.head changeSeq
    match known.Contains(newValue) with
    | true ->
        newValue
    | false ->
       // printfn "%i" newValue
       findDuplicate (Seq.tail changeSeq) (Set.add newValue known) newValue

let result = findDuplicate (infinite test1) Set.empty 0

printfn "Expect 10 - %i" result

printfn "Expect 5 - %i" (findDuplicate (infinite test2) Set.empty 0)
printfn "Expect 14 - %i" (findDuplicate (infinite test3) Set.empty 0)

printfn "Result - %i" (findDuplicate (infinite readFrequencyChanges) Set.empty 0)
