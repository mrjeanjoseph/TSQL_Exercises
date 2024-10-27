namespace Pluralsight.CShPlaybook.MethodsProps;

public class BusinessRules
{
	public static bool EligibleForVoucher(int nPurchases, decimal biggestPurchase)
		=> nPurchases > 5 && biggestPurchase > 100m;
}
