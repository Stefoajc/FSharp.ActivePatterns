//              ******* Multi Case Total Patterns *******
//                              Syntax
// let (|identifier1|identifier2|identifier3|..|identifierN|) [arguments] valueToMatch = expression // template
// 
// identifier   - name of the Active Pattern (like function name or value name)
// arguments    - arguments which you want to pass to the Active pattern (optional)
// valueToMatch - value over which the matching should happen
// expression   - the match condition
// 
// Example:
//   let (|Even|Odd|) n =
//      if n % 2 = 0
//      then Even
//      else Odd
//
// Usage:
//   Used to partition known number of different matches in separate buckets
//   Used to split the data and apply different logic on different cases
//   Can be used to remodel preexisting "sum" type in more appropriate way
//
//
// Ways of thinking:
//   Active patterns are functions which can be called in match expressions and can be piped also
//
// Properties:
//   Can have up to seven case names
//   Identifiable - the compiler will want you to exhaustive specifying all cases


// Declare Multicase active pattern
let (|Fizz|Buzz|FizzBuzz|Num|) n =
    match n % 3, n % 5 with
    | 0,0 -> FizzBuzz
    | 0,_ -> Fizz
    | _,0 -> Buzz
    | n -> Num n

// Using Multicase active patter
for num in [1..100] do
    match num with
    | FizzBuzz -> printfn "FizzBuzz"
    | Fizz -> printfn "Fizz"
    | Buzz -> printfn "Buzz"
    | n -> printfn "%i" n 


// FizzBuzz without active pattern
for num in [1..100] do
    match num % 3, num % 5 with
    | 0,0 -> printfn "FizzBuzz"
    | 0,_ -> printfn "Fizz"
    | _,0 -> printfn "Buzz"
    | _ -> printfn "%i" num


// Even/Odd active pattern
let (|Even|Odd|) n =
    if n % 2 = 0
    then Even
    else Odd

for num in [1..100] do
    match num with
    | Even -> printfn "%i is Even" num
    | Odd -> printfn "%i is Odd" num

let (|PNG|JPEG|JPG|GIF|) (fileName:string) =
    match Array.last(fileName.Split('.')) with
    | "png" -> PNG
    | "jpeg" -> JPEG
    | "jpg" -> JPG
    | _ -> GIF

let image = "image.png"

match image with
| PNG -> printfn "Do actions with .png images"
| JPEG -> printfn "Do actions with .jpeg images"
| JPG -> printfn "Do actions with .jpg images"
| GIF -> printfn "Do actions with .gif images"