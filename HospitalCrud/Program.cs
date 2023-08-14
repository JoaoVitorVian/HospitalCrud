using HospitalCrud.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server;
using HospitalCrud.Service.interfaces;
using HospitalCrud.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie();

builder.Services.AddAuthorization();


builder.Services.AddScoped<CustomAuthenticationStateProvider>();


builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
     options.SignIn.RequireConfirmedAccount = false;
    })
   .AddRoles<IdentityRole>()
   .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roleExistsMedico = await roleManager.RoleExistsAsync("medico");
    if (!roleExistsMedico)
    {
        await roleManager.CreateAsync(new IdentityRole("medico"));
    }

    var roleExistsPaciente = await roleManager.RoleExistsAsync("paciente");
    if (!roleExistsPaciente)
    {
        await roleManager.CreateAsync(new IdentityRole("paciente"));
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
