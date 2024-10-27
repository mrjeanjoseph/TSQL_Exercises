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

string Space(int n) => string.Empty.PadLeft(n, ' ');
