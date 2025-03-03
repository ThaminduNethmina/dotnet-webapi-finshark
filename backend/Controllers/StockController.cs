using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.DTOs.Stock;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stockDTO = stocks.Select(s => s.ToStockDTO());
            return Ok(stockDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(stock.ToStockDTO());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            var stock = stockDTO.ToStockFromCreateDTO();
            var newStock = await _stockRepository.CreateAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, stock.ToStockDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO updateDTO)
        {
            var stock = await _stockRepository.UpdateAsync(id, updateDTO);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDTO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}