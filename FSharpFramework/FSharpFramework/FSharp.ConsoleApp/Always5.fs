module Always5 
    module Trick1 =
        let AddNextHighestNumber current = current + (current + 1)
        let Add9 current = current + 9
        let DivideBy2 current = current / 2
        let SubtractOriginal (current, original) = current - original

        let AddNextHighestNumberAdd9DivideBy2 =
            AddNextHighestNumber >> Add9 >> DivideBy2

        let AddNextHighestNumberAdd9DivideBy2Pipe x =
            x |> AddNextHighestNumber |> Add9 |> DivideBy2

        let Solve anyNumber:int = 
            anyNumber
            |> AddNextHighestNumberAdd9DivideBy2
            |> fun x-> (x, anyNumber)
            |> SubtractOriginal 
    
    module Trick2 =
        type AnyNumber1To99 = private AnyNumber1To99 of int
         
        let Unpack (AnyNumber1To99 i) = i

        
        let CreateAnyNumber1To99FromInt (aNumber:int) =
            if 1 <= aNumber && aNumber <= 99
                then Some (AnyNumber1To99 aNumber)
                else None

        let CreateAnyNumber1To99FromString (aString:string) =
            match System.Int32.TryParse(aString) with
               | (true,myIntVal) -> CreateAnyNumber1To99FromInt(myIntVal)
               | _ -> None

        let CreateAnyNumber1To99 (x:obj) = 
            match x with
                | :? string as s -> CreateAnyNumber1To99FromString s
                | :? int as i -> CreateAnyNumber1To99FromInt i
                | _ -> None

        
        let MultiplyBy5 current = current * 5
        let Add25 current = current + 25
        let DivideBy5 current = current / 5
        let SubtractOriginal (current, original) = current - original

        let Solve (anyNumber1To99 : Option<AnyNumber1To99>) : Option<int> =
            match anyNumber1To99 with
                | Some number1To99 ->
                    number1To99
                    |> Unpack
                    |> MultiplyBy5
                    |> Add25
                    |> DivideBy5
                    |> fun x -> (x, Unpack number1To99)
                    |> SubtractOriginal
                    |> Some
                | _ -> None
        
