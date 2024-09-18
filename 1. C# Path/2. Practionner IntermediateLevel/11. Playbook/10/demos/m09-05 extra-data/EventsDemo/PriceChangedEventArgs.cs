namespace Pluralsight.CShPlaybook.EventsDemo
{
    public delegate void PriceChangedEventHandler(object sender, PriceChangedEventArgs e);
 	public class PriceChangedEventArgs
		: EventArgs
	{
		public decimal OldPrice { get; init; }
		public PriceChangedEventArgs(decimal oldPrice)
		{
			OldPrice = oldPrice;
		}

	}
}
