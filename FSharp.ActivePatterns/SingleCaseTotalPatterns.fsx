//              ******* Single Case Total Patterns *******
//                              Syntax
// let (|identifier|) [arguments] valueToMatch = expression // template
// 
// identifier   - name of the Active Pattern (like function name or value name)
// arguments    - arguments which you want to pass to the Active pattern (optional)
// valueToMatch - value over which the matching should happen
// expression   - the match condition
// 
// Example:
//   let (|Rect|) (number:Complex) = Rect(number.Real, number.Imaginary) // no arguments
//
// Usage:
//   Used to decompose values in different ways, whem the underlying type has multiple representations.
//   You can think of these type of patterns as converters, from one type to another.
//   You can use these patterns to represent one type in a different ways. (like Database views.)
//   You can use them to deconstruct multiple values and perform computations on the values
//
//
// Ways of thinking:
//   Active patterns are functions which can be called in match expressions and can be piped also
//

open System.Numerics
let (|Rect|) (number:Complex) = Rect(number.Real, number.Imaginary)
let (|Polar|) (number:Complex) = Polar(number.Magnitude, number.Phase)
let x = Complex(2.0, 3.0)
let y = Complex(1.0, 2.0)

//Simple one param match
match x with
| Rect (r,i) -> printfn "%f - %f" r i

//Active pattern as function
let result = (|Rect|) x

//Tuple matching expresion with "Rect" active pattern
//Used to generate view of the Data
match x, y with
| Rect (r1,i1), Rect (r2,i2) -> Complex(r1+r2, i1+i2)

//Tuple matching expresion with "Polar" active pattern
//Used to generate view of the Data
match x,y with
| Polar (m1,ph1), Polar(m2, ph2) -> Complex(m1+m2, ph1+ph2);



type Person = { fName:string; mName:string; lName:string; age:int; email:string; }

let (|Name|) person = (person.fName, person.mName, person.lName)

let person = { fName = "Stefan"; mName="Yordanov"; lName = "Peev"; age = 27; email = "stefoajc@abv.bg"; }

let getFullName (person:Person) =
    match person with
    | Name (fName, mName, lName) -> (fName + " " + mName + " " + lName)

let fullName = 
    match person with
    | Name (fName, mName, lName) -> (fName + " " + mName + " " + lName)

let (|Age|) person = person.age

let personAgeUsingActivePattern = 
    match person with
    | Age a -> a

//Without Active pattern Age
let personAgeWithoutActivePattern = person.age

//Without Active pattern FullName
let personFullNameWithoutActivePattern = person.fName + person.lName


//Single case patterns with argument
let (|Test|) (arg:int) (valueToMatch:int) =
    valueToMatch

match 1 with
| Test  1 1 -> 1 // this case is activated
| _ -> 10

match 2 with
| Test 1 1 -> 1 
| Test 1 2 -> 2 // this case is activated
| _ -> 10