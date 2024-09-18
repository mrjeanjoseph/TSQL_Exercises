using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

var repository = new ClientRepository("connection string");
GardenClient client = repository.GetClientFromId(1);

ConsoleLogger logger = new ConsoleLogger();
client.Logger = logger;

client.SaveCart();

client.LogMyself();


