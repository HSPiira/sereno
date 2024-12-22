using Microsoft.AspNetCore.Mvc;
using Sereno.Application.IService;
using Sereno.Core;
using Sereno.Infrastructure.Dtos;

namespace Sereno.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;
    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }
    [HttpGet("get-all")]
    public IActionResult GetAllSuppliers()
    {
        var suppliers = _supplierService.GetAllSuppliers();
        return Ok(suppliers);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddSupplier([FromBody] SupplierDto? supplierDto)
    {
        if (supplierDto == null)
            return BadRequest("Invalid supplier data.");

        var supplier = new 
            Supplier(
                Guid.NewGuid(), 
                supplierDto.Name, 
                supplierDto.Address
            );
        await _supplierService.AddAsync(supplier);

        return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.Id }, supplier);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSupplierById(Guid id)
    {
        var supplier = await _supplierService.GetByIdAsync(id);
        return Ok(supplier);
    }
    
    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateSupplier([FromBody] SupplierDto supplierDto, Guid id)
    {
        var supplier = await _supplierService.GetByIdAsync(id) 
                       ?? throw new ArgumentException("Supplier not found.");

        supplier.Name = supplierDto.Name;
        supplier.Address = supplierDto.Address;
        await _supplierService.UpdateAsync(supplier);

        return Ok(supplier);
    }
    
    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> DeleteSupplier(Guid id)
    {
        var supplier = await _supplierService.GetByIdAsync(id) 
                       ?? throw new ArgumentException("Supplier not found.");
        await _supplierService.DeleteAsync(id: supplier.Id);
        return NoContent();
    }
}