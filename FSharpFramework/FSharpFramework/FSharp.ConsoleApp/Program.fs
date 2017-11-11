// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Always5
open OtherTricks
open System


let DoTrick1 (userInput:int) = 
    let (result:int) = Trick1.Solve userInput 
    sprintf "%d solves to %d" userInput result

let DoTrick2 (userInput:int) = 
    let (anyNumber1To10:Option<Trick2.AnyNumber1To10>) = Trick2.CreateAnyNumber1To10 userInput
    let (result:Option<int>) = Trick2.Solve anyNumber1To10
    match result with
    | Some i -> sprintf "%d solves to %d" userInput i
    | None -> sprintf "%d is an illegal value" userInput

let DoTrick3 userInput = 
    userInput
    |> Trick3.CreateEven
    |> Trick3.Solve
    |> (sprintf "%d is %s" userInput)

let ConvertBad str =
    System.Int32.Parse str

let ConvertGood str =
    match System.Int32.TryParse str with
    | (true, num) -> Some num
    | _ -> None

let Process userInput =
    //Don't do this
    //ConvertBad userInput |> DoTrick1 |> Console.WriteLine
    //ConvertBad userInput |> DoTrick2 |> Console.WriteLine
    //ConvertBad userInput |> DoTrick3 |> Console.WriteLine

    //Do it like this!
    try
        ConvertGood userInput
        |> fun x -> 
            match x with
            | Some i -> DoTrick1 i
            | None -> "Invalid Input"
        |> Console.WriteLine
    with
    | :? ArgumentException -> printfn "Argument Exception Thrown"

    ConvertGood userInput
    |> fun x -> 
        match x with
        | Some i -> DoTrick2 i
        | None -> "Invalid Input"
    |> Console.WriteLine

    ConvertGood userInput
    |> fun x -> 
        match x with
        | Some i -> DoTrick3 i
        | None -> "Invalid Input"
    |> Console.WriteLine

let rec GetUserInput () =
   printfn "Enter a number 1 to 10:"
   let userInput = Console.ReadLine()
   
   if userInput = "exit" then ()
   else (Process userInput |> GetUserInput)

[<EntryPoint>]
let main argv = 
    GetUserInput ()
    0 // return an integer exit code
