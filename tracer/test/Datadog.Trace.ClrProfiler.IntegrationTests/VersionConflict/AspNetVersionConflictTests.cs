// <copyright file="AspNetVersionConflictTests.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#if NETFRAMEWORK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Datadog.Trace.TestHelpers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.ClrProfiler.IntegrationTests.VersionConflict
{
    [Collection("IisTests")]
    public class AspNetVersionConflictTests : TestHelper, IClassFixture<IisFixture>
    {
        private readonly IisFixture _iisFixture;

        public AspNetVersionConflictTests(IisFixture iisFixture, ITestOutputHelper output)
            : base("AspNet.VersionConflict", @"test\test-applications\aspnet", output)
        {
            SetServiceVersion("1.0.0");

            _iisFixture = iisFixture;
            _iisFixture.ShutdownPath = "/home/shutdown";
            // There is an issue in the TracingHttpModule that causes the parent trace to be locked, making the test useless
            // This code is not run when IIS is in classic mode, so using that as a workaround
            _iisFixture.TryStartIis(this, IisAppType.AspNetClassic);
        }

        [SkippableFact]
        [Trait("Category", "EndToEnd")]
        [Trait("RunOnWindows", "True")]
        [Trait("LoadFromGAC", "True")]
        public async Task SubmitsTraces()
        {
            // 4 spans for the base request: aspnet.request / aspnet-mvc.request / Manual / Manual-Inner / http.request
            // + 2 spans for the outgoing request: aspnet.request / aspnet-mvc.request
            const int expectedSpans = 8;

            var spans = await GetWebServerSpans("/home/sendrequest", _iisFixture.Agent, _iisFixture.HttpPort, System.Net.HttpStatusCode.OK, expectedSpans, filterServerSpans: false);

            foreach (var span in spans)
            {
                Output.WriteLine($"Name:{span.Name} - TraceId:{span.TraceId} - SpanID:{span.SpanId} - ParentId:{span.ParentId} - Resource:{span.Resource}");
            }

            spans.Should().HaveCount(expectedSpans);

            // Using Single to make sure there is no orphaned span
            var rootSpan = spans.Single(s => s.ParentId == null);

            rootSpan.Name.Should().Be("aspnet.request");

            var mvcSpan = spans.Single(s => s.ParentId == rootSpan.SpanId);

            mvcSpan.TraceId.Should().Be(rootSpan.TraceId);
            mvcSpan.Name.Should().Be("aspnet-mvc.request");

            var manualSpan = spans.Single(s => s.ParentId == mvcSpan.SpanId);

            manualSpan.TraceId.Should().Be(rootSpan.TraceId);
            manualSpan.Name.Should().Be("Manual");

            var manualInnerSpan = spans.Single(s => s.ParentId == manualSpan.SpanId);

            manualInnerSpan.TraceId.Should().Be(rootSpan.TraceId);
            manualInnerSpan.Name.Should().Be("Manual-Inner");

            var automaticOuterSpan = spans.Single(s => s.ParentId == manualInnerSpan.SpanId);

            automaticOuterSpan.TraceId.Should().Be(rootSpan.TraceId);
            automaticOuterSpan.Name.Should().Be("Automatic-Outer");

            var httpSpan = spans.Single(s => s.ParentId == automaticOuterSpan.SpanId);

            httpSpan.TraceId.Should().Be(rootSpan.TraceId);
            httpSpan.Name.Should().Be("http.request");
        }

        [SkippableTheory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "EndToEnd")]
        [Trait("RunOnWindows", "True")]
        [Trait("LoadFromGAC", "True")]
        public async Task Sampling(bool parentTrace)
        {
            // 6 spans for the base request: aspnet.request / aspnet-mvc.request / Manual / http.request / http.request / Child
            // + 2 * 2 spans for the outgoing requests: aspnet.request / aspnet-mvc.request
            const int expectedSpans = 10;

            var spans = await GetWebServerSpans($"/home/sampling?parentTrace={parentTrace}", _iisFixture.Agent, _iisFixture.HttpPort, System.Net.HttpStatusCode.OK, expectedSpans, filterServerSpans: false);

            foreach (var span in spans)
            {
                var samplingPriority = string.Empty;

                if (span.Metrics.ContainsKey(Metrics.SamplingPriority))
                {
                    samplingPriority = span.Metrics[Metrics.SamplingPriority].ToString();
                }

                Output.WriteLine($"{span.Name} - {span.TraceId} - {span.SpanId} - {span.ParentId} - {span.Resource} - {samplingPriority}");
            }

            // Validate the correct hierarchy of spans
            var rootSpan = spans.Single(s => s.ParentId == null && s.Name == "aspnet.request");
            var mvcSpan = spans.Single(s => s.ParentId == rootSpan.SpanId);
            mvcSpan.TraceId.Should().Be(rootSpan.TraceId);
            mvcSpan.Name.Should().Be("aspnet-mvc.request");

            // The manual span will be in the same trace when parentTrace=true,
            // or the start of a new trace when parentTrace=false
            var manualSpan = spans.Single(s => s.Name == "Manual");
            var secondTraceId = parentTrace ? rootSpan.TraceId : manualSpan.TraceId;

            manualSpan.TraceId.Should().Be(secondTraceId);
            manualSpan.Name.Should().Be("Manual");

            var nestedSpans = spans.Where(s => s.ParentId == manualSpan.SpanId).OrderBy(s => s.Start).ToArray();
            nestedSpans.Should().HaveCount(3);

            // Validate the first http request and its subspans
            var firstHttpSpan = nestedSpans[0];

            firstHttpSpan.TraceId.Should().Be(secondTraceId);
            firstHttpSpan.Name.Should().Be("http.request");

            // Validate the second http request and its subspans
            var secondHttpSpan = nestedSpans[1];

            secondHttpSpan.TraceId.Should().Be(secondTraceId);
            secondHttpSpan.Name.Should().Be("http.request");

            var manualInnerSpan = nestedSpans[2];

            manualInnerSpan.TraceId.Should().Be(secondTraceId);
            manualInnerSpan.Name.Should().Be("Child");

            // Make sure there is no extra root span
            spans.Where(s => s.ParentId == null).Should().HaveCount(parentTrace ? 1 : 2);

            // The sampling priority should be UserKeep for all spans
            spans.Should().OnlyContain(s => VerifySpan(s, parentTrace));
        }

        [SkippableFact]
        [Trait("Category", "EndToEnd")]
        [Trait("RunOnWindows", "True")]
        [Trait("LoadFromGAC", "True")]

        public async Task ParentScope()
        {
            // aspnet.request + aspnet-mvc.request
            const int expectedSpans = 2;

            var testStart = DateTime.UtcNow;
            using var client = new HttpClient();

            var response = await client.GetAsync($"http://localhost:{_iisFixture.HttpPort}/home/parentScope");
            var content = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"server returned an error: {content}");

            var spans = _iisFixture.Agent.WaitForSpans(expectedSpans, minDateTime: testStart, returnAllOperations: true);

            spans.Should().HaveCount(expectedSpans);

            var mvcSpan = spans.Single(s => s.Name == "aspnet-mvc.request");

            mvcSpan.Tags.Should().Contain(new KeyValuePair<string, string>("Test", "OK"));

            var rootSpan = spans.Single(s => s.Name == "aspnet.request");

            rootSpan.Metrics.Should().Contain(new KeyValuePair<string, double>(Metrics.SamplingPriority, (double)SamplingPriority.UserKeep));

            var result = JObject.Parse(content);

            result.Should().NotBeNull();

            result["OperationName"].Value<string>().Should().Be(mvcSpan.Name);
            result["ResourceName"].Value<string>().Should().Be(mvcSpan.Resource);
            result["ServiceName"].Value<string>().Should().Be(mvcSpan.Service);
        }

        private static bool VerifySpan(MockTracerAgent.Span span, bool parentTrace)
        {
            if (!span.Metrics.ContainsKey(Metrics.SamplingPriority))
            {
                return true;
            }

            if (!parentTrace)
            {
                // The root asp.net trace has an automatic priority
                if (span.Name == "aspnet.request" && span.Resource == "GET /home/sampling")
                {
                    return span.Metrics[Metrics.SamplingPriority] == 1;
                }
            }

            return span.Metrics[Metrics.SamplingPriority] == 2;
        }
    }
}

#endif