﻿using System;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console.Settings {
    public static class LogServiceCollectionExtensions {
        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services) {
            return services.RegisterToRunsOnConsole();
        }

        public static ILogServiceCollection RunsOnConsole(this ILogServiceCollection services, Action<LoggingSettings> settingsAction) {
            if (services.ExposeLogSettings() is LoggingSettings settings) {
                settingsAction?.Invoke(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        public static ILogServiceCollection RunsOnConsole<TLoggingSettings>(this ILogServiceCollection services, TLoggingSettings settings)
            where TLoggingSettings : LoggingSettings, new() {
            if (services is ConsoleLogServiceCollection collection) {
                collection.ReplaceSettings<TLoggingSettings>(settings);
            }

            return services.RegisterToRunsOnConsole();
        }

        private static ILogServiceCollection RegisterToRunsOnConsole(this ILogServiceCollection services) {
            return services.AddDependency(s => s.AddScoped<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
        }
    }
}