using Pluralsight.CShPlaybook.DrawingStuff;

DrawTextBox tbx = new("Pluralsight is Fab!", 4);
DrawTextBox tbx1 = new(tbx.Text, 10);
DrawTextBox tbx2 = tbx1.BringForward();

Console.WriteLine($"{tbx2.Text}, Z-index={tbx2.ZIndex}");