// Learn more about F# at http://fsharp.org

open System

let squareRoot x =
    let isCloseEnough guess = 
        let acceptableVariance = x / 10000.0
        let guessSquared = guess * guess
        x - acceptableVariance < guessSquared &&
        x + acceptableVariance > guessSquared 
    
    let nextGuess y =
        (y + (x/y)) / 2.0

    let rec guessFn lastGuess =
        let closeEnough = isCloseEnough lastGuess
        match closeEnough with
        | true -> lastGuess
        | false -> lastGuess |> nextGuess |> guessFn 
    
    guessFn (x / 2.0)

[<EntryPoint>]
let main argv =
    squareRoot 100.0 |> printfn "%f"
    0 // return an integer exit code
