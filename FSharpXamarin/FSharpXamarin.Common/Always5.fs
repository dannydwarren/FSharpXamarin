module Always5 
    module Trick1 =
        let AddNextHighestNumber current = current + (current + 1)
        let Add9 current = current + 9
        let DivideBy2 current = current / 2
        let SubtractOriginal (current, original) = current - original

        let Solve anyNumber:int = 
            anyNumber
            |> AddNextHighestNumber
            |> Add9
            |> DivideBy2
            |> fun x-> (x, anyNumber)
            |> SubtractOriginal 
    
    module Trick2 =
        type AnyNumber1To99 = private AnyNumber1To99 of int
        
        let CreateAnyNumber1To99 (aNumber:int) =
            if 1 <= aNumber && aNumber <= 99
                then Some (AnyNumber1To99 aNumber)
                else None

        let Unpack (AnyNumber1To99 i) = i
        
        let MultiplyBy5 current = current * 5
        let Add25 current = current + 25
        let DivideBy5 current = current / 5
        let SubtractOriginal (current, original) = current - original

        let Solve (anyNumber1To99 : AnyNumber1To99) : int =
            //Because the value passed to Solve is assumed to be a valid int between 1 to 99
            //  we want to unpack the Discriminated Union type helping into an int.

            anyNumber1To99
            |> Unpack
            |> MultiplyBy5
            |> Add25
            |> DivideBy5
            |> fun x -> (x, Unpack anyNumber1To99)
            |> SubtractOriginal
        
