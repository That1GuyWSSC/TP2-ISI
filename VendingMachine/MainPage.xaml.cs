using Microsoft.VisualBasic;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            
            
            InitializeComponent();
        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var apiClient = new CategoryApiClient(httpClient);

            //chamar metodo da api para guardar os valores da nova categoria
            var newCategory = new Category
            {
                Name = name.Text,
                Description = string.IsNullOrWhiteSpace(description.Text) ? null : description.Text
            };

            var createdCategory = await apiClient.CreateCategoryAsync(newCategory);

            name.Text = null;
            description.Text = null;
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {
            name.Text = null;
            description.Text = null;
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var apiClient = new CategoryApiClient(httpClient);

            long id2 = Convert.ToInt64(id.Text);

            var success = await apiClient.DeleteCategoryAsync(id2);
            id.Text = null;
        }

        private async void search_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var apiClient = new CategoryApiClient(httpClient);

            long id = Convert.ToInt64(id_search.Text);

                var category = await apiClient.GetCategoryByIdAsync(id);
                if (category != null)
                {
                    name_search.Text = category.Name;
                    description_search.Text = category.Description;
                }
                else
                {
                    await DisplayAlert("Alert", "Id não existe", "OK");
                    id_search.Text = null;
                }

        }

        private void searchCancel_Clicked(object sender, EventArgs e)
        {
            name_search.Text = null;
            description_search.Text = null;
        }
    }

}
