using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.ServerService.InputOutputService
{
    public interface IInputOutputService
{
		Task<List<InputOutputEntity>> GetInputOutputsList();
		Task<InputOutputEntity?> Save(InputOutputEntity inputOutput);
		Task<InputOutputEntity?> Update(string id, InputOutputEntity inputOutput);
		Task<bool> Delete(string id);
	}
}
