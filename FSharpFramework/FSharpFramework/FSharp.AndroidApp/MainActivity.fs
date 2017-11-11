namespace FSharp.AndroidApp

open Android.App
open Android.Views
open Android.Widget
open Always5
open OtherTricks

type Resources = FSharp.AndroidApp.Resource

[<Activity (Label = "FSharp.AndroidApp", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 0

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

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        this.SetContentView (Resources.Layout.Main)

        let button = this.FindViewById<Button>(Resources.Id.myButton)
        button.Click.Add (fun args -> 
            button.Text <- DoTrick1 count
            //button.Text <- DoTrick2 count
            //button.Text <- DoTrick3 count

            count <- count + 1
        )

