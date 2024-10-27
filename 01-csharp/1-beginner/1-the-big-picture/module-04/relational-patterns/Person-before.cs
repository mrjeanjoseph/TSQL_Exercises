enum Generation { BabyBoomer, GenX, Millenial, GenZ, GenAlpha, GenBeta }

class Person
{
    public required int BirthYear { get; init; }

    public Generation Generation
    {
        get
        {
            if ((BirthYear >= 1946) && (BirthYear <= 1964))
            {
                return Generation.BabyBoomer;
            }
            else if ((BirthYear >= 1965) && (BirthYear <= 1980))
            {
                return Generation.GenX;
            }
            else if ((BirthYear >= 1981) && (BirthYear <= 1996))
            {
                return Generation.Millenial;
            }
            else if ((BirthYear >= 1997) && (BirthYear <= 2012))
            {
                return Generation.GenZ;
            }
            else if ((BirthYear >= 2013) && (BirthYear <= 2024))
            {
                return Generation.GenAlpha;
            }
            else
            {
                return Generation.GenBeta;
            }
        }
    }
}
