using Pluralsight.CShPlaybook.AttribsReflection;

string textTemplate = DataFileReader.ReadDataFile("ProductPromoV2.txt");
TextGenerator generator = new TextGenerator(textTemplate);

var product = new ToyProduct("Space-ship building blocks", ProductStatus.NotYetLaunched, 20, "3-7 years", "Construction toys", "500 g");
//var product = new ComputerProduct("Deluxe gaming computer", ProductStatus.InStock, 999, "16GB", 8);
string result = generator.GenerateTextV2(product);

Console.WriteLine(result);
