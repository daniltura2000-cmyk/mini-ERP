var builder = WebApplication.CreateBuilder(args);

// 1. ДОБАВЛЯЕМ СЕРВИСЫ КОНТРОЛЛЕРОВ В КОНТЕЙНЕР (Этого не хватало!)
builder.Services.AddControllers();

// Твоя настройка OpenAPI (оставляем)
builder.Services.AddOpenApi();

var app = builder.Build();

// Настройка конвейера запросов
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 2. НАСТРАИВАЕМ МАРШРУТИЗАЦИЮ НА НАШИ КОНТРОЛЛЕРЫ (И этого не хватало!)
app.MapControllers();

app.Run();