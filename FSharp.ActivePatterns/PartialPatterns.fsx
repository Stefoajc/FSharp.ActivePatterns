//                  ******* Partial Patterns *******
//                              Syntax
// let (|identifier1|_|) valueToMatch = expression // template
// 
// identifier   - name of the Active Pattern (like function name or value name)
// valueToMatch - value over which the matching should happen
// expression   - the match condition
// 
// Example:
//      let (|Fizz|_|) n =
//          match n%3 with
//          | 0 -> Some ()
//          | _ -> None
//
// Usage:
//   Used to partition unknown number of different matches
//   Used to split the data and apply different logic on one case without carrying about the other possible cases
//
//
// Ways of thinking:
//   Match and if it's that case execute if not don't care what other cases could be
//
// Properties:
//   Can have one case name
//   Can be combined with other Partial Patterns with "AND" and "OR" (ex. match num with | Fizz & Buzz)
//   More flexible that Multicase Total patterns
//   Unidentifiable - the compiler will NOT want you to exhaustively specify all cases


let (|Fizz|_|) n =
    match n%3 with
    | 0 -> Some ()
    | _ -> None

let (|Buzz|_|) n =
    match n%5 with
    | 0 -> Some ()
    | _ -> None

for num in [1..100] do
    match num with
    | Fizz & Buzz -> printfn "FizzBuzz"
    | Fizz -> printfn "Fizz"
    | Buzz -> printfn "Buzz"
    | n -> printfn "%i" n


let endsWithMatch (fileName:string) endsWithStr =
    match fileName.EndsWith(endsWithStr) with
    | true -> Some ()
    | _ -> None

let (|PDF|_|) (fileName:string) = 
    endsWithMatch fileName ".pdf"
    
let (|DOCX|_|) (fileName:string) = 
    endsWithMatch fileName ".docx"

let (|TXT|_|) (fileName:string) = 
    endsWithMatch fileName ".txt"

let algorithmOnFileName fileName =
    match fileName with
    | PDF -> printfn "PDF specific actions"
    | DOCX -> printfn "DOCX specific actions"
    | TXT -> printfn "TXT specific actions"
    | _ -> printfn "Not supported"

algorithmOnFileName "file.jpg"