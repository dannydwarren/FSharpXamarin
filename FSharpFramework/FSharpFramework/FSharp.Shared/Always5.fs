module Always5 
    module Trick1 =
        open System

        let AddNextHighestNumber current = current + (current + 1)
        let Add9 current = current + 9
        let DivideBy2 current = current / 2
        let SubtractOriginal (current, original) = current - original

        let AddNextHighestNumberAdd9DivideBy2 =
            AddNextHighestNumber >> Add9 >> DivideBy2

        let AddNextHighestNumberAdd9DivideBy2Pipe x =
            x |> AddNextHighestNumber |> Add9 |> DivideBy2

        let Solve (anyNumber:int) = 
            anyNumber
            |> fun x -> if x < 10 then x else raise (ArgumentException())
            |> AddNextHighestNumberAdd9DivideBy2
            |> fun x-> (x, anyNumber)
            |> SubtractOriginal
    
    module Trick2 =
        type AnyNumber1To10 = private AnyNumber1To10 of int
         
        let Unpack (AnyNumber1To10 i) = i
        
        let CreateAnyNumber1To10FromInt (aNumber:int) =
            if 1 <= aNumber && aNumber <= 10
                then Some (AnyNumber1To10 aNumber)
                else None

        let CreateAnyNumber1To10FromString (aString:string) =
            match System.Int32.TryParse(aString) with
               | (true,myIntVal) -> CreateAnyNumber1To10FromInt(myIntVal)
               | _ -> None

        let CreateAnyNumber1To10 (x:obj) = 
            match x with
                | :? string as s -> CreateAnyNumber1To10FromString s
                | :? int as i -> CreateAnyNumber1To10FromInt i
                | _ -> None
        
        let MultiplyBy5 current = current * 5
        let Add25 current = current + 25
        let DivideBy5 current = current / 5
        let SubtractOriginal (current, original) = current - original

        let Solve (anyNumber1To10 : Option<AnyNumber1To10>) : Option<int> =
            match anyNumber1To10 with
                | Some num ->
                    num
                    |> Unpack
                    |> MultiplyBy5
                    |> Add25
                    |> DivideBy5
                    |> fun x -> (x, Unpack num)
                    |> SubtractOriginal
                    |> Some
                | _ -> None

