using eMoviesTickets.Data.Cart;
using eMoviesTickets.Data.Services;
using eMoviesTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMoviesTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;

        private readonly OrdersService _ordersService;

        public OrdersController(MoviesService moviesService, ShoppingCart shoppingCart, OrdersService ordersService) 
        { 
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService; 
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrderByUserIdAsync(userId);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null) 
            { 
                _shoppingCart.AddShoppingCartItem(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        //
        public async Task<IActionResult> CompleteOrder() 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted"); 
        }
    }
}
