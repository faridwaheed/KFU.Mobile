using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KFU.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class BuildingNumber
    {
        public string Name { get; set; }
    }
    public partial class SchoolSchedulePage : ContentPage
    {
        List<BuildingNumber> buildingNumbers = new List<BuildingNumber>()
        {
            new BuildingNumber()
            {
                Name="ASD"
            },
            new BuildingNumber()
            {
                Name="FGH"
            },
            new BuildingNumber()
            {
                Name="AAAWW "
            }
        };

        public SchoolSchedulePage()
        {
            InitializeComponent();
            BuildingList.ItemsSource = buildingNumbers;
            //BindingContext = new OrderInfoRepository();

            //SfDataGrid data = new SfDataGrid();

            //data.AutoGenerateColumns = false;

            //GridTextColumn orderIdColumn = new GridTextColumn();
            //orderIdColumn.MappingName = "OrderID";
            //orderIdColumn.HeaderText = "Order ID";

            //GridTextColumn customerIdColumn = new GridTextColumn();
            //customerIdColumn.MappingName = "CustomerID";
            //customerIdColumn.HeaderText = "Customer ID";

            //GridTextColumn customerColumn = new GridTextColumn();
            //customerColumn.MappingName = "Customer";
            //customerColumn.HeaderText = "Customer";

            //GridTextColumn countryColumn = new GridTextColumn();
            //countryColumn.MappingName = "ShipCountry";
            //countryColumn.HeaderText = "Ship Country";

            //data.Columns.Add(orderIdColumn);
            //data.Columns.Add(customerIdColumn);
            //data.Columns.Add(customerColumn);
            //data.Columns.Add(countryColumn);
            //OrderInfoRepository viewModel = new OrderInfoRepository();
            //data.ItemsSource = viewModel.OrderInfoCollection;
        }
    }
}