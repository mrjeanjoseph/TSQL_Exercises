namespace Module2.DIApplied.Shared;
public class Configuration
{
    // We will deal with passing in configuration in a better way in a future module
    // For now hardcoding the values is enough to practice with the concepts from this module

    public string SourceCsvPath => @"c:\src-pluralsight\product-input.csv";
    public string TargetCsvPath => @"c:\src-pluralsight\product-output.csv";
}