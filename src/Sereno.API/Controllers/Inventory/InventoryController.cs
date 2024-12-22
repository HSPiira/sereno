using Microsoft.AspNetCore.Mvc;
using Sereno.Application.Services.Inventory.Interfaces;
using Sereno.Core.Domains.Inventory.Entities;
using Sereno.Infrastructure.Dtos.Inventory;
using Sereno.Infrastructure.Dtos.Records;

namespace Sereno.API.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    [HttpGet("get-all")]
    public IActionResult GetAllInventoryItems()
    {
        var inventoryItems = _inventoryService.GetAllInventoryItems();
        return Ok(inventoryItems);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddInventoryItem([FromBody] InventoryItemDto? inventoryItemDto)
    {
        if (inventoryItemDto == null)
            return BadRequest("Invalid inventory data.");

        var inventoryItem = new 
            InventoryItem(
                Guid.NewGuid(), 
                inventoryItemDto.Name, 
                new ConcreteStockLevel (inventoryItemDto.StockLevel),
                inventoryItemDto.SupplierId,
                category: inventoryItemDto.Category
            );
        await _inventoryService.AddAsync(inventoryItem);
        return CreatedAtAction(nameof(GetInventoryItemById), new { id = inventoryItem.Id }, inventoryItem);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInventoryItemById(Guid id)
    {
        var inventoryItem = await _inventoryService.GetByIdAsync(id);
        return Ok(inventoryItem);
    }
    
    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateInventoryItem([FromBody] InventoryItemDto inventoryItemDto, Guid id)
    {
        var inventoryItem = await _inventoryService.GetByIdAsync(id) 
                       ?? throw new ArgumentException("Inventory item not found.");

        inventoryItem.Name = inventoryItemDto.Name;
        inventoryItem.Category = inventoryItemDto.Category;
        inventoryItem.StockLevel = new ConcreteStockLevel (inventoryItemDto.StockLevel);
        await _inventoryService.UpdateAsync(inventoryItem);

        return Ok(inventoryItem);
    }
    
    [HttpDelete("remove/{id:guid}")]
    public async Task<IActionResult> DeleteInventoryItem(Guid id)
    {
        var inventoryItem = await _inventoryService.GetByIdAsync(id) 
                       ?? throw new ArgumentException("Inventory item not found.");
        await _inventoryService.DeleteAsync(id: inventoryItem.Id);
        return NoContent();
    }
    
    [HttpPost("restock/{id:guid}")]
    public async Task<IActionResult> RestockItem(Guid id, [FromBody] int quantity)
    {
        try
        {
            var updatedItem = await _inventoryService.RestockAsync(id, quantity);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("deduct/{id:guid}")]
    public async Task<IActionResult> DeductStockItem(Guid id, [FromBody] int quantity)
    {
        try
        {
            var updatedItem = await _inventoryService.DeductStockAsync(id, quantity);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}