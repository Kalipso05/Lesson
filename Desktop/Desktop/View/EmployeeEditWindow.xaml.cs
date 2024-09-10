using Desktop.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Desktop.View
{
	/// <summary>
	/// Логика взаимодействия для EmployeeEditWindow.xaml
	/// </summary>
	public partial class EmployeeEditWindow : Window
	{
		private static ViewEmployeeModel _employeeModel;
		private static byte[] ImageBytes { get; set; }

		private List<ViewDivisionModel> Divisions { get; set; }
		private List<ViewPositionModel> Positions { get; set; }

		public EmployeeEditWindow(ViewEmployeeModel employee)
		{
			InitializeComponent();
			LoadData();
			_employeeModel = employee;
			txbName.Text = employee.Name;
			txbSurname.Text = employee.Surname;
			txbPatronymic.Text = employee.Patronymic;
			ImageBytes = employee.Photo;
		}



		public async Task<List<ViewPositionModel>> GetViewPositions()
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("https://localhost:44317/api/Data/position");
				var json = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ViewPositionModel>>(json);
			}
		}

		private async void LoadData()
		{
			Divisions = await GetViewDivisions();

			cmbSelectDivision.ItemsSource = Divisions;
			cmbSelectDivision.DisplayMemberPath = "Title";
			cmbSelectDivision.SelectedValuePath = "Id";

			Positions = await GetViewPositions();
			cmbSelectPosition.ItemsSource = Positions;
			cmbSelectPosition.DisplayMemberPath = "Title";
			cmbSelectPosition.SelectedValuePath = "Id";
		}

		public async Task<List<ViewDivisionModel>> GetViewDivisions()
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("https://localhost:44317/api/Data/division");
				var json = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ViewDivisionModel>>(json);
			}
		}

		private void SelectPhoto_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				string filePath = openFileDialog.FileName;
				ImageBytes = File.ReadAllBytes(filePath);
			}
		}

		private async void AddEmployee_Click(object sender, RoutedEventArgs e)
		{

			var positionId = Convert.ToInt32(cmbSelectPosition.SelectedValue);
			var divisionId = Convert.ToInt32(cmbSelectDivision.SelectedValue);

			var employee = new ViewEmployeeRequestModel()
			{
				Id = _employeeModel.Id,
				IdPosition = positionId == 0 ? (_employeeModel.IdPosition) : (positionId),
				IdStructuralDivision = divisionId == 0 ? (_employeeModel.IdStructuralDivision) : (divisionId),
				Name = _employeeModel.Name,
				Surname = _employeeModel.Surname,
				Patronymic = _employeeModel.Patronymic,
				Photo = ImageBytes
			};

			var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

			using (var client = new HttpClient())
			{
				var response = await client.PutAsync("https://localhost:44317/api/Employee/EmployeePut", content);

				if (response.IsSuccessStatusCode)
				{
					MessageBox.Show("Данные сотрудника были обновлены");
				}
				else
				{
					MessageBox.Show("Произошла ошибка!");
				}
			}



		}
	}
}
