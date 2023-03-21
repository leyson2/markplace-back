using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {

        readonly IProductRepository _product;
        private IEnumerable<ProdctsDTOview> datos;

        public ProductsController(IProductRepository product)
        {
            _product = product;
    
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {

            try
            {
               this.datos = _product.GetAll();
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

        public async Task<ActionResult> Post(ProductDTOCreate product)
        {

            try { 
            if (product is null)
                return NoContent();


             await _product.Add(product);
            }
            catch (Exception e)
            {
                return BadRequest(new { men = "no se pudo guardar" +e});

            }
            return Ok(new { men = "Guardado con exito" });
        }


         [HttpGet("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          public async Task<ActionResult<ProdctsDTOview>> GetId([FromRoute] int id)
          {

              try
              {
                  var pais = await _product.GetById(id);

                  return Ok(pais);

              }
              catch (Exception e)
              {
                  return NoContent();

              }


          }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetId([FromRoute] int id, [FromBody] ProductDTOEdit productDTOEdit)
        {

            try
            {
                await _product.Update(id, productDTOEdit);

                return Ok();

            }
            catch (Exception e)
            {
                return NoContent();

            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> PostDelete(int id)
        {
            await _product.Delete(id);


            return Ok();
        }

    }
}
