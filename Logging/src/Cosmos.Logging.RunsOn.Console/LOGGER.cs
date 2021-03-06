﻿using System;
using System.Collections.Generic;
using AspectCore.Injector;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.Console.Core;
using Cosmos.Logging.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console {
    public static class LOGGER {
        public static ILogServiceCollection Initialize() {
            return Initialize((IConfigurationBuilder) null);
        }

        public static ILogServiceCollection Initialize(IConfigurationBuilder builder) {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ILoggingServiceProvider, ConsoleLoggingServiceProvider>();
            return IocContainer.Initialize(services, builder);
        }

        public static ILogServiceCollection Initialize(IConfigurationRoot root) {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ILoggingServiceProvider, ConsoleLoggingServiceProvider>();
            return IocContainer.Initialize(services, root);
        }

        public static IServiceProvider GetScopedServiceResolver() => IocContainer.GetScopedServiceResolver();

        private static ILoggingServiceProvider TouchProvider() => IocContainer.GetServiceResolver().GetService<ILoggingServiceProvider>();

        public static ILogger GetLogger(LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(mode);
        }

        public static ILogger GetLogger(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(name, mode);
        }

        public static ILogger GetLogger(LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(level, mode);
        }

        public static ILogger GetLogger(string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(name, level, mode);
        }

        public static ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, mode);
        }

        public static ILogger GetLogger(Type type, string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, name, mode);
        }

        public static ILogger GetLogger(Type type, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, level, mode);
        }

        public static ILogger GetLogger(Type type, string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, name, level, mode);
        }

        public static ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(mode);
        }

        public static ILogger GetLogger<T>(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(name, mode);
        }

        public static ILogger GetLogger<T>(LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(level, mode);
        }

        public static ILogger GetLogger<T>(string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(name, level, mode);
        }
    }
}