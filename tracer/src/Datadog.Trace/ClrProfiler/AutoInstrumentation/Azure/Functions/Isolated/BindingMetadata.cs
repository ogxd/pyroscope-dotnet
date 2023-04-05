﻿// <copyright file="BindingMetadata.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#if !NETFRAMEWORK
#nullable enable
using Datadog.Trace.DuckTyping;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Azure.Functions;

[DuckCopy]
internal struct BindingMetadata
{
    public BindingDirection Direction;
    [Duck(Name = "Type")]
    public string? BindingType;
}
#endif
