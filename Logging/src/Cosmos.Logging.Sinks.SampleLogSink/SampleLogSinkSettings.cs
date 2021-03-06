﻿using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Settings;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogSinkSettings : ILogSinkSettings {
        public string Key => "SampleLog";
        public string Name { get; set; } = $"SampleLogSink_{DateTime.Now.ToString("yyyyMMdd_HHmmssffff")}";
        public LogEventLevel? Level { get; set; }
    }
}