﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data;
using OnlineStore.API.Data.Interfaces;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoriesController(ICategoryRepository repo)
        {
            _repo = repo;

        }
        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.ToListAsync();
            if(categories!=null)
            {
                return Ok(categories);
            }
            return BadRequest("Categories NULL");
            
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repo.GetItemAsync(id);
            return Ok(category);
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody] string category)
        {
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string category)
        {
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}