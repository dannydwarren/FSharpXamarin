// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Always5
open System

let doTrick1 userInput = 
    let number = userInput |> int
    number |> Trick1.Solve |> Some

let doTrick2 userInput = 
    let someNumber = Trick2.CreateAnyNumber1To99 userInput
    Trick2.Solve someNumber

[<EntryPoint>]
let main argv = 
    printfn "Enter a number 1 to 99:"
    let userInput = Console.ReadLine()
    let result = doTrick2 userInput
    match result with
        | Some num -> printfn "Your result is %d" num
        | None -> printfn "User Input Is Invalid"

    let trash = Console.ReadLine()
    0 // return an integer exit code
