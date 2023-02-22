using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace curso_platzi_Inventory_3.Server.ServerService.InputOutputService
{
    public class InputOutputService : IInputOutputService
	{

		private readonly InventaryContext _context;
		public InputOutputService(InventaryContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(string id)
		{
			var dbInputOutput = await _context.InOuts.FindAsync(id);
			if (dbInputOutput == null)
			{
				return false;
			}

			_context.Remove(dbInputOutput);
			await _context.SaveChangesAsync();

			return true;
		}


		public async Task<List<InputOutputEntity>> GetInputOutputsList()
		{
			return await _context.InOuts.ToListAsync();
		}

		public async Task<InputOutputEntity?> Save(InputOutputEntity inputOutput)
		{
			_context.Add(inputOutput);
			await _context.SaveChangesAsync();
			return inputOutput;
		}

		public async Task<InputOutputEntity?> Update(string id, InputOutputEntity inputOutput)
		{
			var dbInputOutput = await _context.InOuts.FindAsync(id);
			if (dbInputOutput != null)
			{
				dbInputOutput.InOutDate = inputOutput.InOutDate;
				dbInputOutput.Quantity = inputOutput.Quantity;
				dbInputOutput.IsInput = inputOutput.IsInput;
				dbInputOutput.StorageId = inputOutput.StorageId;

				await _context.SaveChangesAsync();
			}

			return dbInputOutput;
		}
	}
}
