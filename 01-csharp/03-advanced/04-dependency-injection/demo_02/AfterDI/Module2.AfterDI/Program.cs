using Module2.AfterDI;
using Module2.AfterDI.Shared;
using Module2.AfterDI.Source;
using Module2.AfterDI.Target;

var configuration = new Configuration();
var priceParser = new PriceParser();

var productSource = new ProductSource(configuration, priceParser);

var productFormatter = new ProductFormatter();

var productTarget = new ProductTarget(configuration, productFormatter);

var productImporter = new ProductImporter(productSource, productTarget);
productImporter.Run();