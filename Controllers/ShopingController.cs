using Financial_Stock.DTO;
using Financial_Stock.Model;
using Financial_Stock.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Stock.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ShopingController : ControllerBase
    {
        public Context context;
        public IOrderReposatry orderrepo;
        
        ShopingController(Context _context, IOrderReposatry _orderrepo)
        {
            context = _context;
            orderrepo = _orderrepo;

        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(Orderdto orderdto)
        {
            Orders orders =new Orders();

            if(ModelState.IsValid)
            {
                orders.Name=orderdto.Name;
                orders.Price=orderdto.Price;
                orders.Stock=orderdto.Stock;
                orders.OrderStatus=orderdto.OrderStatus;
                orders.AverageExecutionPrice=orderdto.AverageExecutionPrice;
                orders.ExecutedQuantity=orderdto.ExecutedQuantity;
                orders.Quantity=orderdto.Quantity;
                orders.Created_At=orderdto.Created_At; 
                orders.StockID=orderdto.StockID;
                orders.TimeOfLastModification=orderdto.TimeOfLastModification;
                orders.TimeOfSubmission=orderdto.TimeOfSubmission;
                orders.ClientOrderID=orderdto.ClientOrderID;

                return Ok();

            }

            return BadRequest("Error in registering the purchase of the share. Please make sure that the entered data or the email registration process is correct.");

        }

        [HttpPut("{id}")] //http restfull api
        public IActionResult Update(int id,Orders order)
        {
            Orders ord = new Orders();
            var update=orderrepo.Update(id, order);
            Orders orde=context.orders.FirstOrDefault(o => o.Id==id);

            if(ModelState.IsValid)
            {
                if(orde!=null)
                {
                    ord.Name=orde.Name;
                    ord.Price=orde.Price;
                    ord.Stock=orde.Stock;
                    ord.OrderStatus=orde.OrderStatus;
                    ord.AverageExecutionPrice=orde.AverageExecutionPrice;
                    ord.ExecutedQuantity=orde.ExecutedQuantity;
                    ord.Quantity=orde.Quantity;
                    ord.Created_At=orde.Created_At;
                    ord.StockID=orde.StockID;
                    ord.TimeOfLastModification=orde.TimeOfLastModification;
                    ord.TimeOfSubmission=orde.TimeOfSubmission;
                    ord.ClientOrderID = orde.ClientOrderID;

                    return Ok();

                }
                else
                {
                    return BadRequest("Error You must make sure that you did not leave the available fields blank and you must enter the correct statement.");
                }
            }
            return BadRequest("Error You must make sure that you did not leave the available fields blank and you must enter the correct statement.");

        }

        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            var order = context.orders.FirstOrDefault(o => o.Id==id);
            context.orders.Remove(order);   

            int raw =context.SaveChanges();
            return Ok(raw);

        }

    
    }
    
}
