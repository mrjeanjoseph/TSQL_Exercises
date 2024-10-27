namespace fscalc

type public Calculator =
    static member Add (a : double, b : double) = a + b
    static member Subtract (a : double, b : double) = a - b
    static member Multiply (a : double, b : double) = a * b
    static member Divide (a : double, b : double) = a / b