using System.ComponentModel;

namespace Pluralsight.CShPlaybook.EventsDemo;
public class BookmarkProduct : INotifyPropertyChanged
{
	public string Id { get; init; }
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (value != _name)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }	private decimal _price;
	public decimal Price
	{
		get => _price;
		set
		{
			if (value != _price)
			{
				_price = value;
                OnPropertyChanged(nameof(Price));
			}
		}
	}
	private void OnPropertyChanged(string propName)
   	 	=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    public event PropertyChangedEventHandler? PropertyChanged;

    public BookmarkProduct(string id, string name, decimal price)
	{
		if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || price < 0.01m)
			throw new ArgumentException("Invalid product details");
		Id = id;
		_name = name;
		_price = price;
	}
}

