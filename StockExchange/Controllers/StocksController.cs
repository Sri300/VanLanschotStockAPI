using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StockExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
              
		private IConfiguration configuration;
		public StocksController(IConfiguration iConfig)
		{
			 configuration = iConfig;
		}

		// GET: api/BuyStocks/5
		[HttpGet("buy/{numStocks}")]
		public ActionResult<string> BuyStocks(int numStocks)
		{
			double appleSharePrice = double.Parse(configuration.GetSection("AppleSharePrice").Value);
			if (numStocks < 1)
			{
				return Content($"status: {"Failed"} Message:{"Order execution failed. Number of stocks should be >0"} "); ;
			}
			var total_price = numStocks * appleSharePrice;
			// buy stock here numStocks, apple_share_price

			return Ok($"status: {"Success"} Message:{"Order executed successfully"} Total Price:{"Total Price:" + total_price}");
		}

	}
}
