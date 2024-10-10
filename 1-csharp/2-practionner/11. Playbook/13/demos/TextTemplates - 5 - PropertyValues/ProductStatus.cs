namespace Pluralsight.CShPlaybook.AttribsReflection;

public enum ProductStatus
{
    [FriendlyTextAttribute("In stock")]
    InStock,

    [FriendlyTextAttribute("Out of stock")]
    OutOfStock,

    [FriendlyTextAttribute("No longer available")]
    Discontinued,

    [FriendlyTextAttribute("Coming soon!")]
    NotYetLaunched
}

