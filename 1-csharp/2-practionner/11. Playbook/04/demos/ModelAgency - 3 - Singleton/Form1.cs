namespace Pluralsight.CShPlaybook.Oop;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		// store hard-coded dogs in the listbox
		CanineModel josie = new(1, "Josie", "Julie Lerman");
		CanineModel bouncy = new(2, "Bouncy", "Barry");
		CanineModel fluffy = new(3, "Fluffy", "Fred");
		CanineModel lazy = new(4, "Lazy", "Larry");
		CanineModel greedy = new(5, "Greedy", "Greg");

		CanineModel[] models = {josie, fluffy, lazy, bouncy, greedy};
		this.lbxModels.DataSource = models;
	}

	private void lbxModels_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{

			if (lbxModels.SelectedItem is ModelBase model)
			{
				this.pbxPhoto.Image = model.PhotoProvider.GetPhoto();
				this.tbxName.Text = model.Name;
				this.tbxHuman.Text = (model as CanineModel)?.CompanionHuman;
			}
			else
			{
				this.pbxPhoto.Image = null;
				this.tbxName = null;
				this.tbxHuman = null;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error displaying photo");
		}
		
	}
}
