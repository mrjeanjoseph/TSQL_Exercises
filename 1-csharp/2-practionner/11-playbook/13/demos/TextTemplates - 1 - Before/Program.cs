using Pluralsight.CShPlaybook.AttribsReflection;

string textTemplate = DataFileReader.ReadDataFile("ProductPromo.txt");
TextGenerator generator = new TextGenerator(textTemplate);

var product = new ComputerProduct("Deluxe gaming computer", ProductStatus.InStock, 999, "16GB", 8);
string result = generator.GenerateText(product);

Console.WriteLine(result);
