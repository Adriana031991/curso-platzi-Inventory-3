
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace curso_platzi_Inventory_3.Client.Service.InputOutputService
{
    public class InputOutputService : IInputOutputService
	{

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;
        public InputOutputService(HttpClient http, NavigationManager navigationManger)
		{
            _http = http;
            _navigationManger = navigationManger;
        }


        public List<InputOutputEntity> InputOutputsList { get; set; } = new List<InputOutputEntity>();



        public async Task Delete(string id)
		{
            await _http.DeleteAsync($"api/inputOutput/{id}");
            //_navigationManger.NavigateTo("product/list");
        }


		public async Task GetInputOutputsList()
		{
            var result = await _http.GetFromJsonAsync<List<InputOutputEntity>>("api/inputOutput");
			if (result is not null)
				InputOutputsList = result;
        }

		public async Task Save(InputOutputEntity inputOutput)
		{
            await _http.PostAsJsonAsync("api/inputOutput", inputOutput);
            //_navigationManger.NavigateTo("product/list");
        }

		public async Task Update(string id, InputOutputEntity inputOutput)
		{
            await _http.PutAsJsonAsync($"api/inputOutput/{id}", inputOutput);
            //_navigationManger.NavigateTo("product/list");
        }
	}
}
