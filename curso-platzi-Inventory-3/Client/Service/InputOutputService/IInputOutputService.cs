using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Client.Service.InputOutputService
{
    public interface IInputOutputService
{
       
        List<InputOutputEntity> InputOutputsList { get; set; }
        Task GetInputOutputsList();
        Task Save(InputOutputEntity inputOutput);
		Task Update(string id, InputOutputEntity inputOutput);
		Task Delete(string id);
	}
}
