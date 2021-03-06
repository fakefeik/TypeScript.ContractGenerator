﻿using System;

using Microsoft.AspNetCore.Mvc;

using SkbKontur.TypeScript.ContractGenerator;
using SkbKontur.TypeScript.ContractGenerator.Internals;

namespace AspNetCoreExample.Generator
{
    public class AspNetCoreExampleCustomGenerator : CustomTypeGenerator
    {
        public AspNetCoreExampleCustomGenerator()
        {
            const string modelsNamespace = "AspNetCoreExample.Api.Models";
            WithTypeRedirect<Guid>("Guid", @"dataTypes\Guid")
                .WithTypeLocationRule(
                    x => TypeInfo.From<ControllerBase>().IsAssignableFrom(x),
                    x => $"api/{x.Name}".Replace("Controller", "Api")
                )
                .WithTypeLocationRule(
                    x => x.FullName.StartsWith(modelsNamespace),
                    x => "dto/" + x.FullName.Substring(modelsNamespace.Length + 1).Replace(".", "/")
                )
                .WithTypeBuildingContext(ApiControllerTypeBuildingContext.Accept, (unit, type) => new ApiControllerTypeBuildingContext(unit, type));
        }
    }
}