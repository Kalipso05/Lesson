using System;
using System.IO;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using Desktop.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace Desktop.View
{
	/// <summary>
	/// Логика взаимодействия для EmployeeAddWindow.xaml
	/// </summary>
	public partial class EmployeeAddWindow : Window
	{
		private static byte[] ImageBytes {  get; set; }
		private List<ViewDivisionModel> Divisions { get; set; }
		private List<ViewPositionModel> Positions { get; set; }
		public EmployeeAddWindow()
		{
			InitializeComponent();
			LoadData();	
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
			var positionId = cmbSelectPosition.SelectedIndex;
			var divisionId = cmbSelectDivision.SelectedIndex;

			if (txbName.Text != "" && txbPatronymic.Text != "" && txbSurname.Text != "")
			{
				if(positionId != 0 && divisionId != 0)
				{
					if (ImageBytes != null)
					{
						var employee = new ViewEmployeeRequestModel()
						{
							IdPosition = positionId,
							IdStructuralDivision = divisionId,
							Name = txbName.Text,
							Surname = txbSurname.Text,
							Patronymic = txbPatronymic.Text,
							Photo = ImageBytes
						};

						var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

						using(var client = new HttpClient())
						{
							var response = await client.PostAsync("https://localhost:44317/api/Employee/EmployeAdd", content);

							if(response.IsSuccessStatusCode)
							{
								MessageBox.Show("Сотрудник добавлен в базу данных!");
							}
							else
							{
								MessageBox.Show("Произошла ошибка!");
							}
						}
					}
					else
					{
						MessageBox.Show("Выберите фотографию");
					}
				}
				else
				{
					MessageBox.Show("Выберите подразделение и должность");
				}
			}
			else
			{
				MessageBox.Show("Имя, Фамилия, Отчество не должны быть пустыми");
			}
		}
	}
}
