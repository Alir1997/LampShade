using _0_FrameWork.Application;

namespace InventoryManagement.Application.Contract.Inventory;

public interface IInventoryApplication
{
    OpretionResult Create(CreateInventory command);
    OpretionResult Edit(EditInventory command);
    OpretionResult Increase(IncreaseInventory command);
    OpretionResult Reduce(ReduceInventory command);
    OpretionResult Reduce(List<ReduceInventory> command);
    EditInventory GetDetails(long id);
    List<InventoryViewModel> Search(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
}