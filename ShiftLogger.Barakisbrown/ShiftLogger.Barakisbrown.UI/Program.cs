using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ShiftLogger.Barakisbrown.UI;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Repos;
using ShiftLogger.Barakisbrown.UI.UserInput;

var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app.log");
// LOG SETUP
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();


var services = new ServiceCollection();
services.AddHttpClient();
services.AddTransient<IEmployeeRepo, EmployeeRepo>();
services.AddTransient<IShiftRepo, ShiftsRepo>();
services.AddTransient<App>();
services.AddLogging(build => build.AddSerilog());


using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();
await app.Run();

Helper.ShowMsg("Thank you for using Shift Logger. Have a great day.");
Console.ReadKey(intercept: true);
// FLUSH LOG
Log.CloseAndFlush();

