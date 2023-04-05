﻿// <auto-generated />

#nullable enable

namespace Datadog.Trace.Configuration;

/// <summary>
/// Extension methods for <see cref="Datadog.Trace.Configuration.IntegrationId" />
/// </summary>
internal static partial class IntegrationIdExtensions
{
    /// <summary>
    /// The number of members in the enum.
    /// This is a non-distinct count of defined names.
    /// </summary>
    public const int Length = 45;

    /// <summary>
    /// Returns the string representation of the <see cref="Datadog.Trace.Configuration.IntegrationId"/> value.
    /// If the attribute is decorated with a <c>[Description]</c> attribute, then
    /// uses the provided value. Otherwise uses the name of the member, equivalent to
    /// calling <c>ToString()</c> on <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to retrieve the string value for</param>
    /// <returns>The string representation of the value</returns>
    public static string ToStringFast(this Datadog.Trace.Configuration.IntegrationId value)
        => value switch
        {
            Datadog.Trace.Configuration.IntegrationId.HttpMessageHandler => nameof(Datadog.Trace.Configuration.IntegrationId.HttpMessageHandler),
            Datadog.Trace.Configuration.IntegrationId.HttpSocketsHandler => nameof(Datadog.Trace.Configuration.IntegrationId.HttpSocketsHandler),
            Datadog.Trace.Configuration.IntegrationId.WinHttpHandler => nameof(Datadog.Trace.Configuration.IntegrationId.WinHttpHandler),
            Datadog.Trace.Configuration.IntegrationId.CurlHandler => nameof(Datadog.Trace.Configuration.IntegrationId.CurlHandler),
            Datadog.Trace.Configuration.IntegrationId.AspNetCore => nameof(Datadog.Trace.Configuration.IntegrationId.AspNetCore),
            Datadog.Trace.Configuration.IntegrationId.AdoNet => nameof(Datadog.Trace.Configuration.IntegrationId.AdoNet),
            Datadog.Trace.Configuration.IntegrationId.AspNet => nameof(Datadog.Trace.Configuration.IntegrationId.AspNet),
            Datadog.Trace.Configuration.IntegrationId.AspNetMvc => nameof(Datadog.Trace.Configuration.IntegrationId.AspNetMvc),
            Datadog.Trace.Configuration.IntegrationId.AspNetWebApi2 => nameof(Datadog.Trace.Configuration.IntegrationId.AspNetWebApi2),
            Datadog.Trace.Configuration.IntegrationId.GraphQL => nameof(Datadog.Trace.Configuration.IntegrationId.GraphQL),
            Datadog.Trace.Configuration.IntegrationId.HotChocolate => nameof(Datadog.Trace.Configuration.IntegrationId.HotChocolate),
            Datadog.Trace.Configuration.IntegrationId.MongoDb => nameof(Datadog.Trace.Configuration.IntegrationId.MongoDb),
            Datadog.Trace.Configuration.IntegrationId.XUnit => nameof(Datadog.Trace.Configuration.IntegrationId.XUnit),
            Datadog.Trace.Configuration.IntegrationId.NUnit => nameof(Datadog.Trace.Configuration.IntegrationId.NUnit),
            Datadog.Trace.Configuration.IntegrationId.MsTestV2 => nameof(Datadog.Trace.Configuration.IntegrationId.MsTestV2),
            Datadog.Trace.Configuration.IntegrationId.Wcf => nameof(Datadog.Trace.Configuration.IntegrationId.Wcf),
            Datadog.Trace.Configuration.IntegrationId.WebRequest => nameof(Datadog.Trace.Configuration.IntegrationId.WebRequest),
            Datadog.Trace.Configuration.IntegrationId.ElasticsearchNet => nameof(Datadog.Trace.Configuration.IntegrationId.ElasticsearchNet),
            Datadog.Trace.Configuration.IntegrationId.ServiceStackRedis => nameof(Datadog.Trace.Configuration.IntegrationId.ServiceStackRedis),
            Datadog.Trace.Configuration.IntegrationId.StackExchangeRedis => nameof(Datadog.Trace.Configuration.IntegrationId.StackExchangeRedis),
            Datadog.Trace.Configuration.IntegrationId.ServiceRemoting => nameof(Datadog.Trace.Configuration.IntegrationId.ServiceRemoting),
            Datadog.Trace.Configuration.IntegrationId.RabbitMQ => nameof(Datadog.Trace.Configuration.IntegrationId.RabbitMQ),
            Datadog.Trace.Configuration.IntegrationId.Msmq => nameof(Datadog.Trace.Configuration.IntegrationId.Msmq),
            Datadog.Trace.Configuration.IntegrationId.Kafka => nameof(Datadog.Trace.Configuration.IntegrationId.Kafka),
            Datadog.Trace.Configuration.IntegrationId.CosmosDb => nameof(Datadog.Trace.Configuration.IntegrationId.CosmosDb),
            Datadog.Trace.Configuration.IntegrationId.AwsSdk => nameof(Datadog.Trace.Configuration.IntegrationId.AwsSdk),
            Datadog.Trace.Configuration.IntegrationId.AwsSqs => nameof(Datadog.Trace.Configuration.IntegrationId.AwsSqs),
            Datadog.Trace.Configuration.IntegrationId.ILogger => nameof(Datadog.Trace.Configuration.IntegrationId.ILogger),
            Datadog.Trace.Configuration.IntegrationId.Aerospike => nameof(Datadog.Trace.Configuration.IntegrationId.Aerospike),
            Datadog.Trace.Configuration.IntegrationId.AzureFunctions => nameof(Datadog.Trace.Configuration.IntegrationId.AzureFunctions),
            Datadog.Trace.Configuration.IntegrationId.Couchbase => nameof(Datadog.Trace.Configuration.IntegrationId.Couchbase),
            Datadog.Trace.Configuration.IntegrationId.MySql => nameof(Datadog.Trace.Configuration.IntegrationId.MySql),
            Datadog.Trace.Configuration.IntegrationId.Npgsql => nameof(Datadog.Trace.Configuration.IntegrationId.Npgsql),
            Datadog.Trace.Configuration.IntegrationId.Oracle => nameof(Datadog.Trace.Configuration.IntegrationId.Oracle),
            Datadog.Trace.Configuration.IntegrationId.SqlClient => nameof(Datadog.Trace.Configuration.IntegrationId.SqlClient),
            Datadog.Trace.Configuration.IntegrationId.Sqlite => nameof(Datadog.Trace.Configuration.IntegrationId.Sqlite),
            Datadog.Trace.Configuration.IntegrationId.Serilog => nameof(Datadog.Trace.Configuration.IntegrationId.Serilog),
            Datadog.Trace.Configuration.IntegrationId.Log4Net => nameof(Datadog.Trace.Configuration.IntegrationId.Log4Net),
            Datadog.Trace.Configuration.IntegrationId.NLog => nameof(Datadog.Trace.Configuration.IntegrationId.NLog),
            Datadog.Trace.Configuration.IntegrationId.TraceAnnotations => nameof(Datadog.Trace.Configuration.IntegrationId.TraceAnnotations),
            Datadog.Trace.Configuration.IntegrationId.Grpc => nameof(Datadog.Trace.Configuration.IntegrationId.Grpc),
            Datadog.Trace.Configuration.IntegrationId.Process => nameof(Datadog.Trace.Configuration.IntegrationId.Process),
            Datadog.Trace.Configuration.IntegrationId.HashAlgorithm => nameof(Datadog.Trace.Configuration.IntegrationId.HashAlgorithm),
            Datadog.Trace.Configuration.IntegrationId.SymmetricAlgorithm => nameof(Datadog.Trace.Configuration.IntegrationId.SymmetricAlgorithm),
            Datadog.Trace.Configuration.IntegrationId.OpenTelemetry => nameof(Datadog.Trace.Configuration.IntegrationId.OpenTelemetry),
            _ => value.ToString(),
        };

    /// <summary>
    /// Retrieves an array of the values of the members defined in
    /// <see cref="Datadog.Trace.Configuration.IntegrationId" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// </summary>
    /// <returns>An array of the values defined in <see cref="Datadog.Trace.Configuration.IntegrationId" /></returns>
    public static Datadog.Trace.Configuration.IntegrationId[] GetValues()
        => new []
        {
            Datadog.Trace.Configuration.IntegrationId.HttpMessageHandler,
            Datadog.Trace.Configuration.IntegrationId.HttpSocketsHandler,
            Datadog.Trace.Configuration.IntegrationId.WinHttpHandler,
            Datadog.Trace.Configuration.IntegrationId.CurlHandler,
            Datadog.Trace.Configuration.IntegrationId.AspNetCore,
            Datadog.Trace.Configuration.IntegrationId.AdoNet,
            Datadog.Trace.Configuration.IntegrationId.AspNet,
            Datadog.Trace.Configuration.IntegrationId.AspNetMvc,
            Datadog.Trace.Configuration.IntegrationId.AspNetWebApi2,
            Datadog.Trace.Configuration.IntegrationId.GraphQL,
            Datadog.Trace.Configuration.IntegrationId.HotChocolate,
            Datadog.Trace.Configuration.IntegrationId.MongoDb,
            Datadog.Trace.Configuration.IntegrationId.XUnit,
            Datadog.Trace.Configuration.IntegrationId.NUnit,
            Datadog.Trace.Configuration.IntegrationId.MsTestV2,
            Datadog.Trace.Configuration.IntegrationId.Wcf,
            Datadog.Trace.Configuration.IntegrationId.WebRequest,
            Datadog.Trace.Configuration.IntegrationId.ElasticsearchNet,
            Datadog.Trace.Configuration.IntegrationId.ServiceStackRedis,
            Datadog.Trace.Configuration.IntegrationId.StackExchangeRedis,
            Datadog.Trace.Configuration.IntegrationId.ServiceRemoting,
            Datadog.Trace.Configuration.IntegrationId.RabbitMQ,
            Datadog.Trace.Configuration.IntegrationId.Msmq,
            Datadog.Trace.Configuration.IntegrationId.Kafka,
            Datadog.Trace.Configuration.IntegrationId.CosmosDb,
            Datadog.Trace.Configuration.IntegrationId.AwsSdk,
            Datadog.Trace.Configuration.IntegrationId.AwsSqs,
            Datadog.Trace.Configuration.IntegrationId.ILogger,
            Datadog.Trace.Configuration.IntegrationId.Aerospike,
            Datadog.Trace.Configuration.IntegrationId.AzureFunctions,
            Datadog.Trace.Configuration.IntegrationId.Couchbase,
            Datadog.Trace.Configuration.IntegrationId.MySql,
            Datadog.Trace.Configuration.IntegrationId.Npgsql,
            Datadog.Trace.Configuration.IntegrationId.Oracle,
            Datadog.Trace.Configuration.IntegrationId.SqlClient,
            Datadog.Trace.Configuration.IntegrationId.Sqlite,
            Datadog.Trace.Configuration.IntegrationId.Serilog,
            Datadog.Trace.Configuration.IntegrationId.Log4Net,
            Datadog.Trace.Configuration.IntegrationId.NLog,
            Datadog.Trace.Configuration.IntegrationId.TraceAnnotations,
            Datadog.Trace.Configuration.IntegrationId.Grpc,
            Datadog.Trace.Configuration.IntegrationId.Process,
            Datadog.Trace.Configuration.IntegrationId.HashAlgorithm,
            Datadog.Trace.Configuration.IntegrationId.SymmetricAlgorithm,
            Datadog.Trace.Configuration.IntegrationId.OpenTelemetry,
        };

    /// <summary>
    /// Retrieves an array of the names of the members defined in
    /// <see cref="Datadog.Trace.Configuration.IntegrationId" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// Ignores <c>[Description]</c> definitions.
    /// </summary>
    /// <returns>An array of the names of the members defined in <see cref="Datadog.Trace.Configuration.IntegrationId" /></returns>
    public static string[] GetNames()
        => new []
        {
            nameof(Datadog.Trace.Configuration.IntegrationId.HttpMessageHandler),
            nameof(Datadog.Trace.Configuration.IntegrationId.HttpSocketsHandler),
            nameof(Datadog.Trace.Configuration.IntegrationId.WinHttpHandler),
            nameof(Datadog.Trace.Configuration.IntegrationId.CurlHandler),
            nameof(Datadog.Trace.Configuration.IntegrationId.AspNetCore),
            nameof(Datadog.Trace.Configuration.IntegrationId.AdoNet),
            nameof(Datadog.Trace.Configuration.IntegrationId.AspNet),
            nameof(Datadog.Trace.Configuration.IntegrationId.AspNetMvc),
            nameof(Datadog.Trace.Configuration.IntegrationId.AspNetWebApi2),
            nameof(Datadog.Trace.Configuration.IntegrationId.GraphQL),
            nameof(Datadog.Trace.Configuration.IntegrationId.HotChocolate),
            nameof(Datadog.Trace.Configuration.IntegrationId.MongoDb),
            nameof(Datadog.Trace.Configuration.IntegrationId.XUnit),
            nameof(Datadog.Trace.Configuration.IntegrationId.NUnit),
            nameof(Datadog.Trace.Configuration.IntegrationId.MsTestV2),
            nameof(Datadog.Trace.Configuration.IntegrationId.Wcf),
            nameof(Datadog.Trace.Configuration.IntegrationId.WebRequest),
            nameof(Datadog.Trace.Configuration.IntegrationId.ElasticsearchNet),
            nameof(Datadog.Trace.Configuration.IntegrationId.ServiceStackRedis),
            nameof(Datadog.Trace.Configuration.IntegrationId.StackExchangeRedis),
            nameof(Datadog.Trace.Configuration.IntegrationId.ServiceRemoting),
            nameof(Datadog.Trace.Configuration.IntegrationId.RabbitMQ),
            nameof(Datadog.Trace.Configuration.IntegrationId.Msmq),
            nameof(Datadog.Trace.Configuration.IntegrationId.Kafka),
            nameof(Datadog.Trace.Configuration.IntegrationId.CosmosDb),
            nameof(Datadog.Trace.Configuration.IntegrationId.AwsSdk),
            nameof(Datadog.Trace.Configuration.IntegrationId.AwsSqs),
            nameof(Datadog.Trace.Configuration.IntegrationId.ILogger),
            nameof(Datadog.Trace.Configuration.IntegrationId.Aerospike),
            nameof(Datadog.Trace.Configuration.IntegrationId.AzureFunctions),
            nameof(Datadog.Trace.Configuration.IntegrationId.Couchbase),
            nameof(Datadog.Trace.Configuration.IntegrationId.MySql),
            nameof(Datadog.Trace.Configuration.IntegrationId.Npgsql),
            nameof(Datadog.Trace.Configuration.IntegrationId.Oracle),
            nameof(Datadog.Trace.Configuration.IntegrationId.SqlClient),
            nameof(Datadog.Trace.Configuration.IntegrationId.Sqlite),
            nameof(Datadog.Trace.Configuration.IntegrationId.Serilog),
            nameof(Datadog.Trace.Configuration.IntegrationId.Log4Net),
            nameof(Datadog.Trace.Configuration.IntegrationId.NLog),
            nameof(Datadog.Trace.Configuration.IntegrationId.TraceAnnotations),
            nameof(Datadog.Trace.Configuration.IntegrationId.Grpc),
            nameof(Datadog.Trace.Configuration.IntegrationId.Process),
            nameof(Datadog.Trace.Configuration.IntegrationId.HashAlgorithm),
            nameof(Datadog.Trace.Configuration.IntegrationId.SymmetricAlgorithm),
            nameof(Datadog.Trace.Configuration.IntegrationId.OpenTelemetry),
        };
}