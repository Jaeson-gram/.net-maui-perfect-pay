namespace Perfect_Pay;

public partial class MainPage : ContentPage
{
	//declaring the variables we'll be needin to carry out calculations

	decimal bill = 0; //the bill
	int tip = 0; //percentage to tip
	int numberOfPersons = 1; // number of persons to split amongst, 1 is the minimum

	public MainPage()
	{
		InitializeComponent();
	}



	//event handler invoked when the bill amount has been entered and completed
	private void billTextLabel_Completed(object sender, EventArgs e)
	{
		bill = decimal.Parse(billTextLabel.Text);
		calculateTotal();
	}																														




	//method to do the calculations we need
	private void calculateTotal()
	{
		//Total tip
		var totalTip = (bill * tip) / 100;

		//tip by person
		var tipByPerson = (totalTip / numberOfPersons);
		tipAmountLabel.Text = $"{tipByPerson:C}";

		//subtotal
		var subTotal = (bill / numberOfPersons);
		subTotalAmountLabel.Text = $"{subTotal:C}";

		//total
		var totalByPerson = (bill + totalTip) / numberOfPersons;
		totoalAmountLabel.Text = $"${totalByPerson}";


	}



	//event handler invoked when the slider is moved
	private void tipSlider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		tip = (int) tipSlider.Value;
		tipLabel.Text = $"Tip: {tip}%";
		calculateTotal();
	}



	//event handler invoked when any of the tip percentage buttons is clicked
	private void Button_Clicked(object sender, EventArgs e)
	{
		//make the sender usable as a button
		var btn = (Button)sender;

		//get the value (of our [now a button[) and replace the % with.. 'nothing'
		var percentage = int.Parse(btn.Text.Replace("%", ""));

		//get the new value (the one without a % sign), and use it to update the slider
		tipSlider.Value = percentage;
	}



	// event handler to update the number of persons when the minus button is clicked
	private void minusButton_Clicked(object sender, EventArgs e)
	{
		if (numberOfPersons > 1) //because we need at least 1 person for the account
		{
			numberOfPersons--;
		}

		numberOfPersonsLabel.Text = numberOfPersons.ToString();

		calculateTotal();
	}

    // event handler to update the number of persons when the minus button is clicked
    private void plusButton_Clicked(object sender, EventArgs e)
	{
		numberOfPersons++;

        numberOfPersonsLabel.Text = numberOfPersons.ToString();

        calculateTotal();
	}
}

