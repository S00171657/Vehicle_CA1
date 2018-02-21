using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Making lists for all vehicles and a filtered list
        ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Combox Setup
            //adding all the combobox items
            comboBox.Items.Add("Make");
            comboBox.Items.Add("Mileage");
            comboBox.Items.Add("Price");
            #endregion

            #region Vehicles
            Car c1 = new Car("Opel",
                "Astra",
                7500, 2010, 50000,
                "Nice car. NCT done last month.",
                1.6,
                "/Assets/Vehicles/Cars/astra.png");

            vehicles.Add(c1);

            Car c2 = new Car("Dodge",
                "Challenger",
                60000, 1970, 100000,
                "Powerful car",
                6.2,
                "/Assets/Vehicles/Cars/challenger.png");

            vehicles.Add(c2);

            Car c3 = new Car("Nissan",
                "Skyline",
                18000, 2000, 80000,
                "Needs new brakes.",
                2.5,
                "/Assets/Vehicles/Cars/skyline.png");

            vehicles.Add(c3);

            Bike b1 = new Bike("Harley Davidson",
                "Fatboy",
                12950, 2009, 20000,
                "Can't afford insurance, barely used.",
                1.5,
                "/Assets/Vehicles/Bikes/fatboy.png");

            vehicles.Add(b1);

            Bike b2 = new Bike("BMW",
                "1200 GS",
                5950, 2007, 40000,
                "Great bike. Reliable.",
                1.1,
                "/Assets/Vehicles/Bikes/patagonia_rider.png");

            vehicles.Add(b2);

            Bike b3 = new Bike("Susuki",
                "GSX-R125",
                4495, 2011, 21000,
                "Mint condition",
                0.6,
                "/Assets/Vehicles/Bikes/gsx-r125.png");

            vehicles.Add(b3);

            Van v1 = new Van("Chevrolet",
                "Express",
                9500, 2012, 110000,
                "Useful for carrying tools.",
                5.0,
                "/Assets/Vehicles/Vans/express.png");

            vehicles.Add(v1);

            Van v2 = new Van("Peugeot",
                "Partner",
                7700, 2014, 90000,
                "Reliable van.",
                1.6,
                "/Assets/Vehicles/Vans/partner.png");

            vehicles.Add(v2);

            Van v3 = new Van("Mercedes",
                "Sprinter",
                27500, 2018, 0,
                "Brand New.",
                2.2,
                "/Assets/Vehicles/Vans/sprinter.png");

            vehicles.Add(v3);

            lstVehicle.ItemsSource = vehicles;
            #endregion

        }

        #region Radio Buttons
        private void radCar_Checked(object sender, RoutedEventArgs e)
        {
            List<Vehicle> carList = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetType().Name == "Car")
                {
                    carList.Add(vehicle);
                }
            }

            lstVehicle.ItemsSource = carList;
        }

        private void radAll_Checked(object sender, RoutedEventArgs e)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            lstVehicle.ItemsSource = vehicles;

        }

        private void radBike_Checked(object sender, RoutedEventArgs e)
        {
            List<Vehicle> bikeList = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetType().Name == "Bike")
                {
                    bikeList.Add(vehicle);
                }
            }

            lstVehicle.ItemsSource = bikeList;
        }

        private void radVan_Checked(object sender, RoutedEventArgs e)
        {
            List<Vehicle> vanList = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.GetType().Name == "Van")
                {
                    vanList.Add(vehicle);
                }
            }

            lstVehicle.ItemsSource = vanList;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vehicle selectedVehicle = lstVehicle.SelectedItem as Vehicle;
            if (selectedVehicle != null)
            {
                vehicles.Remove(selectedVehicle);

                lblMake.Content = "";
                lblModel.Content = "";
                lblPrice.Content = "";
                lblYear.Content = "";
                lblMileage.Content = "";
                lblDesc.Content = "";
                lblEngine.Content = "";
                img.Source = null;
            }
        }
        #endregion
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Vehicle> sortedList;

            if (comboBox.SelectedIndex == 0)
            {
                sortedList = vehicles.OrderBy(o => o.Make).ToList();
                lstVehicle.ItemsSource = sortedList;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                sortedList = vehicles.OrderBy(o => o.Mileage).ToList();
                lstVehicle.ItemsSource = sortedList;
            }
            else if (comboBox.SelectedIndex == 2)
            {
                sortedList = vehicles.OrderBy(o => o.Price).ToList();
                lstVehicle.ItemsSource = sortedList;
            }
        }
        private void lstVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle selectedVehicle = lstVehicle.SelectedItem as Vehicle;

            if (selectedVehicle != null)
            {
                lblMake.Content = selectedVehicle.Make;
                lblModel.Content = selectedVehicle.Model;
                lblPrice.Content = selectedVehicle.Price;
                lblYear.Content = selectedVehicle.Year;
                lblMileage.Content = selectedVehicle.Mileage;
                lblDesc.Content = selectedVehicle.Desc;
                lblEngine.Content = selectedVehicle.Engine + " litre";

                Uri imageUri = new Uri(selectedVehicle.Image, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                img.Source = imageBitmap;
            }
        }
    }

}
