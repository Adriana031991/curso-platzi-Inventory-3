using curso_platzi_Inventory_3.Server.ServerService.InputOutputService;
using curso_platzi_Inventory_3.Server.ServerService.WareHouseService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_Inventory_3.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InputOutputController : ControllerBase
	{

		private readonly IInputOutputService _inputoutputService;

		public InputOutputController(IInputOutputService inputoutputService)
		{
			_inputoutputService = inputoutputService;
		}


		[HttpGet]
		public async Task<List<InputOutputEntity>> Get()
		{
			return await _inputoutputService.GetInputOutputsList();
		}


		[HttpPost]
		public async Task<InputOutputEntity?> CreateInputOutput(InputOutputEntity inputOutputEntity)
		{
			return await _inputoutputService.Save(inputOutputEntity);
		}

		[HttpPut("{id}")]
		public async Task<InputOutputEntity?> UpdateInputOutput(string id, InputOutputEntity inputOutputEntity)
		{
			return await _inputoutputService.Update(id, inputOutputEntity);
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteInputOutput(string id)
		{
			return await _inputoutputService.Delete(id);
		}
	}
}
