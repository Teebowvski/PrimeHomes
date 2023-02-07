using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{



    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        public OrderService(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);


            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    PropertyId = item.Property.Id,
                    OrderId = order.Id,
                    Price = item.Property.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var data = await _context.Orders.ToListAsync();
            return data;
        }
    }
}