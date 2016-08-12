namespace FSharpXamarin.AppAndroid

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "FSharpXamarin.AppAndroid", MainLauncher = true)>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1
 
    let LegalValue num (button : Button) =
        let value = Always5.Trick2.Solve(num)
        button.Text <- sprintf "%d clicks! -- %d Value!" count value

    let IllegalValue (button : Button) =
        button.Text <- sprintf "%d clicks! -- Illegal Value!" count

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resource_Id.MyButton)
        button.Click.Add (fun args -> 
            count <- count + 1

            let val1to99 = Always5.Trick2.CreateAnyNumber1To99(count)
            match val1to99 with
                | Some _ -> LegalValue val1to99.Value button
                | None -> IllegalValue button
        )
    


