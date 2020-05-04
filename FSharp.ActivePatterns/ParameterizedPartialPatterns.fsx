//          ******* Parameterized Partial Patterns *******
//                              Syntax
// let (|identifier1|_|) arguments valueToMatch = expression
// 
// identifier   - name of the Active Pattern (like function name or value name)
// arguments    - arguments which you want to pass to the Active pattern (optional)
// valueToMatch - value over which the matching should happen
// expression   - the match condition
// 
// Example:
//      let (|Groups|_|) pattern value =
//          let m = Regex.Match (value,pattern)
//          match m.Success,m.Groups.Count with
//          | true,n when n > 0 ->
//              [ for g in m.Groups -> g.Value ]  //List comprehention
//              |> List.tail // drop “root” match
//              |> Some
//          | _ -> None
//
// Usage:
//   Used to match the data and apply different logic on different cases using outside parameters
//   Can be used to remodel preexisting "sum" type in more appropriate way
//   Can be combined with other Partial Patterns with "AND" and "OR" (ex. match num with | Fizz & Buzz)
//   More flexible that Partial patterns
//
//
// Ways of thinking:
//   Match and if it's that case execute if not don't care what other cases could be
//
// Properties:
//   Can have one case name
//   Can have as much arguments as needed
//   Unidentifiable - the compiler will NOT want you to exhaustively specify all cases

open System.Text.RegularExpressions
let (|Groups|_|) pattern value =
   let m = Regex.Match (value,pattern)
   match m.Success,m.Groups.Count with
   | true,n when n > 0 ->
      [ for g in m.Groups -> g.Value ]  //List comprehention
      |> List.tail // drop “root” match
      |> Some
   | _ ->None

let RegexValidation pattern value =
    match value with
    | Groups pattern [ item ] -> true
    | _ -> false
        


match "37206-1234" with
| Groups "(\d{5})([-]\d{4})?" [ zip; other ] ->
    printfn "Postal code: %s , %s" zip other
| _ -> printf "Invalid postal code"
   