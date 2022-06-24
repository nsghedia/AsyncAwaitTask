using AsyncAwaitTaskDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncAwaitTaskDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await TestMethod1();
            Console.WriteLine(await TestMethod2());
            Console.WriteLine(await TestMethod3());
            Console.WriteLine(await TestMethod4());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public Task TestMethod1()
        {
            Console.WriteLine("I done with the task");
            return Task.CompletedTask;
        }

        public Task<string> TestMethod2()
        {
            string str = "I done with the task and I am returning some value";
            return Task.FromResult(str);
        }

        public async Task<string> TestMethod3()
        {
            string str = "My name is Neha Ghedia";
            return await Task.FromResult(str);
        }

        public async Task<string> TestMethod4()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("Some Site");
            return content;
        }

        public async Task<string> TestMethod5()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("Some Site")
                .ConfigureAwait(false);
            return content;
        }


    }
}