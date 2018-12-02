open System.IO
open System
open FSharp.Core.LanguagePrimitives

let readFrequencyChages = 
    Array.map ParseInt32 (File.ReadAllLines("day-01-01-data.txt"))
    
let applyFrequencyChanges changes initialFrequency =
    initialFrequency + (Array.sum changes)

printfn "%i" (applyFrequencyChanges readFrequencyChages 0)
