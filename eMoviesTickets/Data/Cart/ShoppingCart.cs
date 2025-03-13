using eMoviesTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eMoviesTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context {  get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public string ShoppingCartId { get; set; }

        public ShoppingCart(AppDbContext context) 
        { 
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        //Add movie to cart
        public void AddShoppingCartItem(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id &&
            x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1,
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else { shoppingCartItem.Amount++; }
            _context.SaveChanges();
        }

        //Remove movies from the cart
        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id &&
            x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem.Amount != null)
            {
                if (shoppingCartItem.Amount > 1) 
                { 
                shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            
            _context.SaveChanges();

        }

        //Display all movies in the shoppingCart
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n=>n.Movie).ToList());

        }

        //Add the total cost of movies in the cart
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Movie.Price * n.Amount).Sum();
            return total;   
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems
                .Where(n=>n.ShoppingCartId==ShoppingCartId)
                .ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);

            await _context.SaveChangesAsync();

                    
        }
    }
}
