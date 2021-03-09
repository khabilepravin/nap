using Autofac;
using Autofac.Extensions.DependencyInjection;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using graphqlMiddleware.GraphTypes;
using graphqlMiddleware.Mutations;
using graphqlMiddleware.NapSchema;
using graphqlMiddleware.Queries;
using logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;

namespace napclient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            
            //services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<ISchema, TestSchema>();
           // services.AddSingleton<ISchema, UserSchema>();
            services.AddSingleton<TestQuery>();
            services.AddSingleton<TestMutation>();
            services.AddSingleton<TestType>();
            services.AddSingleton<QuestionType>();
            services.AddSingleton<TestInputType>();
            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserType>();
            services.AddSingleton<QuestionInputType>();
            services.AddSingleton<AnswerType>();
            services.AddSingleton<AnswerInputType>();
            services.AddSingleton<ExplanationInputType>();
            services.AddSingleton<ExplanationType>();
            services.AddSingleton<LookupGroupType>();
            services.AddSingleton<LookupGroupInputType>();
            services.AddSingleton<LookupValueType>();
            services.AddSingleton<LookupValueInputType>();
            services.AddSingleton<UserTestInputType>();
            services.AddSingleton<UserTestRecordInputType>();
            services.AddSingleton<UserTestType>();
            services.AddSingleton<UserTestRecordType>();
            services.AddSingleton<QuestionFileType>();
            services.AddSingleton<AnswerFileType>();
            services.AddSingleton<UserInputType>();
            
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson(seserializerSettings => { }, serializerSettings => { })
            .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddControllers();
            //services.AddApiVersioning();
            //services.AddMvc(option => option.EnableEndpointRouting = false);

            // In production, the React files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});

            services.AddControllers();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            dataAccess.DataBootstrapper.Boostrap(containerBuilder);
            graphqlMiddleware.GraphqlBootstrapper.Bootstrap(containerBuilder);
            LogicBootstrapper.Bootstrap(containerBuilder);
            externalServices.ExternalServicesBootstrapper.Bootstrap(containerBuilder);
            this.Container = containerBuilder.Build();

            return new AutofacServiceProvider(this.Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            //app.UseCors("Nap_Policy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>("/graphql");
            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });

            app.UseGraphQLVoyager();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
            
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
        }
    }
}
