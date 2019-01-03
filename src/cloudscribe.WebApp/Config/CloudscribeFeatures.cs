using cloudscribe.WebApp.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CloudscribeFeatures
    {
        public static IServiceCollection SetupDataStorage(
            this IServiceCollection services,
            IConfiguration config
            )
        {
            var storage = config["DataOptions:DbType"];
            var efProvider = config["DataOptions:EFProvider"];

            switch (storage)
            {
                case "ef":

                    switch (efProvider)
                    {
                        case "sqlite":
                           
                            var slConnection = config.GetConnectionString("DataOptions:SQLiteConnectionString");
                            services.AddCloudscribeCoreEFStorageSQLite(slConnection);
                            services.AddCloudscribeLoggingEFStorageSQLite(slConnection);
                            services.AddCloudscribeSimpleContentEFStorageSQLite(slConnection);
                            
                            services.AddFormsStorageSQLite(slConnection);

                            break;
                            
                        case "pgsql":

                            var pgsConnection = config.GetConnectionString("DataOptions:PostgreSqlConnectionString");

                            services.AddCloudscribeCorePostgreSqlStorage(pgsConnection);
                            services.AddCloudscribeLoggingPostgreSqlStorage(pgsConnection);
                            services.AddCloudscribeSimpleContentPostgreSqlStorage(pgsConnection);
                            
                            services.AddFormsStoragePostgreSql(pgsConnection);

                            break;

                        case "MySql":
                            var mysqlConnection = config.GetConnectionString("DataOptions:MySqlConnectionString");
                            
                            services.AddCloudscribeCoreEFStorageMySql(mysqlConnection);
                            services.AddCloudscribeLoggingEFStorageMySQL(mysqlConnection);
                            services.AddCloudscribeSimpleContentEFStorageMySQL(mysqlConnection);
                            
                            services.AddFormsStorageMySql(mysqlConnection);

                            break;

                        case "MSSQL":
                        default:

                            var connectionString = config.GetConnectionString("DataOptions:MSSQLConnectionString");
                            
                            services.AddCloudscribeCoreEFStorageMSSQL(connectionString);
                            services.AddCloudscribeLoggingEFStorageMSSQL(connectionString);
                            services.AddCloudscribeSimpleContentEFStorageMSSQL(connectionString);
                            
                            services.AddFormsStorageMSSQL(connectionString);

                            break;
                    }

                    break;

                case "nodb":
                default:

                    services.AddCloudscribeCoreNoDbStorage();
                    services.AddCloudscribeLoggingNoDbStorage(config);
                    services.AddNoDbStorageForSimpleContent();
                    services.AddFormsStorageNoDb();

                    break;
            }

            

            return services;
        }

        public static IServiceCollection SetupCloudscribeFeatures(
            this IServiceCollection services,
            IConfiguration config
            )
        {

            services.AddCloudscribeLogging(config);


            services.AddScoped<cloudscribe.Web.Navigation.INavigationNodePermissionResolver, cloudscribe.Web.Navigation.NavigationNodePermissionResolver>();
            services.AddScoped<cloudscribe.Web.Navigation.INavigationNodePermissionResolver, cloudscribe.SimpleContent.Web.Services.PagesNavigationNodePermissionResolver>();
            services.AddCloudscribeCoreMvc(config);
            services.AddCloudscribeCoreIntegrationForSimpleContent(config);
            services.AddSimpleContentMvc(config);
            services.AddContentTemplatesForSimpleContent(config);

            services.AddMetaWeblogForSimpleContent(config.GetSection("MetaWeblogApiOptions"));
            services.AddSimpleContentRssSyndiction();

            services.AddFormsCloudscribeCoreIntegration(config);
            services.AddFormsServices(config);
            services.AddFormSurveyContentTemplatesForSimpleContent(config);

            services.AddScoped<cloudscribe.Forms.Models.IHandleFormSubmission, FakeFormSubmissionHandler1>();
            services.AddScoped<cloudscribe.Forms.Models.IHandleFormSubmission, FakeFormSubmissionHandler2>();

            return services;
        }

    }
}
