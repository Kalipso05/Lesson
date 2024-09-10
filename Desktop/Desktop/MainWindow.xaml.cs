using Desktop.Model;
using Desktop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Desktop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			LoadEmployees();
		}

		private async void LoadEmployees()
		{
			using (var client = new HttpClient())
			{
				string url = "https://localhost:44317/api/Employee/EmployeeGet";
				var response = await client.GetAsync(url);
				if(response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var employees = JsonConvert.DeserializeObject<List<ViewEmployeeModel>>(json);
					listView.ItemsSource = employees;
				}
			}
		}

		private void UpdateWindow_Click(object sender, RoutedEventArgs e)
		{
			LoadEmployees();
		}

		private void AddEmployee_Click(object sender, RoutedEventArgs e)
		{
			var win = new EmployeeAddWindow();
			win.Show();
		}

		private void EmployeeEdit_Click(object sender, RoutedEventArgs e)
		{
			var selectedEmployee = listView.SelectedItem as ViewEmployeeModel;

			var win = new EmployeeEditWindow(selectedEmployee);
			win.Show();

        }

		private async void EmployeeDelete_Click(object sender, RoutedEventArgs e)
		{
			var selectedEmployee = listView.SelectedItem as ViewEmployeeModel;

			using(var client = new HttpClient())
			{
				var response = await client.DeleteAsync($"https://localhost:44317/api/Employee/EmployeeDelete/{selectedEmployee.Id}");

				if (response.IsSuccessStatusCode)
				{
					MessageBox.Show("Сотрудник был удален");
					LoadEmployees();
				}
				else
				{
					MessageBox.Show("Произошла ошибка");
				}
			}
		}
	}
}
