﻿using System;
using System.Collections.Generic;
using System.Text;
using Kafka.DotNet.ksqlDB.Infrastructure.Extensions;
using Kafka.DotNet.ksqlDB.KSql.RestApi.Statements;

namespace Kafka.DotNet.ksqlDB.KSql.RestApi.Generators
{
  internal class TypeGenerator : CreateEntityStatement
  {
    private readonly StringBuilder stringBuilder = new();

    internal string Print<T>()
    {
      stringBuilder.Clear();

      var type = typeof(T);
      
      var name = type.ExtractTypeName();

      name = name.ToUpper();

      stringBuilder.Append(@$"CREATE TYPE {name} AS STRUCT<");

      PrintProperties<T>();

      stringBuilder.Append(@">;");

      return stringBuilder.ToString();
    }

    private void PrintProperties<T>()
    {
      var ksqlProperties = new List<string>();

      foreach (var memberInfo in Members<T>())
      {
        var type = GetMemberType<T>(memberInfo);

        var ksqlType = CreateEntity.KSqlTypeTranslator(type);

        string columnDefinition = $"{memberInfo.Name} {ksqlType}{CreateEntity.ExploreAttributes(memberInfo, type)}";

        ksqlProperties.Add(columnDefinition);
      }

      stringBuilder.Append(string.Join(", ", ksqlProperties));
    }
  }
}