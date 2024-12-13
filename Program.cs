using Kapitoshka.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// добавление данных
using (NodeContext db = new())
{
    var nodes = db.Nodes.ToList();
    if (nodes.Count == 0)
    {
        // создаем объекты Node
        Node node1  = new() { name = "Спортивные секции", quantity = 0, childrenId = {2, 3, 6 } };
        Node node2  = new() { name = "Футбол", quantity = 5, parentId = 1 };
        Node node3  = new() { name = "Цирковая школа", quantity = 0, parentId = 1, childrenId = {4, 5 } };
        Node node4  = new() { name = "Клоунада", quantity = 6, parentId = 3 };
        Node node5  = new() { name = "Эквилибристика", quantity = 4, parentId = 3 };
        Node node6  = new() { name = "Иппотерапия", quantity = 7, parentId = 1 };
        Node node7  = new() { name = "Творческие студии", quantity = 0, childrenId = {8, 13 } };
        Node node8  = new() { name = "Изобразительное искусство", quantity = 0, parentId = 7, childrenId = {9, 12 } };
        Node node9  = new() { name = "Живопись", quantity = 0, parentId = 8, childrenId = { 10, 11 } };
        Node node10 = new() { name = "Гуашь", quantity = 3, parentId = 9 };
        Node node11 = new() { name = "Масло", quantity = 2, parentId = 9 };
        Node node12 = new() { name = "Графика", quantity = 4, parentId = 8};
        Node node13 = new() { name = "Литература", quantity = 0, parentId = 7, childrenId = { 14, 15 } };
        Node node14 = new() { name = "Поэзия", quantity = 1, parentId = 13 };
        Node node15 = new() { name = "Проза", quantity = 1, parentId = 13 };
        Node node16 = new() { name = "Технические кружки", quantity = 0, childrenId = { 17, 20 } };
        Node node17 = new() { name = "Робототехника", quantity = 0, parentId = 16, childrenId = {18, 19 } };
        Node node18 = new() { name = "LEGO Mindstorms", quantity = 6, parentId = 17 };
        Node node19 = new() { name = "Arduino", quantity = 2, parentId = 17 };
        Node node20 = new() { name = "Моделирование", quantity = 5, parentId = 16 };

        // добавляем их в бд
        db.Nodes.AddRange(node1, node2, node3, node4, node5, node6, node7, node8, node9, node10
            , node11, node12, node13, node14, node15, node16, node17, node18, node19, node20);
        db.SaveChanges();
    }
    
}

app.Run();
