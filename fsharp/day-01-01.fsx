open System.IO
open System
open FSharp.Core.LanguagePrimitives

let ParseFile = 
    let dataLines = File.ReadAllLines("day-01-01-data.txt")
    dataLines
    |> Array.map ParseInt32
    |> Array.sum
    |> printfn "%i"
    