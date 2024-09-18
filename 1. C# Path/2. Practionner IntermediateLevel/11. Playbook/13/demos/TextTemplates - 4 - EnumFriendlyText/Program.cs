using Pluralsight.CShPlaybook.AttribsReflection;

string textTemplate = DataFileReader.ReadDataFile("ProductPromoV2.txt");
TextGenerator generator = new TextGenerator(textTemplate);

var product = new ComputerProduct("Deluxe gaming computer", ProductStatus.InStock, 999, "16GB", 8);
string result = generator.GenerateTextV2(product);

Console.WriteLine(result);
