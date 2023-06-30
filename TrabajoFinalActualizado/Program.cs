using TrabajoFinalActualizado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .Add(new ServiceDescriptor(typeof(IUsuario),
    new UsuarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IMantenimiento), new MantenimientoRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IRegistrar),
    new RegistrarRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IGenero),
    new GeneroRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IUserTemporal),
    new UserTemporalRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IPelicula),
    new PeliculaRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IVentaTemporal),
    new VentaTemporalRepository()));
builder.Services
    .Add(new ServiceDescriptor(typeof(IDatosDelPago),
    new DatosDelPagoRepository()));

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pelicula}/{action=Index}/{id?}");

app.Run();
