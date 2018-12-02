open System.IO
open System
open FSharp.Core.LanguagePrimitives

let ParseFile = 
    File.ReadAllLines("day-01-01-data.txt")
    |> Array.sumBy ParseInt32
    |> printfn "%i"
    