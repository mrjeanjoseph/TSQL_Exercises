enum Generation { BabyBoomer, GenX, Millenial, GenZ, GenAlpha, GenBeta }

class Person
{
    public required int BirthYear { get; init; }

    public Generation Generation =>
        BirthYear switch
        {
            (>= 1946) and (<= 1964) => Generation.BabyBoomer,
            (>= 1965) and (<= 1980) => Generation.GenX,
            (>= 1981) and (<= 1996) => Generation.Millenial,
            (>= 1997) and (<= 2012) => Generation.GenZ,
            (>= 2013) and (<= 2024) => Generation.GenAlpha,
            _ => Generation.GenBeta
        };
}
