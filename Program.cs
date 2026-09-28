var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


//Get request at- /api/categories => Read Category
List<Category> categories = new List<Category>();
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

//Post request at- /api/categories => Create Category
app.MapPost("/api/categories", () =>
{
    var newCategory = new Category
    {
       CategoryId = Guid.NewGuid(),
        Name = "Electronics",
        Description = "computer, phone , laptop etc",
        CreatedAt = DateTime.UtcNow,
    };
    categories.Add(newCategory);
    
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);   
});


//Delete request at- /api/categories => Delete a Category
app.MapDelete("/api/categories/", () =>
{

    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("0728a615-8878-43ef-af7b-2ecb3ec2a43c"));

    if (foundCategory == null)
    {
        return Results.NotFound("category with this id not found");
    }
    return Results.NoContent();
});

//Put request at- /api/categories => Update a Category
app.MapPut("/api/categories/", () =>
{

    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("0728a615-8878-43ef-af7b-2ecb3ec2a43c"));

    if (foundCategory == null)
    {
        return Results.NotFound("category with this id not found");
    }
    foundCategory.Name = "Updated Category Name";
    foundCategory.Description = "Updated Category Description";
    return Results.NoContent();
});








app.Run();

public record Category
{
public Guid CategoryId { get; set; }
public string? Name { get; set; }
public string? Description { get; set; }
public DateTime CreatedAt{get; set;}
};




