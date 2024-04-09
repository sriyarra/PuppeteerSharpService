// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;

Console.WriteLine("Hello, World!");

LaunchOptions launchOptions = new()
{
    Headless = false,
    ExecutablePath = @"C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe"
};
IBrowser browser = Puppeteer.LaunchAsync(launchOptions).Result;
//IBrowserContext context = await browser.CreateBrowserContextAsync();
IPage page = await browser.NewPageAsync();

await page.SetViewportAsync(new ViewPortOptions
{
    Width = 1200,
    Height = 900
});

await page.GoToAsync("https://www.facebook.com/");
await page.WaitForSelectorAsync("input[name='email']");
await page.TypeAsync("input[name='email']", "yar.srikanth@gmail.com");
await page.TypeAsync("input[name='pass']", "");
await page.ClickAsync("button[name='login']");

Thread.Sleep(5000);
await page.GoToAsync("https://www.facebook.com/784253392/allactivity?activity_history=false&category_key=MANAGEPOSTSPHOTOSANDVIDEOS&manage_mode=false&should_load_landing_page=false");

Thread.Sleep(5000);
await page.FocusAsync("input[name='comet_activity_log_select_all_checkbox']");
await page.Keyboard.PressAsync("Tab");
await page.Keyboard.PressAsync(" ");
await page.Keyboard.DownAsync("Shift");
await page.Keyboard.PressAsync("Tab");
await page.Keyboard.PressAsync("Tab");
await page.Keyboard.UpAsync("Shift");
await page.Keyboard.PressAsync(" ");
Thread.Sleep(2000);
await page.Keyboard.PressAsync("Tab");
await page.Keyboard.PressAsync("Tab");

await page.Keyboard.PressAsync(" ");


Console.ReadLine();
browser.CloseAsync();