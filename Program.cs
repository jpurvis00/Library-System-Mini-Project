// See https://aka.ms/new-console-template for more information
using LibrarySystemMiniProject;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<ILibraryServices, LibraryServices>();
services.AddSingleton<IMemberServices, MemberServices>();
services.AddSingleton<IDataServices, JsonDataServices>();
services.AddSingleton<IMenuService, MenuService>();
services.AddSingleton<LibraryApp>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<LibraryApp>();
app.Run();
