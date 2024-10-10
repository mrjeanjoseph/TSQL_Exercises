using Pluralsight.CShPlaybook.Generics;

TreeNode<string> ceo = new("Simon");
var financeHead = ceo.AddChild("Ramdevi");
var cto = ceo.AddChild("Deborah");
financeHead.AddChild("Mohammed");
financeHead.AddChild("PingPing");
var teamLeader = cto.AddChild("Jenifer");
teamLeader.AddChild("Volodymyr");
teamLeader.AddChild("Aruna");
cto.AddChild("Femi");

foreach (var tuple in ceo.EnumerateSelfAndDescendantsWithDepth())
    Console.WriteLine(Space(2 * tuple.Depth) + tuple.Value);


Location kyiv = Location.MakeTown("Kyiv");
Location kharkiv = Location.MakeTown("Kharkiv");
Location lviv = Location.MakeTown("Lviv");
Location portLouis = Location.MakeTown("Port Louis");
Location quatreBornes = Location.MakeTown("Quatre Bornes");
Location ukraine = Location.MakeCountry("Ukraine");
Location mauritius = Location.MakeCountry("Mauritius");
Location curepipe = Location.MakeTown("Curepipe");

TreeNode<Location> earthNode = new(Location.Earth);
var mauritiusNode = earthNode.AddChild(mauritius);
var ukraineNode = earthNode.AddChild(ukraine);
mauritiusNode.AddChild(portLouis);
mauritiusNode.AddChild(quatreBornes);
mauritiusNode.AddChild(curepipe);
ukraineNode.AddChild(kyiv);
ukraineNode.AddChild(lviv);
ukraineNode.AddChild(kharkiv);

Console.WriteLine();
foreach (var node in earthNode.EnumerateSelfAndDescendantsWithDepth())
    Console.WriteLine($"{Space(3 * node.Depth)}{node.Value.Type}: {node.Value.Name}");


string Space(int n) => string.Empty.PadLeft(n, ' ');
