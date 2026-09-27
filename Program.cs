var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

//Rest api==> GET, POST, PUT, DELETE(HHTP verbs)




//json object response
app.MapGet("/hello",() =>
{
    var responsen = new
    {
        message = "this is a json object",
        success = true
    };

    return responsen;
});

app.MapGet("/hello",() =>
{
    return Results.Content("<h1>Hello World</h1>", "text/html");//200
});

var products = new List<Product>(){
new Product("samsung",1250),
new Product("apple",1350),   
};

app.MapGet("/products", () =>
{
    return Results. Ok(products);

});

app.Run();
public record Product(String Name , decimal Price);



