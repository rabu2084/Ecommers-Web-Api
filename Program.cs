var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//Rest api==> GET, POST, PUT, DELETE(HHTP verbs)
app.MapPut("/",() =>
{
    return "Default Method: hello";
});


app.MapGet("/hello",() =>
{
    return "Get Method: hello";
});

app.MapPut("/hello",() =>
{
    return "Put Method: hello";
});

app.MapDelete("/hello",() =>
{
    return "Delete Method: hello";
});



app.Run();



