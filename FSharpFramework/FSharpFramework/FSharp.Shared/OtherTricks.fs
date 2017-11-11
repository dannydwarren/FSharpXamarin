module OtherTricks
    module Trick3 =
        type Even = private Even of int

        let Unpack (Even i) = i

        let CreateEven num =
            match num % 2 with
            | 0 -> Some (Even num)
            | _ -> None
        
        let CreateEvenFromString str =
            match System.Int32.TryParse(str) with
            | (true, num) -> CreateEven num
            | _ -> None

        let Solve (even : Option<Even>) =
            match even with
            | Some i -> "Even"
            | None -> "Odd"
