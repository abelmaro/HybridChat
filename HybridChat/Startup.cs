using HybridChat.Data;
using HybridChat.Hubs;
using HybridChat.Services;
using HybridChat.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HybridChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddDbContext<ChatContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("HybridChat")));

            services.AddSwaggerGen(s =>
                s.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "HybridChat", Version = "v1"})
            );

            services.AddSignalR();

            services.AddScoped<IHybridChatHub, HybridChatHub>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                    s.SwaggerEndpoint(url: "/swagger/swagger/v1/swagger.json", name: "HybridChat v1");
                }
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<HybridChatHub>("/chathub");
            });
        }
    }
}
