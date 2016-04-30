using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace HelloWebApi
{
    public class EntLibConfig
    {
        public static void Register()
        {
            // could be moved to configuration file
            // putting configuration here to keep things simple
            var builder = new ConfigurationSourceBuilder();

            // add exception handling policy configuration
            builder.ConfigureExceptionHandling()
                .GivenPolicyWithName("ServiceAbend")
                    .ForExceptionType<Exception>()
                        .LogToCategory("General")
                        .ThenDoNothing();

            // add logging configuration
            builder.ConfigureLogging()
                .LogToCategoryNamed("General")
                    .WithOptions.SetAsDefaultCategory()
                    .SendTo.FlatFile("FlatFile TraceListener")
                        .ToFile("exceptions.log")
                        .FormatWith(new FormatterBuilder()
                            .TextFormatterNamed("Text Formatter"));

            // build the configuration
            var config = new DictionaryConfigurationSource();
            builder.UpdateConfigurationWithReplace(config);

            // configure logger static facade
            LogWriterFactory logWriterFactory = new LogWriterFactory(config);
            Logger.SetLogWriter(logWriterFactory.Create());

            // configure exception policy static facade
            ExceptionPolicyFactory exceptionPolicyFactory = new ExceptionPolicyFactory(config);
            ExceptionPolicy.SetExceptionManager(exceptionPolicyFactory.CreateManager());
        }
    }
}