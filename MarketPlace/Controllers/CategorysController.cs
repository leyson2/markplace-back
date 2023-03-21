using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {


      ICategoryRepository _category;
        private IEnumerable<Category> datos;

        public CategorysController(ICategoryRepository category)
        {
            _category = category;
        }

        public IProductRepository Category { get; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {

            try
            {
                this.datos = _category.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(datos);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Post(CategoryDTO  categoryDTO)
        {

            try
            {
                if (categoryDTO is null)
                    return NoContent();


                await _category.Add(categoryDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { men = "no se pudo guardar" });

            }
            return Ok(new { men = "Guardado con exito" });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Category>> GetId([FromRoute] int id)
        {

            try
            {
                var pais = await _category.GetById(id);

                return Ok(pais);

            }
            catch (Exception e)
            {
                return NoContent();

            }


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> PostDelete(int id)
        {

            try
            {
                await _category.Delete(id);

            }
            catch (Exception e)
            {
                return BadRequest(new { men = "no se pudo guardar" +e});

            }
            return Ok();
        }

    }
}
